$(function() {
    $('.tab-control').on('click', 'a[data-toggle="tab"]', function(evt) {
        $(this).parents('.tab-control').find('li.active').removeClass('active');
    })
})