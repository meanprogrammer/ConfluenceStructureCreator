using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{

    public class PageTreeMapping
    {
        public string FromSpace { get; set; }
        public string ToSpace { get; set; }

        public List<PageTreeMappingItem> Mappings { get; set; }
    }

    public class PageTreeMappingItem
    {
        public string FromPageTitle { get; set; }
        public string ToPageTitle { get; set; }
    }
}
