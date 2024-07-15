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
                student = (from s in context.Students where s.Sid == id select s).Single();
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
    }
}