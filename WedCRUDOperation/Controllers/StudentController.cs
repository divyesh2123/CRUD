using Microsoft.AspNetCore.Mvc;
using WedCRUDOperation.Models;

namespace WedCRUDOperation.Controllers
{
    public class StudentController : Controller
    {

        

        public IActionResult Index()
        {
            StudentDataAccessLayer d = new StudentDataAccessLayer();
            var mydata = d.GetAllStudent();
            return View(mydata);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            StudentDataAccessLayer studentDataAccessLayer = new StudentDataAccessLayer();   
            var d = studentDataAccessLayer.GetStudentData(id);
            return View("Create",d);
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if(!ModelState.IsValid)
            {
                return View(student);   
            }

            StudentDataAccessLayer studentDataAccessLayer = new StudentDataAccessLayer();
            
            if(student.Id >0)
            {
                studentDataAccessLayer.UpdateStudent(student);
            }
            else
            {
                studentDataAccessLayer.AddStudent(student);
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult DeleteInfo(int id)
        {
            StudentDataAccessLayer studentDataAccessLayer = new StudentDataAccessLayer();
            studentDataAccessLayer.DeleteStudent(id);
            return RedirectToAction("Index");
        }


        }
}
