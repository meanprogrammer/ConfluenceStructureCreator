using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public class Expandable4
    {
        public string view { get; set; }
    }

    public class SpaceOutput_Description2
    {
        public SpaceInput_Plain plain { get; set; }
        public Expandable4 _expandable { get; set; }
    }

    public class SpaceByTitleAndKeyResultResultExtensions
    {
        public string position { get; set; }
    }

    public class Links4
    {
        public string webui { get; set; }
        public string tinyui { get; set; }
        public string self { get; set; }
    }

    public class SpaceByTitleAndKeyResultResultExpandable2
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

    public class SpaceOutput_Homepage
    {
        public string id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public SpaceByTitleAndKeyResultResultExtensions extensions { get; set; }
        public Links4 _links { get; set; }
        public SpaceByTitleAndKeyResultResultExpandable2 _expandable { get; set; }
    }

    public class SpaceOutput_Links3
    {
        public string collection { get; set; }
        public string @base { get; set; }
        public string context { get; set; }
        public string self { get; set; }
    }

    public class SpaceByTitleAndKeyResultResultExpandable3
    {
        public string icon { get; set; }
    }

    public class SpaceOutput
    {
        public int id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public SpaceOutput_Description2 description { get; set; }
        public SpaceOutput_Homepage homepage { get; set; }
        public string type { get; set; }
        public SpaceOutput_Links3 _links { get; set; }
        public SpaceByTitleAndKeyResultResultExpandable3 _expandable { get; set; }
    }

}
