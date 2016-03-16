using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{

    public class Links
    {
        public string self { get; set; }
    }

    public class Expandable
    {
        public string icon { get; set; }
        public string description { get; set; }
        public string homepage { get; set; }
    }

    public class Result
    {
        public int id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public Links _links { get; set; }
        public Expandable _expandable { get; set; }
    }

    public class Links2
    {
        public string self { get; set; }
        public string @base { get; set; }
        public string context { get; set; }
    }

    public class AllSpaces
    {
        public List<Result> results { get; set; }
        public int start { get; set; }
        public int limit { get; set; }
        public int size { get; set; }
        public Links2 _links { get; set; }
    }
}
