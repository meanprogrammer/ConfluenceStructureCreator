using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConfluenceAutomator.Library.Helper
{
    public class MappingHelper
    {
        public static PageTreeMapping GetMapping()
        {
            PageTreeMapping mappings = null;
            string path = "TreeMappings.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(PageTreeMapping));

            StreamReader reader = new StreamReader(path);
            mappings = (PageTreeMapping)serializer.Deserialize(reader);
            reader.Close();
            return mappings;
        }
    }
}
