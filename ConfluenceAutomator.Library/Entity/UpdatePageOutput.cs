using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public class UpdatePageOutput_Links
    {
        public string self { get; set; }
    }

    public class UpdatePageOutput_Expandable
    {
        public string icon { get; set; }
        public string description { get; set; }
        public string homepage { get; set; }
    }

    public class UpdatePageOutput_Space
    {
        public int id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public UpdatePageOutput_Links _links { get; set; }
        public UpdatePageOutput_Expandable _expandable { get; set; }
    }

    public class UpdatePageOutput_ProfilePicture
    {
        public string path { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public bool isDefault { get; set; }
    }

    public class UpdatePageOutput_CreatedBy
    {
        public string type { get; set; }
        public UpdatePageOutput_ProfilePicture profilePicture { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string userKey { get; set; }
    }

    public class UpdatePageOutput_Links2
    {
        public string self { get; set; }
    }

    public class UpdatePageOutput_Expandable2
    {
        public string lastUpdated { get; set; }
        public string previousVersion { get; set; }
        public string nextVersion { get; set; }
    }

    public class UpdatePageOutput_History
    {
        public bool latest { get; set; }
        public UpdatePageOutput_CreatedBy createdBy { get; set; }
        public string createdDate { get; set; }
        public UpdatePageOutput_Links2 _links { get; set; }
        public UpdatePageOutput_Expandable2 _expandable { get; set; }
    }

    public class UpdatePageOutput_ProfilePicture2
    {
        public string path { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public bool isDefault { get; set; }
    }

    public class UpdatePageOutput_By
    {
        public string type { get; set; }
        public UpdatePageOutput_ProfilePicture2 profilePicture { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string userKey { get; set; }
    }

    public class UpdatePageOutput_Version
    {
        public UpdatePageOutput_By by { get; set; }
        public string when { get; set; }
        public int number { get; set; }
        public bool minorEdit { get; set; }
    }

    public class UpdatePageOutput_Extensions
    {
        public string position { get; set; }
    }

    public class UpdatePageOutput_Links3
    {
        public string webui { get; set; }
        public string tinyui { get; set; }
        public string self { get; set; }
    }

    public class UpdatePageOutput_Expandable3
    {
        public string container { get; set; }
        public string metadata { get; set; }
        public string operations { get; set; }
        public string children { get; set; }
        public string history { get; set; }
        public string ancestors { get; set; }
        public string body { get; set; }
        public string version { get; set; }
        public string descendants { get; set; }
        public string space { get; set; }
    }

    public class UpdatePageOutput_Ancestor
    {
        public string id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public UpdatePageOutput_Extensions extensions { get; set; }
        public UpdatePageOutput_Links3 _links { get; set; }
        public UpdatePageOutput_Expandable3 _expandable { get; set; }
    }

    public class UpdatePageOutput_Links4
    {
        public string self { get; set; }
    }

    public class UpdatePageOutput_Expandable4
    {
        public string icon { get; set; }
        public string description { get; set; }
        public string homepage { get; set; }
    }

    public class UpdatePageOutput_Container
    {
        public int id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public UpdatePageOutput_Links4 _links { get; set; }
        public UpdatePageOutput_Expandable4 _expandable { get; set; }
    }

    public class UpdatePageOutput_Expandable5
    {
        public string content { get; set; }
    }

    public class UpdatePageOutput_Storage
    {
        public string value { get; set; }
        public string representation { get; set; }
        public UpdatePageOutput_Expandable5 _expandable { get; set; }
    }

    public class UpdatePageOutput_Expandable6
    {
        public string editor { get; set; }
        public string view { get; set; }
        public string export_view { get; set; }
        public string anonymous_export_view { get; set; }
    }

    public class UpdatePageOutput_Body
    {
        public UpdatePageOutput_Storage storage { get; set; }
        public UpdatePageOutput_Expandable6 _expandable { get; set; }
    }

    public class UpdatePageOutput_Extensions2
    {
        public string position { get; set; }
    }

    public class UpdatePageOutput_Links5
    {
        public string webui { get; set; }
        public string tinyui { get; set; }
        public string collection { get; set; }
        public string @base { get; set; }
        public string context { get; set; }
        public string self { get; set; }
    }

    public class UpdatePageOutput_Expandable7
    {
        public string metadata { get; set; }
        public string operations { get; set; }
        public string children { get; set; }
        public string descendants { get; set; }
    }

    public class UpdatePageOutput
    {
        public string id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public UpdatePageOutput_Space space { get; set; }
        public UpdatePageOutput_History history { get; set; }
        public UpdatePageOutput_Version version { get; set; }
        public List<UpdatePageOutput_Ancestor> ancestors { get; set; }
        public UpdatePageOutput_Container container { get; set; }
        public UpdatePageOutput_Body body { get; set; }
        public UpdatePageOutput_Extensions2 extensions { get; set; }
        public UpdatePageOutput_Links5 _links { get; set; }
        public UpdatePageOutput_Expandable7 _expandable { get; set; }
    }
}
