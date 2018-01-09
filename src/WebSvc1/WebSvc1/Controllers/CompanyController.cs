using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Xml;
using System.Web.Http;
using WebSvc1.Models;
using System.Xml.Serialization;

namespace WebSvc1.Controllers
{
    public class CompanyController : ApiController
    {
        private static IList<Company> CompaniesList = LoadCompanies();

        private static IList<Company> LoadCompanies()
        {
            List<Company> loadedCompanies = new List<Company>();
            try
            {
                const string resourceName = "WebSvc1.Resources.companies.xml";
                var serialiser = new XmlSerializer(typeof(Company));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    using (var xmlRdr = XmlReader.Create(stream))
                    {
                        while (xmlRdr.Read())
                        {
                            switch (xmlRdr.NodeType)
                            {
                                case XmlNodeType.Element:
                                    {
                                        if (xmlRdr.Name == "company")
                                        {
                                            var co = serialiser.Deserialize(xmlRdr) as Company;
                                            loadedCompanies.Add(co);
                                        }
                                        break;
                                    }
                                default:
                                    break;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Could not read file.", ex);
            }

            return loadedCompanies;
        }

        // GET: api/Company
        public IEnumerable<Company> Get()
        {
            if (CompaniesList == null || CompaniesList.Count == 0)
            {
                throw new InvalidDataException("List of companies was not loaded.");
            }

            return CompaniesList;
        }

        // GET: api/Company/5
        public Company Get(int id)
        {
            return null;
        }

        // POST: api/Company
        public void Post([FromBody]Company value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Company/5
        public void Put(int id, [FromBody]Company value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Company/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
