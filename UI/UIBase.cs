using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapHtmlHelper.UI
{
    public abstract class UIBase
    {
        public abstract string GetContent();
        public virtual string GetScript()
        {
            return "";
        }
    }
}
