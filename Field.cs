using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapFormHelper
{
    public abstract class Field
    {
        protected string _field { get; set; }
        protected string _label { get; set; }
        protected string _value { get; set; }
        public abstract string Content();

        public string Script()
        {
            return "";
        }
    }
}
