using BootstrapHtmlHelper.FormHelper.Fields;
using BootstrapHtmlHelper.Util.Tree;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BootstrapHtmlHelper.FormHelper
{
    public class Form<T>
    {
        public List<Object> Elements = new List<Object>();
        private T _model;
        public string scripts = "";
        private string _action = "?";
        private string _method = "POST";
        private bool _upload = false;

        public Form<T> Action(string action)
        {
            _action = action;
            return this;
        }

        public Form<T> Method(string method = "POST")
        {
            _method = method;
            return this;
        }
        public Form<T> Edit(T model)
        {
            _model = model;
            return this;
        }

        public Form<T> Text(string field, string label)
        {
            Text text = new Text(field, label);
            Elements.Add(text);
            return this;
        }

        public Form<T> Select(string field, string label, List<Option> options)
        {
            Elements.Add(new Select(field, label, options));
            return this;
        }

        public Form<T> MultipleSelect(string field, string label, List<Option> options)
        {
            Elements.Add(new MultipleSelect(field, label, options));
            return this;
        }

        public Form<T> TreeSelect(string field, string label, List<Node> tree)
        {
            Elements.Add(new TreeSelect(field, label, tree));
            return this;
        }

        public Form<T> Textarea(string field, string label)
        {
            Elements.Add(new Textarea(field, label));
            return this;
        }

        private string getModelFieldValue(string field)
        {
            var t = _model.GetType();
            var p = t.GetProperty(field);
            if(p != null)
            {
                var vv = p.GetValue(_model, null);
                return Convert.ToString(vv);
            }
            return null;
        }

        public string GetContent()
        {
            string elements = "";
            foreach(Field item in Elements)
            {
                if (_model != null)
                {
                    string field = item.GetField();
                    item.setValue(getModelFieldValue(field));
                }
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
            string ct = "<form action='" + _action + "' pjax-container='1' method='" + _method + "' " + enctype + " >"
                                + "<div  validation-summary ='ModelOnly' class='text-danger'></div>";
            string hiddenID = "";
            if (_model != null)
            {
                string ID = getModelFieldValue("ID");
                hiddenID = "<input type='hidden' name='ID' value='" + ID + "'>";
            }
            ct += hiddenID;
            ct += elements;
            ct += "<input type='hidden' name='__RequestVerificationToken' value=''>";
            ct += "<button type=\"submit\" class=\"btn btn-primary\">提交</button>";
            ct += "</form>";

            scripts += ";$('[name=__RequestVerificationToken]').val(LA);";
            return ct;
        }

        public string GetScript()
        {
            return scripts;
        }
    }
}
