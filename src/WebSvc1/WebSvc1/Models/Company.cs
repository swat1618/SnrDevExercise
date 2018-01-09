using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebSvc1.Models
{
    [Serializable]
    [XmlRoot(ElementName ="company")]
    public class Company
    {
        [XmlElement(ElementName= "CompanyName")]
		public string CompanyName { get; set; }
        [XmlElement(ElementName = "Director")]
        public string Director { get; set; }
        [XmlElement(ElementName = "DateOfIncorporation")]
        public string DateOfIncorporation { get; set; }
        [XmlElement(ElementName = "Address")]
        public string Address { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName = "Region")]
        public string Region { get; set; }
        [XmlElement(ElementName = "Phone")]
        public string Phone { get; set; }
        [XmlElement(ElementName = "OrgNo")]
        public string OrgNo { get; set; }
    }
}