using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapHtmlHelper.Util.Tree
{
    class Node
    {
        public int ParentID;
        public string Title;
        public int ID;
        public List<Node> SubItems;
    }
}
