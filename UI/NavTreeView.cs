using BootstrapHtmlHelper.Util.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapHtmlHelper.UI
{
    public abstract class NavTreeView : UIBase
    {
        protected List<Node> _nodes;
        protected string html = "";
        protected string _id = "";
        public NavTreeView() { }
        public NavTreeView(List<Node> nodes, string id)
        {
            Builder builder = new Builder(nodes);
            _nodes = builder.getTree();
            _id = id;
        }
        public override string GetContent()
        {
            BuildTree(_nodes);
            return html;
        }

        private void BuildTree(List<Node> nodes)
        {
            foreach (Node node in nodes)
            {
                bool hasSubItems = node.SubItems != null && node.SubItems.Count > 0;
                html += @"<li class='nav-item " + (hasSubItems ? "has-treeview" : "") + @"'>";

                html += _handle(node);

                if (hasSubItems)
                {
                    html += "<ul class='nav nav-treeview'>";
                    BuildTree(node.SubItems);
                    html += "</ul>";
                }
                html += "</li>";
            }
        }

        protected abstract string _handle(Node node);
    }
}
