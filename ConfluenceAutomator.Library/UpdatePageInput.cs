using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{


    public class UpdatePageInputSpace
    {
        public string key { get; set; }
    }

    public class UpdatePageInputStorage
    {
        public string value { get; set; }
        public string representation { get; set; }
    }

    public class UpdatePageInputBody
    {
        public UpdatePageInputStorage storage { get; set; }
    }

    public class UpdatePageInputVersion
    {
        public int number { get; set; }
    }

    public class UpdatePageInput
    {
        public UpdatePageInput()
        {
            space = new UpdatePageInputSpace();
            body = new UpdatePageInputBody();
            body.storage = new UpdatePageInputStorage();
            body.storage.representation = "storage";
            version = new UpdatePageInputVersion();
            type = "page";
        }

        public string id { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public UpdatePageInputSpace space { get; set; }
        public UpdatePageInputBody body { get; set; }
        public UpdatePageInputVersion version { get; set; }
    }
}
