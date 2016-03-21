using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public class StructureHelper
    {
        public static List<ConfluencePage> AlterWithNewContent(List<ConfluencePage> list, string key, string newContent)
        {
            var result = list;
            foreach (ConfluencePage c in list)
            {
                if (c.Title == key)
                {
                    c.Content = newContent;
                    return list;
                }
                if (c.ChildPages.Count > 0)
                {
                    result = AlterWithNewContent(c.ChildPages, key, newContent);
                }
                else
                {
                    continue;
                }
            }
            return result;
        }
    }
}
