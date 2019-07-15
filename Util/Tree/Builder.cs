using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapHtmlHelper.Util.Tree
{
    class Builder
    {
        private List<Item> _items;
        public Builder(List<Item> items)
        {
            _items = items;
        }

        public List<Node> getTree(int root=0)
        {
            List<Node> tree = new List<Node>();
            foreach(Item item in _items)
            {
                if (item.ParentID == root)
                {
                    Node node = new Node { ParentID=0, Title=item.Title, ID=item.ID, SubItems=new List<Node>() };
                    tree.Add(node);
                    getTree(item.ID);
                }
            }
            return tree;
        }
    }
}
