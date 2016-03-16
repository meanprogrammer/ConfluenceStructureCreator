using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public class PageByTitleAndKeyOutput_ProfilePicture
    {
        public string path { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public bool isDefault { get; set; }
    }

    public class PageByTitleAndKeyOutput_By
    {
        public string type { get; set; }
        public PageByTitleAndKeyOutput_ProfilePicture profilePicture { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string userKey { get; set; }
    }

    public class PageByTitleAndKeyOutput_Version
    {
        public PageByTitleAndKeyOutput_By by { get; set; }
        public string when { get; set; }
        public int number { get; set; }
        public bool minorEdit { get; set; }
    }

    public class PageByTitleAndKeyOutput_Expandable
    {
        public string content { get; set; }
    }

    public class PageByTitleAndKeyOutput_Storage
    {
        public string value { get; set; }
        public string representation { get; set; }
        public PageByTitleAndKeyOutput_Expandable _expandable { get; set; }
    }

    public class PageByTitleAndKeyOutput_Expandable2
    {
        public string editor { get; set; }
        public string view { get; set; }
        public string export_view { get; set; }
        public string anonymous_export_view { get; set; }
    }

    public class PageByTitleAndKeyOutput_Body
    {
        public PageByTitleAndKeyOutput_Storage storage { get; set; }
        public PageByTitleAndKeyOutput_Expandable2 _expandable { get; set; }
    }

    public class PageByTitleAndKeyOutput_Extensions
    {
        public string position { get; set; }
    }

    public class PageByTitleAndKeyOutput_Links
    {
        public string webui { get; set; }
        public string tinyui { get; set; }
        public string self { get; set; }
    }

    public class PageByTitleAndKeyOutput_Expandable3
    {
        public string container { get; set; }
        public string metadata { get; set; }
        public string operations { get; set; }
        public string children { get; set; }
        public string history { get; set; }
        public string ancestors { get; set; }
        public string descendants { get; set; }
        public string space { get; set; }
    }

    public class PageByTitleAndKeyOutput_Result
    {
        public string id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public PageByTitleAndKeyOutput_Version version { get; set; }
        public PageByTitleAndKeyOutput_Body body { get; set; }
        public PageByTitleAndKeyOutput_Extensions extensions { get; set; }
        public PageByTitleAndKeyOutput_Links _links { get; set; }
        public PageByTitleAndKeyOutput_Expandable3 _expandable { get; set; }
    }

    public class PageByTitleAndKeyOutput_Links2
    {
        public string self { get; set; }
        public string @base { get; set; }
        public string context { get; set; }
    }

    public class PageByTitleAndKeyOutput
    {
        public List<PageByTitleAndKeyOutput_Result> results { get; set; }
        public int start { get; set; }
        public int limit { get; set; }
        public int size { get; set; }
        public PageByTitleAndKeyOutput_Links2 _links { get; set; }
    }



}
