using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    [Serializable()]
    public class PageTreeMapping
    {
        public string FromSpace { get; set; }
        public string ToSpace { get; set; }

        public List<PageTreeMappingItem> Mappings { get; set; }
        public List<BackwardPageTreeMapping> BackwardMappings { get; set; }
    }
    [Serializable()]
    public class PageTreeMappingItem
    {
        public string FromPageTitle { get; set; }
        public string ToPageTitle { get; set; }
    }

    [Serializable()]
    public class BackwardPageTreeMapping
    {
        public string FromPageTitle { get; set; }
        public string ToPageTitle { get; set; }
    }
}
