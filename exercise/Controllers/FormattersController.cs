using exercise.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace exercise.Controllers
{
    /// <summary>
    /// in http , Accept and Content-type in header specified the data type sended to server
    /// and receive from server
    /// </summary>
    public class FormattersController : ApiController
    {
        public static List<Book> books = new List<Book>()
        {
            new Book(){Name="violet",TotalPages =15,Author="Toms",Publisher="HenLin",PublicationDate = DateTime.Now },
            new Book(){Name="ctads",TotalPages =10,Author="T2ms",Publisher="HenasdLin",PublicationDate = DateTime.Now.AddDays(-1) },
        };

        public string GetBooks()
        {
            // Convert all dates to UTC when use json format
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            var jsonResult = JsonConvert.SerializeObject(books);
            return jsonResult;
        }   
    }
}
