using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapHtmlHelper.Util.Tree
{
    class Builder
    {
        public static List<Node> getTree(List<Node> _items)
        {
            var dic = new Dictionary<int, Node>(_items.Count);
            foreach (var item in _items)
            {
                dic.Add(item.ID, item);
            }
            foreach (var item in dic.Values)
            {
                if (dic.ContainsKey(item.ParentID))
                {
                    if (dic[item.ParentID].SubItems == null)
                        dic[item.ParentID].SubItems = new List<Node>();
                    dic[item.ParentID].SubItems.Add(item);
                }
            }
            return dic.Values.Where(t => t.ParentID == 0).ToList();
        }
    }
}
