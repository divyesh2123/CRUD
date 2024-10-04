using ClosedXML.Excel;
using FileUploadHandle.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadHandle.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult SingleFileUpload()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult SingleFileUpload(IFormFile file)
        {

            if (file != null && file.Length > 0)
            {
                //Create an Instance of ExcelFileHandling
                ExcelFileHandling excelFileHandling = new ExcelFileHandling();
                //Call the CreateExcelFile method by passing the stream object which contains the Excel file
                var employees = excelFileHandling.ParseExcelFile(file.OpenReadStream());
                // Now save these employees to the database
                using (var context = new EFCoreDbContext())
                {
                     context.Employees.AddRange(employees);
                     context.SaveChanges();
                }
                return View("UploadSuccess"); // Redirect to a view showing success or list of products
            }

            return View("UploadSuccess");
        }
    

        public IActionResult UploadSuccess()
        {
            return View("UploadSuccess");
        }

        //This Method will Stream Object as an input which contains the Excel file
        //And then convert that Excel file to List of Employees
        public List<Employee> ParseExcelFile(Stream stream)
        {
            var employees = new List<Employee>();

            //Create a workbook instance
            //Opens an existing workbook from a stream.
            using (var workbook = new XLWorkbook(stream))
            {
                //Lets assume the First Worksheet contains the data
                var worksheet = workbook.Worksheet(1);

                //Lets assume first row contains the header, so skip the first row
                var rows = worksheet.RangeUsed().RowsUsed().Skip(1);

                //Loop Through all the Rows except the first row which contains the header data
                foreach (var row in rows)
                {
                    //Create an Instance of Employee object and populate it with the Excel Data Row
                    var employee = new Employee
                    {
                        Name = row.Cell(1).GetValue<string>(),
                        Departmet = row.Cell(2).GetValue<string>(),
                        Salary = row.Cell(3).GetValue<long>(),
                        Position = row.Cell(4).GetValue<string>(),
                        DateOfJoining = row.Cell(5).GetValue<DateTime>(),
                    };

                    //Add the Employee to the List of Employees
                    employees.Add(employee);
                }
            }

            //Finally return the List of Employees
            return employees;
        }

        public IActionResult ExportToExcel()
        {
            //Get the Employee data from the database
            EFCoreDbContext dbContext = new EFCoreDbContext();
            var employees = dbContext.Employees.ToList();

            //Create an Instance of ExcelFileHandling
            ExcelFileHandling excelFileHandling = new ExcelFileHandling();
            //Call the CreateExcelFile method by passing the list of Employee
            var stream = excelFileHandling.CreateExcelFile(employees);

            //Give a Name to your Excel File
            string excelName = $"Employees-{Guid.NewGuid()}.xlsx";

            // 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' is the MIME type for Excel files
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
    }
}
