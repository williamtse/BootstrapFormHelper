using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BootstrapHtmlHelper.FormHelper
{
    public class Option
    {
        public string value { get; set; }
        public string text { get; set; }

        public static List<Option> GetOptions<T>(List<T> list, Expression<Func<T, string>> TKey, Expression<Func<T, string>> TValue)
        {
            List<Option> options = new List<Option>();
            var GetValue = TKey.Compile();
            var GetText = TValue.Compile();
            foreach (T obj in list)
            {
                options.Add(new Option
                {
                    value = GetValue(obj),
                    text = GetText(obj)
                });
            }
            return options;
        }
    }
}
