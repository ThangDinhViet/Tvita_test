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
            getRelatedProducts(data.data.ID_GroupProduct, data.data.Product_ID);
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}

function getRelatedProducts(_idGrp, _idPr) {
    var dataSend = { idGroup: parseInt(_idGrp), idPr: parseInt(_idPr) }
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
    if ($('.lan.active').text() == "VI")
    {
        $('.js-product-name').text(data.Product_Name);
        $('.js-product-description').text(data.Product_Description);
        $('.js-product-original').text(data.Product_Original);
        $('.js-product-pakageStandard').text(data.Product_PakageStandard);
        $('.js-product-guide').text(data.Product_Guide);
        $('.js-product-preserve').text(data.Product_Preserve);
    }
    else
    {
        $('.js-product-name').text(data.Product_Name_EN);
        $('.js-product-description').text(data.Product_Description_EN);
        $('.js-product-original').text(data.Product_Original_EN);
        $('.js-product-pakageStandard').text(data.Product_PakageStandard_EN);
        $('.js-product-guide').text(data.Product_Guide_EN);
        $('.js-product-preserve').text(data.Product_Preserve_EN);
    }
    $('.js-product-bannerPicture').css("background-image", "url('/Content/pictures/" + data.Product_Pic_URL + "')");
    $.each(data.Product_Pic_List, function (k, v) {
        var template = '<div class="col-sm-4 col-md-4 col-lg-4">' + 
                                    '<a href="#">' + 
                                        '<div class="g-item">' +
                                            '<img src="../../Content/images/photos/transparent-388x388.png" style="background-image: Url(\'' + Config.AppUrl + '/Content/pictures/' + v + '\')">' +
                                        '</div>' + 
                                    '</a>' + 
                                '</div>';
        $('.gallery').append($(template));
    })
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
        if ($('.lan.active').text() == "VI")
        {
            var template = '<div class="product-item">' +
                            '<a href="' + Config.AppUrl + '/Product/Detail/' + v.Product_ID + '">' +
                                '<img src="' + Config.AppUrl + '/Content/images/photos/transparent-282-product.png")" style="background-image: Url(\'' + Config.AppUrl + '/Content/pictures/' + v.Product_Pic_URL + '\')"></a>' +
                                '<a href="' + Config.AppUrl + '/Product/Detail/' + v.Product_ID + '">' +
                                '<span class="product-item-caption">' + v.Product_Name + '</span></a>' +
                            '</div>';
            $('.responsive').append($(template));
        }
        else
        {
            var template = '<div class="product-item">' +
                            '<a href="' + Config.AppUrl + '/Product/Detail/' + v.Product_ID + '">' +
                                '<img src="' + Config.AppUrl + '/Content/images/photos/transparent-282-product.png")" style="background-image: Url(\'' + Config.AppUrl + '/Content/pictures/' + v.Product_Pic_URL + '\')"></a>' +
                                '<a href="' + Config.AppUrl + '/Product/Detail/' + v.Product_ID + '">' +
                                '<span class="product-item-caption">' + v.Product_Name_EN + '</span></a>' +
                            '</div>';
            $('.responsive').append($(template));
        }
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