using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace exercise.Models
{
    /// <summary>
    /// If class has DataContract attribute , then all properties
    /// will be ignored for json convert unless they have DataMember attribute
    /// </summary>
    [DataContract]
    public class Book
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int TotalPages { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string Publisher { get; set; }
        [DataMember]
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
    }
}