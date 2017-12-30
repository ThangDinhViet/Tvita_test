Config = {
    AppUrl: '/Tvita_Test'
}

$(document).ready(function () {

    $('#slide-nav').after($('<div class="inverse" id="navbar-height-col"></div>'));

    // Enter your ids or classes
    var toggler = '.navbar-toggle';
    var pagewrapper = '#page-content';
    var navigationwrapper = '.navbar-header';
    var menuwidth = '400px'; // the menu inside the slide menu itself
    var slidewidth = '400px';
    var menuneg = '-400px';
    var slideneg = '-400px';


    $("#slide-nav").on("click", toggler, function (e) {
        toggleSlideMenu();
    });

    function toggleSlideMenu() {
        var selected = $(toggler).hasClass('slide-active');
        $('#slidemenu').stop().animate({
            left: selected ? menuneg : '0px'
        }, function () {
            if ($(toggler).isInViewport('vertical')) {
                $(toggler).fadeIn();
                $(toggler).removeClass('outView');
                $('body').removeClass('overView');
            } else {
                $(toggler).fadeIn();
                $(toggler).addClass('outView');
                $('body').addClass('overView');
            }
            if (selected) {
                $(toggler).find('i').removeClass('fa-chevron-left').addClass('fa-chevron-right')
            } else {
                $(toggler).find('i').removeClass('fa-chevron-right').addClass('fa-chevron-left')
            }
        });

        $('#navbar-height-col').stop().animate({
            left: selected ? slideneg : '0px'
        });

        $(pagewrapper).stop().animate({
            left: selected ? '0px' : slidewidth
        });

        $(navigationwrapper).stop().animate({
            left: selected ? '0px' : slidewidth
        });


        $(toggler).toggleClass('slide-active', !selected);
        $('#slidemenu').toggleClass('slide-active', !selected);


        $('#page-content, .navbar, body, .navbar-header').toggleClass('slide-active', !selected);


    }

    var selected = '#slidemenu, #page-content, body, .navbar, .navbar-header, .navbar-toggle';

    $(window).on("resize", function () {
        // if ($(window).width() > 1279 && $('.navbar-toggle').is(':hidden')) {
        //     $(selected).removeClass('slide-active');
        // } else {
        //     toggleSlideMenu();
        // }
    });

    //for talk with me
    $('.twm-title').unbind().bind('click', function () {
        $('.talk-with-me').toggleClass('open');
        if ($('.talk-with-me').hasClass('open')) {
            if ($('.footer-bottom').isInViewport('horizontal')) {
                $('.talk-with-me').css({
                    position: 'fixed',
                    top: 'inherit'
                })
            }
        } else {
            checkChatInView();
        }
    })


    $(window).on('scroll resize', function () {
        checkChatInView();
    })

    function checkChatInView() {
        if ($('.footer-bottom').isInViewport('horizontal') && $('.talk-with-me').hasClass('open') == false) {
            $('.talk-with-me').css({
                position: 'absolute',
                top: $('.footer-bottom').offset().top - $('.twm-title').outerHeight()
            })
        } else {
            $('.talk-with-me').css({
                position: 'fixed',
                top: 'inherit'
            })
        }
    }

    checkChatInView();
    var nickName = 'No name';
    $('#myName').on('keyup', function (e) {
        if (e.keyCode == 13) {
            $('.handle-name').trigger('click');
        }
    })
    $('.handle-name').unbind().bind('click', function () {
        if ($.trim($('#myName').val()) != '') {
            nickName = $.trim($('#myName').val());
        }
        $('#message').val('').focus();
        $('.name-input').hide();
        $('.message-input').show();
        $('#message').val('').focus();
    })
    // Reference the auto-generated proxy for the hub.
    var chat = $.connection.chatHub;

    // Create a function that the hub can call back to display messages.
    chat.client.addNewMessageToPage = function (name, message, clientId) {
        // Add the message to the page.
        $('#discussion').append('<li class="' + (clientId == chat.connection.id ? 'me' : '') + '"><strong>' + htmlEncode(name)
            + '</strong class="nick-name">' + '<span class="m-content"><span>' + htmlEncode(message) + '<span></span></li>');

        var $target = $('.twm-content');
        $target.animate({ scrollTop: $('#discussion').height() }, 10);
    };

    // Start the connection.
    $.connection.hub.start().done(function () {
        $('.handle-send').click(function () {
            // Call the Send method on the hub.
            if ($.trim($('#message').val()) != '') {
                chat.server.send(nickName, $('#message').val(), chat.connection.id);
                $.ajax({
                    url: 'https://api.wit.ai/message',
                    data: {
                        'q': $('#message').val(),
                        'access_token': 'YVHFIVLW3E3UA3ZQAA3B7ECUCN7SIN6K'
                    },
                    dataType: 'jsonp',
                    method: 'GET',
                    success: function (response) {
                        if (Object.keys(response.entities).length > 0) {
                            $('#discussion').append('<li><strong>' + 'Tư vấn khách hàng TVITA'
            + '</strong class="nick-name">' + '<span class="m-content"><span>' + response.entities.intent[0].value + '<span></span></li>');
                        }
                        else {
                            $('#discussion').append('<li><strong>' + 'Tư vấn khách hàng TVITA'
           + '</strong class="nick-name">' + '<span class="m-content"><span>' + 'Thắc mắc của quí khách đã được gửi tới bộ phận chăm sóc khách hàng, xin vui lòng đợi phản hồi ...' + '<span></span></li>');
                        }
                        var $target = $('.twm-content');
                        $target.animate({ scrollTop: $('#discussion').height() }, 10);
                    }
                });
            }

            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();

        });
    });

    $('#message').on('keyup', function (e) {
        if (e.keyCode == 13) {
            $('.handle-send').trigger('click');
        }
    })

    $('.btn-control-language').unbind().bind('click', function () {
        var lang = $(this).attr('data-lang');
        changeLaguage(lang);
    })


    $('#hot-news-content').empty();
    $.ajax({
        type: "GET",
        dataType: 'json',
        url: Config.AppUrl + "/Home/getHotNews/",
        contentType: 'application/json',
        data: {},
        success: function (resp) {
            if (resp.data.length != 0) {
                $.each(resp.data, function (k, v) {
                    var a = $('<a href="' + Config.Url + '/' + v.Post_Url + '" >' + v.Post_Name + '</a>');
                    $('#hot-news-content').append(a)
                });
            } else {
                $('#hot-news-content').text('Chưa có tin')
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });


});


$.fn.isInViewport = function (_type) {
    var elementLeft = $(this).offset().left;
    var elementRight = elementLeft + $(this).outerWidth();

    var elementTop = $(this).offset().top;
    var elementBottom = elementTop + $(this).outerHeight();

    var viewportLeft = $(window).scrollLeft();
    var viewportRight = viewportLeft + $(window).width();

    var viewportTop = $(window).scrollTop();
    var viewportBottom = viewportTop + $(window).height();

    switch (_type) {
        case 'horizontal':
            return (elementBottom > viewportTop && elementTop < viewportBottom)
            break;
        case 'vertical':
            return (elementRight > viewportLeft && elementLeft < viewportRight)
            break;
        default:
            return (elementRight > viewportLeft && elementLeft < viewportRight && elementBottom > viewportTop && elementTop < viewportBottom)
            break;
    }
};

// This optional function html-encodes messages for display in the page.
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}

function changeLaguage(_lang) {
    $.ajax({
        type: "GET",
        dataType: 'json',
        traditional: true,
        url: Config.AppUrl + "/Home/ChangeLanguage/",
        contentType: 'application/json',
        data: { lang: _lang },
        success: function (data) {
            if (data.success) {
                window.location.reload();
            }
        }
    });
}