/*Author: nguyennngocson.it@gmail.com */
$.fn.slideShow = function(_options) {
    var options = {};
    if (_options) {
        $.extend(options, _options);
    }

    var handle_play_dimension = {},
        handle_previous_dimension = {},
        handle_next_dimension = {};

    var self = this;

    var container;

    var elements = self.find('.ss-item').hide();

    var count = elements.length;

    var player;

    var Interval, IntervalInit;

    var handleNext = $('<div class="ss-handle-next"></div>');
    var handlePrevious = $('<div class="ss-handle-previous"></div>');
    var handlePlay = $('<div class="ss-handle-play"></div>');

    var videoPlaying = false;

    var slideSelected = 0;


    function _calcDimention(callback) {
        container = self.find('.ss-container').length > 0 ? self.find('.ss-container') : self;
        container.height($(options.parent).height());
        self.find('.ss-caption-container').height($(options.parent).height());

        let hP = $('<div class="ss-handle-play"></div>').css({ display: 'none' });
        $('body').append(hP);

        handle_play_dimension = {
            width: hP.width(),
            height: hP.height()
        }
        hP.remove();

        let hPr = $('<div class="ss-handle-previous"></div>').css({ display: 'none' });
        $('body').append(hPr);

        handle_previous_dimension = {
            width: hPr.width(),
            height: hPr.height()
        }
        hPr.remove();

        let hN = $('<div class="ss-handle-next"></div>').css({ display: 'none' });
        $('body').append(hN);

        handle_next_dimension = {
            width: hN.width(),
            height: hN.height()
        }
        hN.remove();

        handlePrevious.css({
            top: (container.outerHeight() / 2) - (handle_previous_dimension.height / 2),
            left: 70
        });

        handleNext.css({
            top: (container.outerHeight() / 2) - (handle_next_dimension.height / 2),
            right: 70
        })

        handlePlay.css({
            top: (container.outerHeight() / 2) - (handle_play_dimension.height / 2),
            left: (container.outerWidth() / 2) - (handle_play_dimension.width / 2)
        })

        if (callback) callback();
    }

    _calcDimention();

    if (count > 0) {
        handlePlay.hide();

        handlePrevious.on('click', function() {
            handlePlay.fadeOut();
            $(elements[slideSelected]).fadeOut();
            slideSelected -= 1;
            if (slideSelected < 0) {
                slideSelected = elements.length - 1;
            }
            _handleGotoSlide(slideSelected)
        })

        handleNext.on('click', function() {
            _next();
        })

        var videoFrame = $('<div id="ss-video-placeholder"></div>');
        self.append(videoFrame);
        handlePlay.on('click', function() {
            clearInterval(Interval);
            var item = elements[slideSelected];
            var videoId = $(item).attr('data-url').split('/')[$(item).attr('data-url').split('/').length - 1];
            if (videoId.length == 0) return;
            $(this).fadeOut();
            $(item).fadeOut();
            if (!player) {
                player = new YT.Player('ss-video-placeholder', {
                    width: '100%',
                    height: '100%',
                    videoId: videoId,
                    playerVars: {
                        color: 'white'
                    },
                    events: {
                        onReady: initialize,
                        onStateChange: stateChange
                    }
                });
            } else {
                player.loadVideoById(videoId);
                $(player.a).fadeIn();
            }
        })
        container.append(handlePrevious).append(handleNext).append(handlePlay);

        _handleGotoSlide(0);

        if (options.autoPlayVideo && $(elements[0]).hasClass('ss-video')) {
            IntervalInit = setInterval(function () {
                try{
                    handlePlay.trigger('click');
                } catch (ex) {
                }
            }, 1000)
            
        }
        $.each(elements, function(k, item) {

        })

        clearInterval(Interval);
        if (options.auto == true) {
            Interval = setInterval(function() {
                _next();
            }, options.interval)
        }
    }

    function _next() {
        handlePlay.fadeOut();
        $(elements[slideSelected]).fadeOut();
        slideSelected += 1;
        if (slideSelected > elements.length - 1) {
            slideSelected = 0;
        }
        _handleGotoSlide(slideSelected)
    }

    function _handleGotoSlide(_index) {
        clearInterval(Interval);
        if (options.auto == true) {
            Interval = setInterval(function() {
                _next();
            }, options.interval)
        }
        if (player) {
            player.stopVideo();
            $(player.a).hide();
        }
        $(elements[_index]).find('img').hide();
        $(elements[_index]).fadeIn(function() {
            if ($(elements[_index]).find('img').height() < $(elements[_index]).height()) {
                $(elements[_index]).find('img').height($(elements[_index]).height())
            }
            $(elements[_index]).find('img').fadeIn();
            if ($(elements[_index]).hasClass('ss-video')) {
                handlePlay.fadeIn();
            }
        });
    }

    function initialize() {
        player.playVideo();
        if (options.autoPlayVideo) {
            clearInterval(IntervalInit);
        }
    }

    function stateChange(evt) {
        videoPlaying = evt.data == 1;
        if (!videoPlaying) {
            setTimeout(function() {
                handlePrevious.fadeIn();
                handleNext.fadeIn();
            }, 300);
        } else {
            setTimeout(function() {
                handlePrevious.fadeOut();
                handleNext.fadeOut();
            }, 1500);
        }
    }


    $(window).on('resize', function() {
        _calcDimention();
        setTimeout(function() {
            if ($(elements[slideSelected]).find('img').height() <= $(elements[slideSelected]).height()) {
                $(elements[slideSelected]).find('img').height($(elements[slideSelected]).height())
            } else {
                $(elements[slideSelected]).find('img').height('initial')
            }
        }, 0)
    })
}