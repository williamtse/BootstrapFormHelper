using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public static List<Node> ListToNodes<T>(List<T> list, 
                Expression<Func<T, int>> TID,
               Expression<Func<T, int>> TParentID,
               Expression<Func<T, string>> TTitle)
        {
            List<Node> nodes = new List<Node>();
            var func_TID = TID.Compile();
            var func_TParentID = TParentID.Compile();
            var func_TTitle = TTitle.Compile();
            foreach (T m in list)
            {
                Node node = new Node();
                node.ID = func_TID(m);
                node.ParentID = func_TParentID(m);
                node.Title = func_TTitle(m);
                nodes.Add(node);
            }
            return nodes;
        }
    }
}
