using System;
using System.Collections.Generic;
using System.Text;

namespace BootstrapHtmlHelper.FormHelper.Fields
{
    public class Image : Field
    {
        protected bool _multiple;
        public Image(string feild, string label, bool required=false, bool multiple=false)
        {
            _field = feild;
            _label = label;
            _required = required;
            _multiple = multiple;
        }
        public override string Content()
        {
            string html = @"<div class='form-group'>
                                <label for= '" + _field + @"' class='control-label'>" + _label + @"</label>
                                <input type = 'file' class='"+_field+"' name='" + (_multiple?_field +"[]":_field ) + @"' id='" + _field + @"' " +(_multiple? "multiple":"") + @">
                            </div>";
            return html;
        }

        public override string Script()
        {
            var script = ";";
            script += @"$('input." + _field + @"').fileinput({
'overwriteInitial':true,
'initialPreviewAsData':true,
'browseLabel':'\u6d4f\u89c8',
'cancelLabel':'\u53d6\u6d88',
'showRemove':false,
'showUpload':false,
'showCancel':false,
'dropZoneEnabled':false,
'deleteExtraData':{'avatar':'_file_del_','_file_del_':'','_token':LA,'_method':'PUT'},
'deleteUrl':'https:\/\/ demo.laravel - admin.org\/ auth\/ ',
'fileActionSettings':{'showRemove':false,'showDrag':false},
'msgPlaceholder':'\u9009\u62e9\u56fe\u7247',
'allowedFileTypes':['image']});";
            return script;
        }
    }
}
