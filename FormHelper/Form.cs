using BootstrapHtmlHelper.FormHelper.Fields;
using System;
using System.Collections.Generic;

namespace BootstrapHtmlHelper.FormHelper
{
    public class Form
    {
        public List<Object> Elements = new List<Object>();
        private Object _model;
        public string scripts="";
        private string _action = "?";
        private string _method = "POST";
        private bool _upload = false;

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

        public Form Select(string field, string label, List<Option> options)
        {
            Elements.Add(new Select(field, label, options));
            return this;
        }

        public Form MultipleSelect(string field, string label, List<Option> options)
        {
            Elements.Add(new MultipleSelect(field, label, options));
            return this;
        }

        public Form Textarea(string field, string label)
        {
            Elements.Add(new Textarea(field, label));
            return this;
        }

        public string GetContent()
        {
            string elements = "";
            foreach(Field item in Elements)
            {
                elements += item.Content();
                scripts += item.Script();
                if(item is Image && _upload == false)
                {
                    _upload = true;
                }
            }

            string enctype = ""; 
            if (_upload)
            {
                enctype = "enctype='multipart/form-data'";
                
            }
            string ct = "<form action='" + _action + "' pjax-container method='" + _method + "' " + enctype + " >"
                                + "<div  validation-summary ='ModelOnly' class='text-danger'></div>";
            ct += elements;
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
