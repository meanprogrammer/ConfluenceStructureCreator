using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfluenceAutomator.Library
{
    public class TreeNodeHelper
    {
        public static TreeNode GetFirstCheckedChild(TreeNodeCollection nodes)
        {
            TreeNode result = null;
            foreach (TreeNode tn in nodes)
            {
                if (tn.Checked)
                {
                    result = tn;
                    break;
                }
            }
            return result;
        }
    }
}
