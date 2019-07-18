using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapHtmlHelper.FormHelper.Fields
{
    public class Select :Field
    {
        public List<Option> _options = new List<Option>();
        public Select(string field, string label, List<Option> options)
        {
            _field = field;
            _label = label;
            _options = options;
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
                + "<select name='" + _field + "' class=\"form-control " + _field + "\" >"
                +"<option value></option>";
            foreach (Option option in _options)
            {
                html += "<option value = \"" + option.value + "\" > " + option.text + " </option >";
            }
            html += "</select >"
                    + "<input name= \"" + _field + "\" type = \"hidden\" class=\"form-control\" />"
                + "<span validation-for=\"" + _field + "\" class=\"text-danger\"></span>"
            + "</div>";
            return html;
        }
    }
}
