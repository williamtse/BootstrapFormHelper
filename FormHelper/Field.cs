using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapHtmlHelper.FormHelper
{
    public abstract class Field
    {
        protected bool _required;
        protected string _field;
        protected string _label;
        protected string _value;
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
