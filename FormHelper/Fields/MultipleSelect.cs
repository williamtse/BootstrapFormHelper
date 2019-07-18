using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapHtmlHelper.FormHelper.Fields
{
    public class MultipleSelect : Field
    {
        public List<Option> _options = new List<Option>();
        public MultipleSelect(string field, string label, List<Option> options)
        {
            _field = field;
            _label = label;
            _options = options;
        }
        public override string Content()
        {
            string html = "<div class='form-group'>"
                + "<label for=\"" + _field + "\" class=\"control-label\">" + _label + "</label>"
                + "<select class=\"form-control " + _field + "\" multiple=\"multiple\">";
            foreach(Option option in _options)
            {
                html += "<option value = '"+ option.value +"' > "+ option.text +" </option >";
            }
            html += "</select >"
                    + "<input name= \"" + _field + "\" type = \"hidden\" class=\"form-control\" />"
                + "<span validation-for=\"" + _field + "\" class=\"text-danger\"></span>"
            + "</div>";
            return html;
        }

        public override string Script()
        {
            string script = ";";
            if (_value != null)
            {
                script += "$('." + _field + "').val('" + _value + "'.split(',')).trigger('change');";
            }
            script += "$(\"." + _field + "\").select2({ \"allowClear\": true, \"placeholder\": { \"id\": \"\", \"text\": \"" + _label + "\" } });";
            script += "$(\"." + _field + "\").change(function () {"
                        + "var methods = $(this).val();"
                        + "$('input[name=" + _field + "]').val(methods.join(','));"
                    + "})";
            return script;
        }
    }
}
