$(function () {
    $('.tab-control').on('click', 'a[data-toggle="tab"]', function (evt) {
        $(this).parents('.tab-control').find('li.active').removeClass('active');
    })

    $('#home-slideshow').slideShow({
        auto: true,
        interval: 10000,
        parent: '.slide-show-container',
        autoPlayVideo: true
    });


    var freshProduct = new productsHome('#fresh');

    freshProduct.init();

    var processedProduct = new productsHome('#processed');

    processedProduct.init();

    $('.js-load-more').unbind().bind('click', function () {
        freshProduct.getMore();
    })


    $('.tab-control a').on('shown.bs.tab', function (event) {
        var x = $(event.target).attr('href');
        if (x == '#fresh') {
            $('.js-load-more').prop('disabled', freshProduct.displayedAllItem);
            $('.js-load-more').unbind().bind('click', function () {
                freshProduct.getMore();
            })
        } else {
            $('.js-load-more').prop('disabled', processedProduct.displayedAllItem);
            $('.js-load-more').unbind().bind('click', function () {
                processedProduct.getMore();
            })
        }
    });

})

var productsHome = function (container, _type) {
    var self = this;

    self.displayedAllItem = false;

    var paramPage = {
        total: 0,
        recordsInPage: 6,
        recordsDisplayed: 0
    }

    var listContainer = $(container);

    self.init = function () {
        listContainer.empty();
        self.getMore();

        $('.js-load-more').unbind().bind('click', function () {
            self.getMore();
        })
    }

    self.getMore = function () {
        $.ajax({
            type: "GET",
            dataType: 'json',
            url: Config.AppUrl + "/Product/GetProduct/",
            contentType: 'application/json',
            data: paramPage,
            success: function (data) {
                paramPage.total = data.pageInfo.total;
                paramPage.recordsDisplayed = data.pageInfo.recordsDisplayed;

                if (data.pageInfo.recordsDisplayed == data.pageInfo.total) {
                    $('.js-load-more').prop('disabled', true);
                    self.displayedAllItem = true;
                }

                $.each(data.data, function (k, v) {
                    var link = $('<a href="' + Config.AppUrl + "/Product/Detail/" + v.Product_ID + '">' +
                                '<div class="col-sm-4 col-md-4 col-lg-4">' +
                                '<div class="s-item-container">' +
                                    '<div class="s-item" style="background-image:url(' + Config.AppUrl + v.Product_Picture + ')">' +
                                    '</div>' +
                                    '<div class="s-item-title">' +
                                        v.Product_Name +
                                    '</div>' +
                                '</div>' +
                            '</div>' +
                            '</a>');
                    listContainer.append(link)
                })
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });
    }
}