using BootstrapHtmlHelper.Util.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapHtmlHelper.UI
{
    public delegate string TreeNodeHandler(Node node);
    public class Nestable : UIBase
    {
        private List<Node> _nodes;
        private string html="";
        private string _id = "";
        private TreeNodeHandler _handle;
        public Nestable(List<Node> nodes, string id, TreeNodeHandler nodeHandler=null)
        {
            _nodes = Builder.getTree(nodes);
            _id = id;
            _handle = nodeHandler;
        }
        public override string GetContent()
        {
            html = "<div class='dd' id='" + _id + "'><ol class='dd-list'>";
            BuildTree(_nodes);
            html += "</ol></div>";
            return html;
        }

        private void BuildTree(List<Node> nodes)
        {
            foreach (Node node in nodes)
            {
                html += "<li class=\"dd-item\" data-id=\"" + node.ID + "\">"
                          + "<div class=\"dd-handle\">";
                if (_handle!=null)
                {
                    html += _handle(node);
                }
                else
                {
                    html += node.Title;
                }
                html += "</div>";
                       
                if (node.SubItems != null && node.SubItems.Count > 0)
                {
                    html += "<ol class=\"dd-list\">";
                    BuildTree(node.SubItems);
                    html += "</ol>";
                }
                else
                {
                    html += "</li>";
                }
            }
        }
    }
}
