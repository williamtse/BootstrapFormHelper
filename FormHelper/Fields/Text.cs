namespace BootstrapHtmlHelper.FormHelper.Fields
{
    public class Text:Field
    {
        private string _type="text";
        public Text(string field, string label, string type="text", bool required=false)
        {
            _field = field;
            _label = label;
            _type = type;
            _required = required;
        }

        public override string Content()
        {
            string val = "";
            if (_value!=null)
            {
                val = "value=\""+_value+"\"";
            }
            string html = "<div class='form-group'>"
                + "<label for=\""+_field+"\" class=\"control-label\">"+_label+"</label>"
                + "<input type='" + _type + "' name=\"" + _field + "\" class=\"form-control\" "
                + val +" " + (_required?"required":"") + "/>"
                + "<span validation-for=\"" + _field + "\" class=\"text-danger\"></span>"
            + "</div>";
            return html;
        }
    }
}
