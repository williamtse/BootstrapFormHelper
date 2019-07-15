using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapHtmlHelper.FormHelper
{
    public abstract class Field
    {
        protected string _field { get; set; }
        protected string _label { get; set; }
        protected string _value { get; set; }
        public abstract string Content();
        public void setValue(string value)
        {
            _value = value;
        }
        public string GetField()
        {
            return _field;
        }
        public virtual string Script()
        {
            return "";
        }
    }
}
