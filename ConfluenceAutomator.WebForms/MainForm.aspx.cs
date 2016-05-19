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
            ConfluenceSpaceTaskExecutor confSpaceService = new ConfluenceSpaceTaskExecutor(this);
            AllSpaces r = confSpaceService.ExecuteWeb(string.Empty, "vd2:Welcome2");
            //this.pare.ValueMember = Strings.KEY;
            //this.ParentSpaceComboBox.DisplayMember = Strings.NAME;
            //this.ParentSpaceComboBox.DataSource = r.results;

            this.ParentSpaceTreeView.Nodes.Add(StructureConstant.GetStructureAsTreeNodeWeb());
            //this.ParentSpaceTreeView.ExpandAll();
        }

        public void Log(string message)
        {
            throw new NotImplementedException();
        }
    }
}