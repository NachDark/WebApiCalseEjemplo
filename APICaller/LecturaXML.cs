using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace APICaller
{
    public class LecturaXML
    {
        public void LecturaXML_Nodes(string filepath) {
            string text = string.Empty;
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                 text += node.InnerText; //or loop through its children as well
            }
            MessageBox.Show(text);
        }
        public ItemsReaded? LecturaXML_Deserialize(string filepath)
        {
            ItemsReaded? i = null;
            var serializer = new XmlSerializer(typeof(ItemsReaded));
            using (Stream reader = new FileStream(filepath, FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                 i = serializer.Deserialize(reader) as ItemsReaded;
            }
            return i;

        }
        public Pizzeria? LecturaXML_Deserialize(string filepath, bool test)
        {
            Pizzeria? i = null;
            var serializer = new XmlSerializer(typeof(Pizzeria));
            using (Stream reader = new FileStream(filepath, FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                i = serializer.Deserialize(reader) as Pizzeria;
            }
            return null;

        }




    }
}
