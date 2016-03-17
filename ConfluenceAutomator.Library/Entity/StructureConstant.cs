using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public class StructureConstant
    {
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




        public static List<ConfluencePage> GetTaxonomy()
        {
            var list = new List<ConfluencePage>();
            var a = new ConfluencePage();
            a.Title = "0. Planning Phase";
            a.Content = ConstantContent.DISPLAY_CHILDREN_MARKUP;
            a.ChildPages.Add(new ConfluencePage() { Title = "0.01 Concept Paper", Content = string.Empty });
            a.ChildPages.Add(new ConfluencePage() { Title = "0.02 Business Case", Content = string.Format("{0}{1}", ConstantContent.FILE_LIST_MARKUP, ConstantContent.CONTRIBUTOR_MARKUP) });
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
            b.ChildPages.Add(new ConfluencePage() { Title = "1.01 Functional Requirements", Content = string.Format("{0}{1}", ConstantContent.FILE_LIST_MARKUP, ConstantContent.CONTRIBUTOR_MARKUP) });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.02 Non-Functional Requirements", Content = string.Empty });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.03 Mockup/Prototypes", Content = string.Empty });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.04 Detailed Use Case Specificatoins", Content = string.Empty });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.05 Information Models", Content = string.Empty });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.06 Security Profiles", Content = string.Empty });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.07 Gap Analysis", Content = string.Empty });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.08 Application and Infrastructure Design", Content = string.Empty });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.09 Project Master Test Plan", Content = string.Empty });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.10 Data Conversion Plan", Content = string.Empty });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.11 Business Change Management Strategy", Content = string.Empty });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.12 Needs Analysis", Content = string.Empty });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.13 High-level Solution Deployment Plan", Content = string.Empty });
            b.ChildPages.Add(new ConfluencePage() { Title = "1.14 Transition and Maintenance Plan", Content = string.Empty });
            list.Add(b);
            

            var c = new ConfluencePage();
            c.Title = "2. Solution Design Phase";
            c.Content = ConstantContent.DISPLAY_CHILDREN_MARKUP;
            c.ChildPages.Add(new ConfluencePage() { Title = "2.01 Application Setup", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.02 Application Extensions Functional Design", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.03 Application Extensions Technilca Design - Database Design", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.04 Detailed Prototype", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.05 High Level Solution Design", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.06 Unit Test Plan", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.07 Unit Test Scripts", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.08 SIT Plans", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.09 SIT Scripts", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.10 Security Test Plan", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.11 Security Test Scripts", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.12 Performance and Stress Test Plan", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.13 Performance and Stress Test Scripts", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.14 Regression Test Plan", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.15 Business Change Management Strategy", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.16 Needs Analysis", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.18 Training Plan", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.19 Training Manual", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.20 Conversion Data Mapping", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.21 High-level Solution Deployment Plan", Content = string.Empty });
            c.ChildPages.Add(new ConfluencePage() { Title = "2.22 Transition and Maintenance Plan", Content = string.Empty });
            list.Add(c);

            var d = new ConfluencePage();
            d.Title = "3. Build Phase";
            d.Content = ConstantContent.DISPLAY_CHILDREN_MARKUP;
            d.ChildPages.Add(new ConfluencePage() { Title = "3.01 Unit Test Report", Content = string.Empty });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.02 SIT Report", Content = string.Empty });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.03 Security Test Report", Content = string.Empty });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.04 Performance and Stress Test Report", Content = string.Empty });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.05 Regression Test Plan", Content = string.Empty });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.06 Solution Deployment Plan", Content = string.Empty });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.07 Conversion Program",Content = string.Empty });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.08 Conversion Test Report",Content = string.Empty });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.09 UAT Plan", Content = string.Empty });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.10 UAT Scripts", Content = string.Empty });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.11 Needs Analysis", Content = string.Empty });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.12 BCM Communication Plan",Content = string.Empty });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.13 Training Plan",Content = string.Empty });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.14 Training Manual", Content = string.Empty });
            d.ChildPages.Add(new ConfluencePage() { Title = "3.15 Transition and Maintenance Plan", Content = string.Empty });
            list.Add(d);

            var e = new ConfluencePage();
            e.Title = "4. Transition Phase";
            e.Content = ConstantContent.DISPLAY_CHILDREN_MARKUP;
            e.ChildPages.Add(new ConfluencePage() { Title = "4.01 UAT Report", Content = string.Empty });
            e.ChildPages.Add(new ConfluencePage() { Title = "4.02 Usability Test Report", Content = string.Empty });
            e.ChildPages.Add(new ConfluencePage() { Title = "4.03 Converted Data Validation Report", Content = string.Empty });
            e.ChildPages.Add(new ConfluencePage() { Title = "4.04 BCM Communication Plan", Content = string.Empty });
            e.ChildPages.Add(new ConfluencePage() { Title = "4.05 Training Plan", Content = string.Empty });
            e.ChildPages.Add(new ConfluencePage() { Title = "4.06 Training Manual", Content = string.Empty });
            e.ChildPages.Add(new ConfluencePage() { Title = "4.07 Solution Deployment Plan", Content = string.Empty });
            e.ChildPages.Add(new ConfluencePage() { Title = "4.08 Transition and Maintenance Procedures", Content = string.Empty });
            list.Add(e);

            var f = new ConfluencePage();
            f.Title = "5. Production Phase";
            f.Content = ConstantContent.DISPLAY_CHILDREN_MARKUP;
            f.ChildPages.Add(new ConfluencePage() { Title = "5.01 Business and Technical Directions Recommendations", Content = string.Empty });
            list.Add(f);

            var g = new ConfluencePage();
            g.Title = "6. Project Management";
            g.Content = ConstantContent.DISPLAY_CHILDREN_MARKUP;
            g.ChildPages.Add(new ConfluencePage() { Title = "6.01 Risk Register", Content = string.Empty });
            g.ChildPages.Add(new ConfluencePage() { Title = "6.02 Issue Register", Content = string.Empty });
            g.ChildPages.Add(new ConfluencePage() { Title = "6.03 Status Reports", Content = string.Empty });
            g.ChildPages.Add(new ConfluencePage() { Title = "6.04 Change Requests", Content = string.Empty });
            g.ChildPages.Add(new ConfluencePage() { Title = "6.05 Meeting Minutes", Content = string.Empty });
            g.ChildPages.Add(new ConfluencePage() { Title = "6.06 Stakeholder Matrix", Content = string.Empty });
            g.ChildPages.Add(new ConfluencePage() { Title = "6.07 Team Roster", Content = string.Empty });
            list.Add(g);
          
            
            return list;
        }
    }

    public class ConfluencePage
    {
        public ConfluencePage() { this.ChildPages = new List<ConfluencePage>(); }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<ConfluencePage> ChildPages { get; set; }
    }
}
