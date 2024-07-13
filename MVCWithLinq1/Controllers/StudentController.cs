using MVCWithLinq1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

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
            if (selectedFile!=null)
            {
                string directoryPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                selectedFile.SaveAs(directoryPath+selectedFile.FileName);
                student.Photo = selectedFile.FileName;
                student.Status = true;
            }
            return RedirectToAction("DisplayStudents");
        }
    }
}