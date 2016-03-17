using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public class PageTreeItem
    {
        public string Title { get; set; }
        public string Key { get; set; }
        public List<PageTreeItem> Children { get; set; }
    }
}
