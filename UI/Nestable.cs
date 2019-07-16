using BootstrapHtmlHelper.Util.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapHtmlHelper.UI
{
    public abstract class Nestable : UIBase
    {
        protected List<Node> _nodes;
        protected string html = "";
        protected string _id = "";
        protected string ModelName;
        public Nestable() { }
        public Nestable(List<Node> nodes, string id)
        {
            Builder builder = new Builder(nodes);
            _nodes = builder.getTree();
            _id = id;
        }
        public void setModelName(string modelName)
        {
            ModelName = modelName;
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

                html += _handle(node);

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

        protected abstract string _handle(Node node);
    }
}