using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapHtmlHelper.Util.Tree
{
    public class Node
    {
        public int ParentID { get; set; }
        public string Title { get; set; }
        public int ID { get; set; }
        public List<Node> SubItems { get; set; }
        public string Icon { get; set; }
        public int Level { get; set; }
    }
}
