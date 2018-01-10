$(function () {
    $('.tab-control').on('click', 'a[data-toggle="tab"]', function (evt) {
        $(this).parents('.tab-control').find('li.active').removeClass('active');
    })

    $('#home-slideshow').slideShow({
        auto: true,
        interval: 5000,
        parent: '.slide-show-container',
        autoPlayVideo: false
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

    var elementsMaxRow = $('.farm-tech [data-maxrow]');
    if (elementsMaxRow.length != 0) {
        $.each(elementsMaxRow, function (k, el) {
            if ($(el).innerHeight() > 80) {
                $(el).addClass('c-collapse');
                var p = $('<p class="c-toggle"></p>');
                var span = $('<span>...</span>');
                var a = $('<a href="#" data-i18n="view_more"></a>');
                var parent = $(el).parent();
                a.unbind().bind('click', function (evt) {
                    evt.preventDefault();
                    $(el).toggleClass('c-collapse');
                    if ($(el).hasClass('c-collapse')) {
                        span.show();
                        a.text($.i18n('view_more'))
                    } else {
                        span.hide();
                        a.text($.i18n('view_less'))
                    }
                })
                p.append(span).append(a);
                parent.append(p);
            }
        })
    }

    var elementsMaxRow = $('.list-thumb [data-maxrow]');
    if (elementsMaxRow.length != 0) {
        $.each(elementsMaxRow, function (k, el) {
            if ($(el).innerHeight() > 80) {
                $(el).addClass('c-collapse');
                var div = $('<div class="c-toggle"></div>');
                var span = $('<span>...</span>');
                div.append(span);
                $(el).after(div);
            }
        })
    }

})

var productsHome = function (container, _type) {
    var self = this;

    self.displayedAllItem = false;

    var paramPage = {
        total: 0,
        recordsInPage: 3,
        recordsDisplayed: 0,
        idBranch : 1
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
                var indexCol = 0;
                var row;
                paramPage.total = data.pageInfo.total;
                paramPage.recordsDisplayed = data.pageInfo.recordsDisplayed;

                if (data.pageInfo.recordsDisplayed == data.pageInfo.total) {
                    $('.js-load-more').prop('disabled', true);
                    self.displayedAllItem = true;
                }

                $.each(data.data, function (k, v) {
                    if (indexCol % 3 == 0) {
                        row = $('<div></div>').addClass('row');
                        listContainer.append(row)
                    }
                    var item_container = $('<div class="col-sm-4 col-md-4 col-lg-4"></div>');
                    var link = $('<a href="' + Config.AppUrl + "/Product/Detail/" + v.Product_ID + '">' +
                                '<div class="product-item">' +
                                    '<div class="product-item-cover">' +
                                          '<img src="' + Config.AppUrl + '/Content/images/photos/transparent-282-product.png" style="background-image: url(\'' + Config.AppUrl + '/Content/pictures/' + v.Product_Pic_URL + '\')">' +
                                    '</div>' +
                                    '<div class="product-item-content">' +
                                        '<span>' + v.Product_Name + '</span>' +
                                    '</div>' +
                                '</div>' +
                            '</a>');
                    item_container.append(link);
                    row.append(item_container);
                    indexCol++;
                })
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });
    }
}