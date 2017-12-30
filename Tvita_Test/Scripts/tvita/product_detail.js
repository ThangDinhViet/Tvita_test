$(function () {




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
});

function getProductDetail(_id) {
    var dataSend = {id: parseInt(_id) }
    $.ajax({
        type: "GET",
        dataType: 'json',
        url: Config.AppUrl + "/Product/GetProductDetail/",
        contentType: 'application/json',
        data: dataSend,
        success: function (data) {
            fillDetail(data.data)
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}

function fillDetail(data) {
    $('.js-product-name').text(data.Product_Name);
    $('.js-price').text(data.Product_Price || '---')
}