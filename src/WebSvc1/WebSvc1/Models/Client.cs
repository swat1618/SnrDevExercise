using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebSvc1.Models
{
    [Serializable]
    [XmlRoot(ElementName = "personal_client")]
    public class Client
    {
        [XmlElement(ElementName = "external_client_reference")]
        public string External_client_reference { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "forenames")]
        public string Forenames { get; set; }
        [XmlElement(ElementName = "surname")]
        public string Surname { get; set; }
        [XmlElement(ElementName = "sex")]
        public string Sex { get; set; }
        [XmlElement(ElementName = "date_of_birth")]
        public string Date_of_birth { get; set; }
        [XmlElement(ElementName = "primary_employment_status")]
        public string Primary_employment_status { get; set; }
        [XmlElement(ElementName = "smoker_ind")]
        public string Smoker_ind { get; set; }
        [XmlElement(ElementName = "occupation_category")]
        public string Occupation_category { get; set; }
        [XmlElement(ElementName = "occupation_class")]
        public string Occupation_class { get; set; }
        [XmlElement(ElementName = "job_title")]
        public string Job_title { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }
}