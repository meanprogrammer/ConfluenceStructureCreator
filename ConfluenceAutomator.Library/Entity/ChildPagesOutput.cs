using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public class ChildPagesOutput_Extensions
    {
        public string position { get; set; }
    }

    public class ChildPagesOutput_Links
    {
        public string webui { get; set; }
        public string tinyui { get; set; }
        public string self { get; set; }
    }

    public class ChildPagesOutput_Expandable
    {
        public string container { get; set; }
        public string metadata { get; set; }
        public string operations { get; set; }
        public string children { get; set; }
        public string history { get; set; }
        public string ancestors { get; set; }
        public string body { get; set; }
        public string version { get; set; }
        public string descendants { get; set; }
        public string space { get; set; }
    }

    public class ChildPagesOutput_Result
    {
        public string id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public ChildPagesOutput_Extensions extensions { get; set; }
        public ChildPagesOutput_Links _links { get; set; }
        public ChildPagesOutput_Expandable _expandable { get; set; }
    }

    public class ChildPagesOutput_Links2
    {
        public string self { get; set; }
        public string @base { get; set; }
        public string context { get; set; }
    }

    public class ChildPagesOutput
    {
        public List<ChildPagesOutput_Result> results { get; set; }
        public int start { get; set; }
        public int limit { get; set; }
        public int size { get; set; }
        public ChildPagesOutput_Links2 _links { get; set; }
    }
}
