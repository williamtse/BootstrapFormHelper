using BootstrapHtmlHelper.Util.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapHtmlHelper.FormHelper.Fields
{
    class TreeSelect : Field
    {
        public List<Node> _tree = new List<Node>();
        private string html = "";
        public TreeSelect(string field, string label, List<Node> nodes)
        {
            _field = field;
            _label = label;
            Builder builder = new Builder(nodes);
            _tree = builder.getTree();
        }
        public override string Content()
        {
            string val = "";
            if (_value != null)
            {
                val = "value=\"" + _value + "\"";
            }
            html = "<div class='form-group'>"
                + "<label for=\"" + _field + "\" class=\"col-sm-2 control-label\">" + _label + "</label>"
                + "<div class='col-sm-8'>"
                    + "<select name='" + _field + "' class=\"form-control " + _field + "\">";
                html += "<option value='0'>ROOT</option>";
                        renderTree(_tree);
            html += "</select >"
                    + "<span validation-for=\"" + _field + "\" class=\"text-danger\"></span>"
                + "</div>"
            + "</div>";
            return html;
        }

        public void renderTree(List<Node> items, int Level=0)
        {
            int level = Level + 1;
            foreach (Node option in items)
            {
                option.Level = level;
                string spaces = "";
                for (int i = 0; i < 1 << level; i++)
                {
                    spaces += "&nbsp;";
                }
                html += "<option value='" + option.ID + "' " + ( _value != null && _value ==option.ID.ToString() ? "selected":"" ) + ">" 
                    + spaces + "┝" + option.Title + "</option>";
                if (option.SubItems!=null && option.SubItems.Count > 0)
                {
                    renderTree(option.SubItems, level);
                }
            }
        }

    }
}
