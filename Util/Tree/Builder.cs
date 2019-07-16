using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapHtmlHelper.Util.Tree
{
    public class Builder
    {
        private List<Node> _items;
        public Builder(List<Node> list)
        {
            _items = list;
            
        }

        public List<Node> getTree()
        {
            Node root = new Node { ID = 0, ParentID = 0, SubItems=new List<Node>() };
            BuildTree(root, 0);
            return root.SubItems;
        }
        public void BuildTree(Node root, int ParentID)
        {
            foreach(Node item in _items)
            {
                if (item.ParentID == ParentID)
                {
                    item.SubItems = new List<Node>();
                    root.SubItems.Add(item);
                    BuildTree(item, item.ID);
                }
            }
        }
    }
}
