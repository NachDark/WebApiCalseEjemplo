using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace APICaller
{
    public class Pizza
    {
        [XmlAttribute("nombre")]
        public string Nombre { get; set; }

        [XmlAttribute("precio")]
        public double Precio { get; set; }

        [XmlElement("ingrediente")]
        public List<Ingrediente> Ingredientes { get; set; }
    }
    public class Ingrediente
    {
        [XmlAttribute("nombre")]
        public string Nombre { get; set; }
    }
}
