using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{

    public class PageByTitleAndKeyResultExpandable
    {
        public string content { get; set; }
    }

    public class PageByTitleAndKeyResultStorage
    {
        public string value { get; set; }
        public string representation { get; set; }
        public PageByTitleAndKeyResultExpandable _expandable { get; set; }
    }

    public class PageByTitleAndKeyResultExpandable2
    {
        public string editor { get; set; }
        public string view { get; set; }
        public string export_view { get; set; }
        public string anonymous_export_view { get; set; }
    }

    public class PageByTitleAndKeyResultBody
    {
        public PageByTitleAndKeyResultStorage storage { get; set; }
        public PageByTitleAndKeyResultExpandable2 _expandable { get; set; }
    }

    public class PageByTitleAndKeyResultExtensions
    {
        public string position { get; set; }
    }

    public class PageByTitleAndKeyResultLinks
    {
        public string webui { get; set; }
        public string tinyui { get; set; }
        public string self { get; set; }
    }

    public class PageByTitleAndKeyResultExpandable3
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

    public class PageByTitleAndKeyResultResult
    {
        public string id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public PageByTitleAndKeyResultBody body { get; set; }
        public PageByTitleAndKeyResultExtensions extensions { get; set; }
        public PageByTitleAndKeyResultLinks _links { get; set; }
        public PageByTitleAndKeyResultExpandable3 _expandable { get; set; }
    }

    public class PageByTitleAndKeyResultLinks2
    {
        public string self { get; set; }
        public string @base { get; set; }
        public string context { get; set; }
    }

    public class PageByTitleAndKeyResult
    {
        public List<PageByTitleAndKeyResultResult> results { get; set; }
        public int start { get; set; }
        public int limit { get; set; }
        public int size { get; set; }
        public PageByTitleAndKeyResultLinks2 _links { get; set; }
    }

}
