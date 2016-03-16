using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{


    public class UpdatePageInput_Space
    {
        public string key { get; set; }
    }

    public class UpdatePageInput_Storage
    {
        public string value { get; set; }
        public string representation { get; set; }
    }

    public class UpdatePageInput_Body
    {
        public UpdatePageInput_Storage storage { get; set; }
    }

    public class UpdatePageInput_Version
    {
        public int number { get; set; }
    }

    public class UpdatePageInput
    {
        public UpdatePageInput()
        {
            space = new UpdatePageInput_Space();
            body = new UpdatePageInput_Body();
            body.storage = new UpdatePageInput_Storage();
            body.storage.representation = "storage";
            version = new UpdatePageInput_Version();
            type = "page";
        }

        public string id { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public UpdatePageInput_Space space { get; set; }
        public UpdatePageInput_Body body { get; set; }
        public UpdatePageInput_Version version { get; set; }
    }
}
