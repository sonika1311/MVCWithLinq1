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
        #region Display
        StudentDAL obj = new StudentDAL();
        public ViewResult DisplayStudents()
        {
            return View(obj.GetStudents(null));
        }
        public ViewResult DisplayStudent(int sid)
        {
            return View(obj.GetStudent(sid, true));
        }
        #endregion

        #region AddStudent
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
            obj.AddStudent(student);
            return RedirectToAction("DisplayStudents");
        }
        #endregion
        #region Edit and Update
        public ViewResult EditStudent(int sid)
        {
            //select * from student s where s.sid=103
            Student student = obj.GetStudent(sid, true);
            return View(student);
        }
        #endregion

    }
}