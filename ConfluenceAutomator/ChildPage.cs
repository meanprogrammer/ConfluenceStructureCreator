using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator
{

    public class ChildPageAncestor
        {
            public int id { get; set; }
        }

    public class ChildPageSpace
        {
            public string key { get; set; }
        }

    public class ChildPageStorage
        {
            public string value { get; set; }
            public string representation { get; set; }
        }

    public class ChildPageBody
        {
        public ChildPageStorage storage { get; set; }
        }

        public class ChildPage
        {
            public string type { get; set; }
            public string title { get; set; }
            public List<ChildPageAncestor> ancestors { get; set; }
            public ChildPageSpace space { get; set; }
            public ChildPageBody body { get; set; }
        }
    
}
