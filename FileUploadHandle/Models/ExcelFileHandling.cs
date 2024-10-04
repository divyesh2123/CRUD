using ClosedXML.Excel;

namespace FileUploadHandle.Models
{
    public class ExcelFileHandling
    {
        //This Method will Create an Excel Sheet and Store it in the Memory Stream Object
        //And return thar Memory Stream Object
        public MemoryStream CreateExcelFile(List<Employee> employees)
        {
            //Create an Instance of Workbook, i.e., Creates a new Excel workbook
            var workbook = new XLWorkbook();
            //Add a Worksheets with the workbook
            //Worksheets name is Employees
            IXLWorksheet worksheet = workbook.Worksheets.Add("Employees");
            //Create the Cell
            //First Row is going to be Header Row
            worksheet.Cell(1, 1).Value = "ID"; //First Row and First Column
            worksheet.Cell(1, 2).Value = "Name"; //First Row and Second Column
            worksheet.Cell(1, 3).Value = "Departmet"; //First Row and Third Column
            worksheet.Cell(1, 4).Value = "Salary"; //First Row and Fourth Column
            worksheet.Cell(1, 5).Value = "Position"; //First Row and Fifth Column
            worksheet.Cell(1, 6).Value = "Date of Joining"; //First Row and Sixth Column
            //Data is going to stored from Row 2
            int row = 2;
            //Loop Through Each Employees and Populate the worksheet
            //For Each Employee increase row by 1
            foreach (var emp in employees)
            {
                worksheet.Cell(row, 1).Value = emp.Id;
                worksheet.Cell(row, 2).Value = emp.Name;
                worksheet.Cell(row, 3).Value = emp.Departmet;
                worksheet.Cell(row, 4).Value = emp.Salary;
                worksheet.Cell(row, 5).Value = emp.Position;
                worksheet.Cell(row, 6).Value = emp.DateOfJoining;
                row++; //Increasing the Data Row by 1
            }
            //Create an Memory Stream Object
            var stream = new MemoryStream();
            //Saves the current workbook to the Memory Stream Object.
            workbook.SaveAs(stream);
            //The Position property gets or sets the current position within the stream.
            //This is the next position a read, write, or seek operation will occur from.
            stream.Position = 0;
            return stream;
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

    }
}

