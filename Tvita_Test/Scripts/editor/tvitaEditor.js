if (CKEDITOR.env.ie && CKEDITOR.env.version < 9)
    CKEDITOR.tools.enableHtml5Elements(document);

// The trick to keep the editor in the sample quite small
// unless user specified own height.
CKEDITOR.config.height = '100vh';
CKEDITOR.config.width = 'auto';
CKEDITOR.config.language = 'vi';

var initEditor = (function () {
    var wysiwygareaAvailable = isWysiwygareaAvailable(),
        isBBCodeBuiltIn = !!CKEDITOR.plugins.get('bbcode');

    return function () {
        var editorElement = CKEDITOR.document.getById('editor');

        // :(((
        if (isBBCodeBuiltIn) {
            editorElement.setHtml('');
        }

        // Depending on the wysiwygare plugin availability initialize classic or inline editor.
        if (wysiwygareaAvailable) {
            CKEDITOR.replace('editor');
        } else {
            editorElement.setAttribute('contenteditable', 'true');
            CKEDITOR.inline('editor');

            // TODO we can consider displaying some info box that
            // without wysiwygarea the classic editor may not work.
        }
    };

    function isWysiwygareaAvailable() {
        // If in development mode, then the wysiwygarea must be available.
        // Split REV into two strings so builder does not replace it :D.
        if (CKEDITOR.revision == ('%RE' + 'V%')) {
            return true;
        }

        return !!CKEDITOR.plugins.get('wysiwygarea');
    }
})();

// %LEAVE_UNMINIFIED% %REMOVE_LINE%

$(function () {
    initEditor();

    $('#save').on('click', function () {
        var content = CKEDITOR.instances.editor.getData();
        var dataSend = JSON.stringify({ contentPost: content })
        $.ajax({
            type: "POST",
            dataType: 'json',
            url: Config.AppUrl + "/Editor/SavePost/",
            contentType: 'application/json',
            data: dataSend,
            success: function (data) {
                console.log('Done!')
            }
        })
    })

})