using BootstrapHtmlHelper.Util.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapHtmlHelper.UI
{
    class Nestable : UIBase
    {
        private List<Node> _nodes;
        public Nestable(List<Node> nodes)
        {
            _nodes = nodes;
        }
        public override string GetContent()
        {
            string html = "<div class='dd'><ol class='dd - list'>";
            html += BuildTree(html, _nodes);
            html += "</ol></div>";
            return html;
        }

        private string BuildTree(string html, List<Node> nodes)
        {
            foreach (Node node in _nodes)
            {
                html += "<li class=\"dd-item\" data-id=\"" + node.ID + "\">"
                          + "<div class=\"dd-handle\">" + node.Title + "</div>";
                       
                if (node.SubItems != null && node.SubItems.Count > 0)
                {
                    html += "<ol class=\"dd - list\">";
                    BuildTree(html, node.SubItems);
                    html += "</ol>";
                }
                else
                {
                    html += "</li>";
                }
            }
            return html;
        }
    }
}
