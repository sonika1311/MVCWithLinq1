using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Runtime.Serialization;

namespace MVCWithLinq1.Models
{
    public class StudentDAL
    {
        MVCDBDataContext context = new MVCDBDataContext(ConfigurationManager.ConnectionStrings["MVCDBConnectionString"].ConnectionString);
        public List<Student> GetStudents(bool? status)
        {
            List<Student> students = null;
            try
            {
                if(status == null)
                { 
                    students = (from s in context.Students select s).ToList();
                }
                else
                {
                    students = (from s in context.Students where s.Status==status select s).ToList();
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            return students;
        }
        public Student GetStudent(int id,bool status)
        {
            Student student;
            try
            {
                if (status == null)
                {
                    student = (from s in context.Students where s.Sid == id select s).Single();
                }
                else
                {
                    student = (from s in context.Students where s.Sid==id && status==true select s).Single();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return student;
        }
        public void AddStudent(Student student)
        {
            try
            {
                context.Students.InsertOnSubmit(student);
                context.SubmitChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateStudent(Student updatedStudent)
        {
            try
            {
                //select * from Student s where s.Sid==updatedStudent.Sid
                Student student = context.Students.First(s => s.Sid == updatedStudent.Sid);
                student.Name = updatedStudent.Name;
                student.Class = updatedStudent.Class;
                student.Fees = updatedStudent.Fees;
                student.Photo = updatedStudent.Photo;
                context.SubmitChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteStudent(int Sid)
        {
            Student student = context.Students.First(s => s.Sid == Sid);
            student.Status = false; //Soft Delete
            //context.Students.DeleteOnSubmit(student);//permanent deletion
            context.SubmitChanges();
            
        }
    }
}