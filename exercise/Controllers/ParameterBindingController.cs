using Antlr.Runtime.Tree;
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
   
    public class ParameterBindingController : ApiController
    {
        public static List<Student> students = new List<Student>() {
            new Student() { Id = 0, Name = "hank" },
            new Student() { Id = 1, Name = "deadeye" },
            new Student() { Id = 2, Name = "rider" }
        };

        /// <summary>
        /// Query String : primitive type/complex type
        /// Request Body : complex type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public Student Get(int id)
        //{
        //    return students.Where(o => o.Id == id).FirstOrDefault();
        //}

        /// <summary>
        /// * by default , primitive type is getted from querystring
        /// and complex type is getted from request body *
        /// </summary>
        /// <param name="test"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        //public Student Get(Student student)
        //{
        //    return students.Where(o => o.Id == student.Id && o.Name == student.Name).FirstOrDefault();
        //}

        /// <summary>
        /// * use attribute to set the way action controller get parameter
        /// ex : api/school?id=1&name=hank then Web API will create Student object and set its id and
        /// name property values to the value of id and name query string *
        /// </summary>
        /// <param name="test"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student Get([FromUri]Student student)
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
        
    }
}
