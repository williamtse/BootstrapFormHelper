using BootstrapFormHelper.Fields;
using System;
using System.Collections.Generic;

namespace BootstrapFormHelper
{
    public class Form
    {
        public List<Object> Elements = new List<Object>();
        private Object _model;
        public string scripts="";
        private string _action = "";
        private string _method = "";

        public Form Action(string action)
        {
            _action = action;
            return this;
        }

        public Form Method(string method = "POST")
        {
            _method = method;
            return this;
        }
        public Form Edit(Object model)
        {
            _model = model;
            return this;
        }

        public Form Text(string field, string label)
        {
            Text text = new Text(field, label);
            Elements.Add(text);
            return this;
        }

        public Form MultipleSelect(string field, string label, List<Option> options)
        {
            Elements.Add(new MultipleSelect(field, label, options));
            return this;
        }

        public string GetContent()
        {
            string ct = "<form action=\"" + _action + "\" pjax-container>"
                            +"< div  validation-summary = \"ModelOnly\" class=\"text-danger\"></div>";
            foreach(Field item in Elements)
            {
                ct += item.Content();
                scripts += item.Script();
            }
            ct += "<button type=\"submit\" class=\"btn btn-primary\">提交</button>";
            ct += "</form>";
            return ct;
        }

        public string GetScript()
        {
            return scripts;
        }
    }
}
