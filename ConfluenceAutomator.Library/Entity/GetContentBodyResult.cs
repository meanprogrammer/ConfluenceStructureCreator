using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public class GetContentBodyResultExpandable
    {
        public string content { get; set; }
    }

    public class Storage
    {
        public string value { get; set; }
        public string representation { get; set; }
        public GetContentBodyResultExpandable _expandable { get; set; }
    }

    public class Expandable2
    {
        public string editor { get; set; }
        public string view { get; set; }
        public string export_view { get; set; }
        public string anonymous_export_view { get; set; }
    }

    public class Body
    {
        public Storage storage { get; set; }
        public Expandable2 _expandable { get; set; }
    }

    public class Extensions
    {
        public string position { get; set; }
    }

    public class GetContentBodyResultLinks
    {
        public string webui { get; set; }
        public string tinyui { get; set; }
        public string collection { get; set; }
        public string @base { get; set; }
        public string context { get; set; }
        public string self { get; set; }
    }

    public class Expandable3
    {
        public string container { get; set; }
        public string metadata { get; set; }
        public string operations { get; set; }
        public string children { get; set; }
        public string history { get; set; }
        public string ancestors { get; set; }
        public string version { get; set; }
        public string descendants { get; set; }
        public string space { get; set; }
    }

    public class GetContentBodyResult
    {
        public string id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public Body body { get; set; }
        public Extensions extensions { get; set; }
        public GetContentBodyResultLinks _links { get; set; }
        public Expandable3 _expandable { get; set; }
    }
}
