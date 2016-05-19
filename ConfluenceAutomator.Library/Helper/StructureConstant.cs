using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ConfluenceAutomator.Library
{
    public class StructureConstant
    {

        #region old_structure
        public static Dictionary<string, List<string>> GetStructure()
        {
            Dictionary<string, List<string>> list = new Dictionary<string, List<string>>();
            list.Add(
                "0. Planning Phase",
                    new List<string>() { 
                        "0.01 Concept Paper", 
                        "0.02 Business Case", 
                        "0.03 High-level Process and Vision Design", 
                        "0.04 High Level Solutions Design", 
                        "0.05 SDLC Activities and Deliverables Checklist", 
                        "0.06 Process and Sub-process Documents", 
                        "0.07 Business Scenarios", 
                        "0.08 Solution Deployment Strategy" 
            });


            list.Add("1 Operations Analysis Phase",
                new List<string>() { 
                    "1.01 Functional Requirements", 
                    "1.02 Non-Functional Requirements", 
                    "1.03 Mockup/Prototypes", 
                    "1.04 Detailed Use Case Specificatoins", 
                    "1.05 Information Models", 
                    "1.06 Security Profiles", 
                    "1.07 Gap Analysis", 
                    "1.08 Application and Infrastructure Design", 
                    "1.09 Project Master Test Plan", 
                    "1.10 Data Conversion Plan", 
                    "1.11 Business Change Management Strategy", 
                    "1.12 Needs Analysis", 
                    "1.13 High-level Solution Deployment Plan", 
                    "1.14 Transition and Maintenance Plan" 
            }); ;
            list.Add("2. Solution Design Phase",
                new List<string>() { 
                    "2.01 Application Setup", 
                    "2.02 Application Extensions Functional Design", 
                    "2.03 Application Extensions Technilca Design - Database Design", 
                    "2.04 Detailed Prototype", 
                    "2.05 High Level Solution Design", 
                    "2.06 Unit Test Plan", 
                    "2.07 Unit Test Scripts", 
                    "2.08 SIT Plans", 
                    "2.09 SIT Scripts", 
                    "2.10 Security Test Plan", 
                    "2.11 Security Test Scripts", 
                    "2.12 Performance and Stress Test Plan", 
                    "2.13 Performance and Stress Test Scripts", 
                    "2.14 Regression Test Plan", 
                    "2.15 Business Change Management Strategy", 
                    "2.16 Needs Analysis", "2.18 Training Plan", 
                    "2.19 Training Manual", 
                    "2.20 Conversion Data Mapping", 
                    "2.21 High-level Solution Deployment Plan", 
                    "2.22 Transition and Maintenance Plan" });

            list.Add("3. Build Phase",
                new List<string>() { 
                    "3.01 Unit Test Report", 
                    "3.02 SIT Report", 
                    "3.03 Security Test Report", 
                    "3.04 Performance and Stress Test Report", 
                    "3.05 Regression Test Plan", 
                    "3.06 Solution Deployment Plan", 
                    "3.07 Conversion Program",
                    "3.08 Conversion Test Report",
                    "3.09 UAT Plan", 
                    "3.10 UAT Scripts", 
                    "3.11 Needs Analysis", 
                    "3.12 BCM Communication Plan",
                    "3.13 Training Plan",
                    "3.14 Training Manual", 
                    "3.15 Transition and Maintenance Plan" 
                });
            list.Add("4. Transition Phase",
                new List<string>() { 
                    "4.01 UAT Report", 
                    "4.02 Usability Test Report", 
                    "4.03 Converted Data Validation Report", 
                    "4.04 BCM Communication Plan", 
                    "4.05 Training Plan", "4.06 Training Manual", 
                    "4.07 Solution Deployment Plan", 
                    "4.08 Transition and Maintenance Procedures"
            });
            list.Add("5. Production Phase", new List<string>() { "5.01 Business and Technical Directions Recommendations" });
            list.Add("6. Project Management ", new List<string>() { 
                "6.01 Risk Register", 
                "6.02 Issue Register", 
                "6.03 Status Reports", 
                "6.04 Change Requests", 
                "6.05 Meeting Minutes", 
                "6.06 Stakeholder Matrix", 
                "6.07 Team Roster" });

            return list;
        }
        #endregion

        public static List<ConfluencePage> GetTaxonomy(bool isWeb)
        {

            List<ConfluencePage> structure = null;
            string path = "TargetSpace.xml";

            if (isWeb)
            {
                path = HttpContext.Current.Server.MapPath(string.Format("~/bin/{0}", path));
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<ConfluencePage>));

            StreamReader reader = new StreamReader(path);
            structure = (List<ConfluencePage>)serializer.Deserialize(reader);
            reader.Close();
            return structure;

            /*
            var list = new List<ConfluencePage>();
            var a = new ConfluencePage();
            a.Title = "0. Planning Phase";
            a.Content = ConstantContent.DISPLAY_CHILDREN_MARKUP;
            a.HasAttachmentWidget = true;
            a.ChildPages.Add(new ConfluencePage() { Title = "0.01 Concept Paper" });
            a.ChildPages.Add(new ConfluencePage() { Title = "0.02 Business Case", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            a.ChildPages.Add(new ConfluencePage() { Title = "0.03 High-level Process and Vision Design", Content = string.Empty });
            a.ChildPages.Add(new ConfluencePage() { Title = "0.04 High Level Solutions Design", Content = string.Empty });
            a.ChildPages.Add(new ConfluencePage() { Title = "0.05 SDLC Activities and Deliverables Checklist", Content = string.Empty });
            a.ChildPages.Add(new ConfluencePage() { Title = "0.06 Process and Sub-process Documents", Content = string.Empty });
            a.ChildPages.Add(new ConfluencePage() { Title = "0.07 Business Scenarios", Content = string.Empty });
            a.ChildPages.Add(new ConfluencePage() { Title = "0.08 Solution Deployment Strategy", Content = string.Empty });
            list.Add(a);
            
            var b = new ConfluencePage();
            b.Title = "1. Operations Analysis Phase";
            b.Content = ConstantContent.DISPLAY_CHILDREN_MARKUP;
            b.ChildPages.Add(new ConfluencePage() { Title = "1.01 Functional Requirements", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.02 Non-Functional Requirements", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.03 Mockups/Prototypes", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.04 Detailed Use Case Specifications", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.05 Information Models", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.06 Security Profiles", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.07 Gap Analysis", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.08 Application and Infrastructure Design",  HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.09 Project Master Test Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.10 Data Conversion Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.11 Business Change Management Strategy", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.12 Needs Analysis", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.13 High-level Solution Deployment Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.14 Transition and Maintenance Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            list.Add(b);
            
            var c = new ConfluencePage();
            c.Title = "2. Solution Design Phase";
            c.Content = ConstantContent.DISPLAY_CHILDREN_MARKUP;
            c.ChildPages.Add(new ConfluencePage() { Title = "2.01 Application Setup", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.02 Application Extensions Functional Design", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.03 Application Extensions Technilca Design - Database Design", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.04 Detailed Prototype", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.05 High Level Solution Design", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.06 Unit Test Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.07 Unit Test Scripts", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.08 SIT Plans", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.09 SIT Scripts", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.10 Security Test Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.11 Security Test Scripts", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.12 Performance and Stress Test Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.13 Performance and Stress Test Scripts", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.14 Regression Test Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.15 Business Change Management Strategy", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.16 Needs Analysis", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.18 Training Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.19 Training Manual", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.20 Conversion Data Mapping", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.21 High-level Solution Deployment Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.22 Transition and Maintenance Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            list.Add(c);

            var d = new ConfluencePage();
            d.Title = "3. Build Phase";
            d.Content = ConstantContent.DISPLAY_CHILDREN_MARKUP;
            d.ChildPages.Add(new ConfluencePage() { Title = "3.01 Unit Test Report", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.02 SIT Report", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.03 Security Test Report", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.04 Performance and Stress Test Report", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.05 Regression Test Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.06 Solution Deployment Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.07 Conversion Program", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.08 Conversion Test Report", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.09 UAT Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.10 UAT Scripts", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.11 Needs Analysis", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.12 BCM Communication Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.13 Training Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.14 Training Manual", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.15 Transition and Maintenance Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            list.Add(d);

            var e = new ConfluencePage();
            e.Title = "4. Transition Phase";
            e.Content = ConstantContent.DISPLAY_CHILDREN_MARKUP;
            e.ChildPages.Add(new ConfluencePage() { Title = "4.01 UAT Report", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            e.ChildPages.Add(new ConfluencePage() { Title = "4.02 Usability Test Report", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            e.ChildPages.Add(new ConfluencePage() { Title = "4.03 Converted Data Validation Report", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            e.ChildPages.Add(new ConfluencePage() { Title = "4.04 BCM Communication Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            e.ChildPages.Add(new ConfluencePage() { Title = "4.05 Training Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            e.ChildPages.Add(new ConfluencePage() { Title = "4.06 Training Manual", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            e.ChildPages.Add(new ConfluencePage() { Title = "4.07 Solution Deployment Plan", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            e.ChildPages.Add(new ConfluencePage() { Title = "4.08 Transition and Maintenance Procedures", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            list.Add(e);

            var f = new ConfluencePage();
            f.Title = "5. Production Phase";
            f.Content = ConstantContent.DISPLAY_CHILDREN_MARKUP;
            f.ChildPages.Add(new ConfluencePage() { Title = "5.01 Business and Technical Directions Recommendations", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            f.ChildPages.Add(new ConfluencePage() { Title = "5.02 How to Archles", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            f.ChildPages.Add(new ConfluencePage() { Title = "5.03 Troubleshooting Articles", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            list.Add(f);

            var g = new ConfluencePage();
            g.Title = "6. Project Management";
            g.Content = ConstantContent.DISPLAY_CHILDREN_MARKUP;
            g.ChildPages.Add(new ConfluencePage() { Title = "6.01 Risk Register", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            g.ChildPages.Add(new ConfluencePage() { Title = "6.02 Issue Register", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            g.ChildPages.Add(new ConfluencePage() { Title = "6.03 Status Reports", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            g.ChildPages.Add(new ConfluencePage() { Title = "6.04 Change Requests", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            g.ChildPages.Add(new ConfluencePage() { Title = "6.05 Meeting Minutes", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            g.ChildPages.Add(new ConfluencePage() { Title = "6.06 Stakeholder Matrix", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            g.ChildPages.Add(new ConfluencePage() { Title = "6.07 Team Roster", HasAttachmentWidget = true, HasContributorSummaryWidget = true });
            list.Add(g);
            
            return list;
            
            */
        }

        public static TreeNode GetStructureAsTreeNode()
        {
            TreeNode tn = new TreeNode("Target Space");

            var list = GetTaxonomy(false);

            foreach (ConfluencePage c in list)
            {
                TreeNode fNode = new TreeNode(c.Title);
                fNode.Tag = c;
                foreach (ConfluencePage cc in c.ChildPages)
                {
                    TreeNode tnc = new TreeNode(cc.Title);
                    tnc.Tag = cc;
                    fNode.Nodes.Add(tnc);
                }
                tn.Nodes.Add(fNode);
            }
            return tn;
        }

        public static System.Web.UI.WebControls.TreeNode GetStructureAsTreeNodeWeb()
        {
            System.Web.UI.WebControls.TreeNode tn = new System.Web.UI.WebControls.TreeNode();
            var list = GetTaxonomy(true);

            foreach (ConfluencePage c in list)
            {
                System.Web.UI.WebControls.TreeNode fNode = new System.Web.UI.WebControls.TreeNode(c.Title);
                fNode.Value = JsonConvert.SerializeObject(c);
                foreach (ConfluencePage cc in c.ChildPages)
                {
                    System.Web.UI.WebControls.TreeNode tnc = new System.Web.UI.WebControls.TreeNode(cc.Title);
                    tnc.Value = JsonConvert.SerializeObject(cc);
                    fNode.ChildNodes.Add(tnc);
                }
                tn.ChildNodes.Add(fNode);
            }

            return tn;
        }

        public static List<ConfluencePage> ExtractFromTreeView(TreeNode treeNode)
        {
            List<ConfluencePage> masterList = new List<ConfluencePage>();
            foreach (TreeNode tn in treeNode.Nodes)
            {
                List<ConfluencePage> childList = new List<ConfluencePage>();
                foreach (TreeNode tn2 in tn.Nodes)
                {
                    childList.Add(tn2.Tag as ConfluencePage);
                }
                ConfluencePage cp = tn.Tag as ConfluencePage;
                if (cp != null)
                {
                    cp.ChildPages.Clear();
                    cp.ChildPages.AddRange(childList);
                    masterList.Add(cp);
                }
            }
            return masterList;
        }
    }

    public class ConfluencePage
    {
        public ConfluencePage() { this.ChildPages = new List<ConfluencePage>(); }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool HasAttachmentWidget { get; set; }
        public bool HasContributorSummaryWidget { get; set; }
        public List<ConfluencePage> ChildPages { get; set; }
    }
}
