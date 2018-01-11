$(function () {
    $('.responsive').empty();

    var elementsMaxRow = $('.n-item [data-maxrow]');
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
});

function getProductDetail(_id) {
    var dataSend = { id: parseInt(_id) }
    $.ajax({
        type: "GET",
        dataType: 'json',
        url: Config.AppUrl + "/Product/GetProductDetail/",
        contentType: 'application/json',
        data: dataSend,
        success: function (data) {
            fillDetail(data.data);
            getRelatedProducts(data.data.ID_GroupProduct);
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}

function getRelatedProducts(_idGrp) {
    var dataSend = { idGroup: parseInt(_idGrp) }
    $.ajax({
        type: "GET",
        dataType: 'json',
        url: Config.AppUrl + "/Product/GetRelatedProducts/",
        contentType: 'application/json',
        data: dataSend,
        success: function (data) {
            fillRelated(data.data)
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}

function fillDetail(data) {
    $('.js-product-name').text(data.Product_Name);
    $('.js-price').text(data.Product_Price || '---');
}

function fillRelated(data) {
    $('.responsive').empty();
    if (data.length == 0) {
        $('.same-kind-product').hide();
        return;
    } else {
        $('.same-kind-product').show()
    }
    $.each(data, function (k, v) {
        var template = '<div class="product-item">' +
                            '<a href="' + Config.AppUrl + '/Product/Detail/' + v.Product_ID + '">' +
                                '<img src="' + Config.AppUrl + '/Content/images/photos/transparent-282-product.png")" style="background-image: url(' + Config.AppUrl + v.Product_Picture + ')"></a>' +
                                '<a href="' + Config.AppUrl + '/Product/Detail/' + v.Product_ID + '">' +
                                '<span class="product-item-caption">' + v.Product_Name + '</span></a>' +
                            '</div>';
        $('.responsive').append($(template));
    })

    $('.responsive').slick({
        dots: false,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        responsive: [{
            breakpoint: 1024,
            settings: {
                slidesToShow: 3,
                slidesToScroll: 3,
                infinite: true,
                dots: false
            }
        },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2,
                    dots: false
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    dots: false
                }
            }
        ]
    });
}