using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace ConfluenceAutomator.Library
{
    public class MappingHelper
    {
        public static PageTreeMapping GetMapping(string currentSpace, bool isWeb)
        {
            PageTreeMapping mappings = null;
            string path = "TreeMappings.xml";

            if (isWeb)
            {
                path = HttpContext.Current.Server.MapPath(string.Format("~/bin/{0}", path));
            }

            XmlSerializer serializer = new XmlSerializer(typeof(PageTreeMapping));

            StreamReader reader = new StreamReader(path);
            mappings = (PageTreeMapping)serializer.Deserialize(reader);
            mappings.ToSpace = currentSpace;
            reader.Close();
            return mappings;
        }
    }
}
