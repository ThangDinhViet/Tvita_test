$(function () {
    var iframe = $('#iframe');
    var idPost = $('#post_id').val();
    iframe.attr('src', Config.AppUrl + '/Technology/getContent/' + idPost);
    iframe[0].addEventListener('load', handleLoad, true);

    function handleLoad() {
        var height = iframe[0].contentWindow.document.body.scrollHeight;
        iframe[0].height = height + "px";
        checkChatInView()
    }
});