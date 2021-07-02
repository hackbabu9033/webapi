using exercise.CustomResult;
using exercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace exercise.Controllers
{
    /// <summary>
    ///　* web api has four categories of return type
    ///　  void 
    ///　  C# object type
    ///    HttpResponseMessage
    ///    IHttpActionResult
    ///  *
    /// </summary>
    public class ReturnTypeController:ApiController
    {
        public static List<Student> students = new List<Student>() {
            new Student() { Id = 0, Name = "hank" },
            new Student() { Id = 1, Name = "deadeye" },
            new Student() { Id = 2, Name = "rider" },
            new Student() { Id = 3, Name = "Fjaags"},
        };

        [HttpPost]
        [Route("add")]
        public void Post([FromBody] Student student)
        {
            var clinet = HttpContext.Current;
            students.Add(student);
        }

        [HttpGet]
        public List<Student> GetStudentsById([FromUri] List<int> ids)
        {
            return students.Where(o => ids.Contains(o.Id)).ToList();
        }

        [HttpDelete]
        public HttpResponseMessage DeleteStudent([FromUri] int id)
        {
            try
            {
                var deletedStudent = students.Where(o => o.Id == id).First();
                if (!students.Remove(deletedStudent))
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Content = new StringContent("delete student fail!")
                    };
                }                
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    Request.CreateResponse(HttpStatusCode.NotFound,id);
                }               
            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("delete success !")
            };
        }

        [HttpPut]
        public IHttpActionResult PutStudent([FromBody]Student student)
        {
            try
            {
                var updateStudent = students.Where(o => o.Id == student.Id).First();
                updateStudent.Name = student.Name;
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    return NotFound();
                }
            }
            return Ok(student);
        }

        [HttpGet]
        [Route("customResult")]
        public IHttpActionResult GetTextResult([FromUri]int id)
        {
            var student = students.Where(o => o.Id == id).First();
            if(student == null)
            {
                return NotFound();
            }
            return new TextResult(student.Name, Request);
        }
    }
}