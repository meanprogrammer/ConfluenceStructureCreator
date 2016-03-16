using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public class Plain
    {
        public string value { get; set; }
        public string representation { get { return "plain"; } }
    }

    public class Description
    {
        public Plain plain { get; set; }
    }

    public class Space
    {
        public Space()
        {
            this.description = new Description();
            this.description.plain = new Plain();
        }
        public string key { get; set; }
        public string name { get; set; }
        public string type { get { return "global"; } }
        public Description description { get; set; }
    }
}
