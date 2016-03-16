using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public class SpaceInput_Plain
    {
        public string value { get; set; }
        public string representation { get { return "plain"; } }
    }

    public class SpaceInput_Description
    {
        public SpaceInput_Plain plain { get; set; }
    }

    public class SpaceInput
    {
        public SpaceInput()
        {
            this.description = new SpaceInput_Description();
            this.description.plain = new SpaceInput_Plain();
        }
        public string key { get; set; }
        public string name { get; set; }
        public string type { get { return "global"; } }
        public SpaceInput_Description description { get; set; }
    }
}
