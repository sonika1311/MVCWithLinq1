using MVCWithLinq1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithLinq1.Controllers
{
    public class StudentController : Controller
    {
        StudentDAL obj = new StudentDAL();
        public ViewResult DisplayStudents()
        {
            return View(obj.GetStudents(null));
        }
        public ViewResult DisplayStudent(int sid)
        {
            return View(obj.GetStudent(sid, true));
        }
        [HttpGet]
        public ViewResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddStudent(Student student, HttpPostedFileBase selectedFile)
        {
            return RedirectToAction("DisplayStudents");
        }
    }
}