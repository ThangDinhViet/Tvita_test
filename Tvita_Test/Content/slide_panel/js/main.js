jQuery(document).ready(function($){
	//open the lateral panel
	$('.cd-btn').on('click', function(event){
		event.preventDefault();
		$('.cd-panel').toggleClass('is-visible');
		if ($('.cd-panel').hasClass('is-visible')) {
		    $('.cd-btn').addClass('is-visible');
		} else {
		    $('.cd-btn').removeClass('is-visible')
		}
		$('body').toggleClass('slide-active', $('.cd-panel').hasClass('is-visible'))
	});
	//clode the lateral panel
	$('.cd-panel').on('click', function(event){
		if( $(event.target).is('.cd-panel') || $(event.target).is('.cd-panel-close') ) { 
		    $('.cd-panel').removeClass('is-visible');
		    $('.cd-btn').removeClass('is-visible');
		    $('body').toggleClass('slide-active', false)
			event.preventDefault();
		}
	});

	$(window).on('resize', function () {
	    if ($('.navbar-toggle').is(':hidden')) {
	        $('.cd-panel').removeClass('is-visible');
	        $('.cd-btn').removeClass('is-visible');
	        $('body').toggleClass('slide-active', false)
	    }
	})
});