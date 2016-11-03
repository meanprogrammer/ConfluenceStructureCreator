using ConfluenceAutomator.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConfluenceAutomator.WebForms
{
    public partial class MainForm : System.Web.UI.Page, IFormLogger
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ConfluenceSpaceTaskExecutor confSpaceService = new ConfluenceSpaceTaskExecutor(this);
                AllSpaces r = confSpaceService.ExecuteWeb(string.Empty, "vd2:Welcome4");
                this.ParentSpaceDropDownList.DataValueField = Strings.KEY;
                this.ParentSpaceDropDownList.DataTextField = Strings.NAME;
                this.ParentSpaceDropDownList.DataSource = r.results;
                this.ParentSpaceDropDownList.DataBind();

                ParentSpaceDropDownList_SelectedIndexChanged(sender, e);

                this.TargetSpaceTreeView.Nodes.Add(StructureConstant.GetStructureAsTreeNodeWeb());
            }
            //this.ParentSpaceTreeView.ExpandAll();
        }

        public void Log(string message)
        {
            
        }

        protected void ParentSpaceDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfluenceSpaceTaskExecutor confSpaceService = new ConfluenceSpaceTaskExecutor(this);
            TreeNode node = confSpaceService.CreateSpaceTreeNodeWeb(confSpaceService.ExecuteWeb(string.Empty, "vd2:Welcome4").results.Where(x => x.key == this.ParentSpaceDropDownList.SelectedValue).FirstOrDefault());
            this.PSpaceTreeView.Nodes.Clear();
            this.PSpaceTreeView.Nodes.Add(node);
        }
    }
}