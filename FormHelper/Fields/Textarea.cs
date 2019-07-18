using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapHtmlHelper.FormHelper.Fields
{
    public class Textarea : Field
    {
        public Textarea(string field, string label)
        {
            _field = field;
            _label = label;
        }
        public override string Content()
        {
            string html = "<div class='form-group'>";
            html += "<label for= \""+_field+"\" class=\"col-sm-2  control-label\">"+_label+"</label>";
            html += "<div class=\"col-sm-8\">";
            html += "<textarea name = \"" + _field + "\" class=\"form-control http_path\" rows=\"5\" placeholder=\"" + _label + "\">";
            if (_value != null)
            {
                html += _value;
            }
            html += "</textarea>";
            html += "</div>";
            html += "</div>";
            return html;
        }
    }
}
