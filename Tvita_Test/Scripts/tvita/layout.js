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
            if ($(toggler).isInViewport()) {
                $(toggler).fadeIn();
                $(toggler).removeClass('outView');
                $('body').removeClass('overView');
            } else {
                $(toggler).fadeIn();
                $(toggler).addClass('outView');
                $('body').addClass('overView');
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
        if ($(window).width() > 1279 && $('.navbar-toggle').is(':hidden')) {
            $(selected).removeClass('slide-active');
        } else {
            toggleSlideMenu();
        }
    });
});

$.fn.isInViewport = function() {
    var elementLeft = $(this).offset().left;
    var elementRight = elementLeft + $(this).outerWidth();

    var viewportLeft = $(window).scrollLeft();
    var viewportRight = viewportLeft + $(window).width();

    return elementRight > viewportLeft && elementLeft < viewportRight;
};