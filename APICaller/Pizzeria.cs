using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace APICaller
{
    [XmlRoot("pizzas")]
    public class Pizzeria
    {
        [XmlElement("pizza")]
        public List<Pizza> Pizzas { get; set; }
    }
}
