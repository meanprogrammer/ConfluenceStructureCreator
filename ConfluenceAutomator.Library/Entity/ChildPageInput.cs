using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{

    public class ChildPage_Ancestor
        {
            public int id { get; set; }
        }

    public class ChildPage_Space
        {
            public string key { get; set; }
        }

    public class ChildPage_Storage
        {
            public string value { get; set; }
            public string representation { get; set; }
        }

    public class ChildPage_Body
        {
        public ChildPage_Storage storage { get; set; }
        }

        public class ChildPageInput
        {
            public string type { get; set; }
            public string title { get; set; }
            public List<ChildPage_Ancestor> ancestors { get; set; }
            public ChildPage_Space space { get; set; }
            public ChildPage_Body body { get; set; }
        }
    
}
