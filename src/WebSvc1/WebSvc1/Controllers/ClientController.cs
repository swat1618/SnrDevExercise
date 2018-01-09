using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WebSvc1.Models;

namespace WebSvc1.Controllers
{
    public class ClientController : ApiController
    {
        // GET: api/Client
        public IEnumerable<Client> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/Client/5
        public Client Get(int id)
        {
            return this.ReadClientFromFile();
        }

        // POST: api/Client
        public void Post([FromBody]Client value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Client/5
        public void Put(int id, [FromBody]Client value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Client/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        private Client ReadClientFromFile()
        {
            var encoder = new BasicHttpBinding(BasicHttpSecurityMode.None).CreateBindingElements()
                .Find<MessageEncodingBindingElement>()?.CreateMessageEncoderFactory()
                .Encoder;

            const string resourceName = "WebSvc1.Resources.client.xml";
            var serialiser = new XmlSerializer(typeof(Client));

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                Message requestMessage = encoder.ReadMessage(stream, 0x10000, "text/xml");

                using (var xmlReader = requestMessage.GetReaderAtBodyContents())
                {
                    xmlReader.ReadStartElement("Process", "http://IntelliFlo.com/");
                    xmlReader.MoveToStartElement("request", "http://IntelliFlo.com/");
                    while (xmlReader.Read())
                    {
                        switch (xmlReader.NodeType)
                        {
                            case XmlNodeType.Element:
                            {
                                if (xmlReader.Name == "personal_client")
                                {
                                    var client = serialiser.Deserialize(xmlReader) as Client;
                                    return client;
                                }
                                break;
                            }
                            default:
                                break;
                        }
                    }
                }
            }

            return null;
        }
    }
}
