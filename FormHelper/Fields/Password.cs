using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapHtmlHelper.FormHelper.Fields
{
    class Password:Field
    {
        public Password(string field, string label)
        {
            _field = field;
            _label = label;
        }

        public override string Content()
        {
            string val = "";
            if (_value != null)
            {
                val = "value=\"" + _value + "\"";
            }
            string html = "<div class='form-group'>"
                + "<label for=\"" + _field + "\" class=\"control-label\">" + _label + "</label>"
                + "<input type=\"password\" name=\"" + _field + "\" class=\"form-control\" "
                + val + "/>"
                + "<span validation-for=\"" + _field + "\" class=\"text-danger\"></span>"
            + "</div>";
            return html;
        }
    }
}
