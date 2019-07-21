using BootstrapHtmlHelper.FormHelper.Fields;
using BootstrapHtmlHelper.Util.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BootstrapHtmlHelper.FormHelper
{
    public class Form
    {
        public List<Object> Elements = new List<Object>();
        private Object _model;
        private bool _isEdit=false;
        public string scripts = "";
        private string _action = "?";
        private string _method = "POST";
        private bool _upload = false;
        public Form Model(Object model, string ID)
        {
            _model = model;
            int id = int.Parse(getModelFieldValue(ID));
            if (id > 0)
            {
                _isEdit = true;
                _action = '/' + GetControllerName(model) + "/Edit/" + id.ToString();
                _method = "PUT";
            }
            else
            {
                _action = '/' + GetControllerName(model) + "/Create";
                _method = "POST";
            }
            return this;
        }

        private int GetID(Object model, Expression<Func<Object, int>> TID)
        {
            var func = TID.Compile();
            return func(model);
        }

        private string GetControllerName(Object model)
        {
            string fullName = model.GetType().ToString();
            string[] arr = fullName.Split('.');
            return  arr.Last()+ "s";
        }

        public Form AddField(Field field)
        {
            Elements.Add(field);
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
            else
            {
                string method = "Get" + field;
                var m = t.GetMethod(method);
                if (m != null)
                {
                    var vv = m.Invoke(_model, null);
                    return Convert.ToString(vv);
                }
            }
            return null;
        }

        public string GetContent()
        {
            string elements = "";
            foreach(Field item in Elements)
            {
                if (_isEdit)
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
