using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public class ChildPageResultExtensions
    {
        public string position { get; set; }
    }

    public class ChildPageResultLinks
    {
        public string webui { get; set; }
        public string tinyui { get; set; }
        public string self { get; set; }
    }

    public class ChildPageResultExpandable
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

    public class ChildPageResultResult
    {
        public string id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public ChildPageResultExtensions extensions { get; set; }
        public ChildPageResultLinks _links { get; set; }
        public ChildPageResultExpandable _expandable { get; set; }
    }

    public class ChildPageResultLinks2
    {
        public string self { get; set; }
        public string @base { get; set; }
        public string context { get; set; }
    }

    public class ChildPageResult
    {
        public List<ChildPageResultResult> results { get; set; }
        public int start { get; set; }
        public int limit { get; set; }
        public int size { get; set; }
        public ChildPageResultLinks2 _links { get; set; }
    }
}
