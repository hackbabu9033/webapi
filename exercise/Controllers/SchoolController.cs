using exercise.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace exercise.Controllers
{
    public class SchoolController : ApiController
    {
        public static List<Student> students = new List<Student>() {
            new Student() { Id = 0, Name = "hank" },
            new Student() { Id = 1, Name = "deadeye" },
            new Student() { Id = 2, Name = "rider" }
        };      

        /// <summary>
        /// Query String : primitive type/complex type
        /// Request Body : NA
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student Get(int id)
        {
            return students.Where(o => o.Id == id).FirstOrDefault();
        }

        public Student Get(Student student)
        {
            return students.Where(o => o.Id == student.Id && o.Name == student.Name).FirstOrDefault();
        }
        

        /// <summary>
        /// Query String : primitive type/complex type
        /// Request Body : complex type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Post(int id, string name)
        {
            students.Add(new Student() { Id = id, Name = name });
        }

        public void Post(Student student)
        {
            students.Add(student);
        }
    }
}
