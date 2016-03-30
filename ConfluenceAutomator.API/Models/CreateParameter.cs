using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfluenceAutomator.API.Models
{
    public class CreateParameter
    {
        public string Title { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public string ParentKey { get; set; }
    }
}