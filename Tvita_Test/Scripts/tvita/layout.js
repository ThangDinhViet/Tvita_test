$(document).ready(function() {

    $('#slide-nav').after($('<div class="inverse" id="navbar-height-col"></div>'));

    // Enter your ids or classes
    var toggler = '.navbar-toggle';
    var pagewrapper = '#page-content';
    var navigationwrapper = '.navbar-header';
    var menuwidth = '400px'; // the menu inside the slide menu itself
    var slidewidth = '400px';
    var menuneg = '-400px';
    var slideneg = '-400px';


    $("#slide-nav").on("click", toggler, function(e) {
        toggleSlideMenu();
    });

    function toggleSlideMenu() {
        var selected = $(toggler).hasClass('slide-active');
        $('#slidemenu').stop().animate({
            left: selected ? menuneg : '0px'
        }, function() {
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

    $(window).on("resize", function() {
        // if ($(window).width() > 1279 && $('.navbar-toggle').is(':hidden')) {
        //     $(selected).removeClass('slide-active');
        // } else {
        //     toggleSlideMenu();
        // }
    });

    //for talk with me
    $('.twm-title').unbind().bind('click', function() {
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


    $(window).on('scroll resize', function() {
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

});


$.fn.isInViewport = function(_type) {
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