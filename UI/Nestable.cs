using BootstrapHtmlHelper.Util.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapHtmlHelper.UI
{
    public delegate string TreeNodeHandler(Node node);
    public class Nestable : UIBase
    {
        private List<Node> _nodes;
        private string html = "";
        private string _id = "";
        private TreeNodeHandler _handle;
        public Nestable(List<Node> nodes, string id, TreeNodeHandler nodeHandler = null)
        {
            Builder builder = new Builder(nodes);
            _nodes = builder.getTree();
            _id = id;
            _handle = nodeHandler;
        }
        public override string GetContent()
        {
            html = "<div class='dd' id='" + _id + "'><ol class='dd-list'>";
            BuildTree(_nodes);
            html += "</ol></div>";
            return html;
        }

        public override string GetScript()
        {
            string script = ";";
            script += "$('.tree_branch_delete').unbind('click').click(function () {"
                    + "    var id = $(this).data('id');"
                    + "    swal({"
                    + "        title: \"确认删除 ? \","
                    + "        type: \"warning\","
                    + "        showCancelButton: true,"
                    + "        confirmButtonColor: \"#DD6B55\","
                    + "        confirmButtonText: \"确认\","
                    + "        showLoaderOnConfirm: true,"
                    + "        cancelButtonText: \"取消\","
                    + "        preConfirm: function () {"
                    + "            return new Promise(function (resolve) {"
                    + "                $.ajax({"
                    + "                    method: 'post',"
                    + "                    url: '/admin/articles/' + id,"
                    + "                    data: {"
                    + "                        _method: 'delete',"
                    + "                        _token: LA.token,"
                    + "                    },"
                    + "                    success: function (data) {"
                    + "                        $.pjax.reload('#pjax-container');"
                    + "                        resolve(data);"
                    + "                    }"
                    + "                });"
                    + "            });"
                    + "        }"
                    + "    }).then(function (result) {"
                    + "        var data = result.value;"
                    + "        if (typeof data === 'object') {"
                    + "            if (data.status) {"
                    + "                swal(data.message, '', 'success');"
                    + "            } else {"
                    + "                swal(data.message, '', 'error');"
                    + "            }"
                    + "        }"
                    + "    });"
                    + "});";
            return script;
        }

        private void BuildTree(List<Node> nodes)
        {
            foreach (Node node in nodes)
            {
                html += "<li class=\"dd-item\" data-id=\"" + node.ID + "\">"
                          + "<div class=\"dd-handle\">";
                if (_handle!=null)
                {
                    html += _handle(node);
                }
                else
                {
                    html += node.Title;
                }
                html += "</div>";
                       
                if (node.SubItems != null && node.SubItems.Count > 0)
                {
                    html += "<ol class=\"dd-list\">";
                    BuildTree(node.SubItems);
                    html += "</ol>";
                }
                else
                {
                    html += "</li>";
                }
            }
        }
    }
}
