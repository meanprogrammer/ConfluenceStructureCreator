using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator
{

    public class Plain
    {
        public string value { get; set; }
        public string representation { get; set; }
    }

    public class Expandable
    {
        public string view { get; set; }
    }

    public class Description
    {
        public Plain plain { get; set; }
        public Expandable _expandable { get; set; }
    }

    public class Extensions
    {
        public string position { get; set; }
    }

    public class Links
    {
        public string webui { get; set; }
        public string tinyui { get; set; }
        public string self { get; set; }
    }

    public class Expandable2
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

    public class Homepage
    {
        public string id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public Extensions extensions { get; set; }
        public Links _links { get; set; }
        public Expandable2 _expandable { get; set; }
    }

    public class Links2
    {
        public string collection { get; set; }
        public string @base { get; set; }
        public string context { get; set; }
        public string self { get; set; }
    }

    public class Expandable3
    {
        public string icon { get; set; }
    }

    public class SpaceResult
    {
        public int id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public Description description { get; set; }
        public Homepage homepage { get; set; }
        public string type { get; set; }
        public Links2 _links { get; set; }
        public Expandable3 _expandable { get; set; }
    }

}
