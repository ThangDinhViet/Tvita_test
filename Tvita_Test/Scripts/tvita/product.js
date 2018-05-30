var products = function (_type) {
    var self = this;

    var paramPage = {
        total: 0,
        recordsInPage: 6,
        recordsDisplayed: 0,
        idBranch: 1,
        idGroup: 0,
    }

    var listContainer = $('.list-product');

    self.init = function () {
        listContainer.empty();
        if ($('#idBranch').val() != null)
        {
            paramPage.idBranch = $('#idBranch').val()
            paramPage.idGroup = window.location.href.split('/')[5]
        } 
        self.getMore();

        $('.js-load-more').unbind().bind('click', function () {
            if ($('#idBranch').val() != null)
            {
                paramPage.idBranch = $('#idBranch').val()
                paramPage.idGroup = window.location.href.split('/')[5]
            }
                
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
                }

                $.each(data.data, function (k, v) {
                    if (indexCol % 3 == 0) {
                        row = $('<div></div>').addClass('row');
                        listContainer.append(row)
                    }
                    var item_container = $('<div class="col-sm-4 col-md-4 col-lg-4"></div>');
                    if ($('.lan.active').text() == "VI")
                    {
                        var link = $('<a href="' + Config.AppUrl + "/Product/Detail/" + v.Product_ID + '">' +
                                '<div class="product-item">' +
                                    '<div class="product-item-cover">' +
                                        '<img src="' + Config.AppUrl + '/Content/images/photos/transparent-282-product.png")" style="background-image: Url(\'' + Config.AppUrl + '/Content/pictures/' + v.Product_Pic_URL + '\')">' +
                                    '</div>' +
                                    '<div class="product-item-content">' +
                                        '<span>' + v.Product_Name + '</span>' +
                                    '</div>' +
                                '</div>' +
                            '</a>');
                        item_container.append(link);
                    }
                    else
                    {
                        {
                            var link = $('<a href="' + Config.AppUrl + "/Product/Detail/" + v.Product_ID + '">' +
                                    '<div class="product-item">' +
                                        '<div class="product-item-cover">' +
                                            '<img src="' + Config.AppUrl + '/Content/images/photos/transparent-282-product.png")" style="background-image: Url(\'' + Config.AppUrl + '/Content/pictures/' + v.Product_Pic_URL + '\')">' +
                                        '</div>' +
                                        '<div class="product-item-content">' +
                                            '<span>' + v.Product_Name_EN + '</span>' +
                                        '</div>' +
                                    '</div>' +
                                '</a>');
                            item_container.append(link);
                        }
                    }
                    row.append(item_container);
                    indexCol++;
                })
            },
            error: function (jqXHR, textStatus, errorThrown) {
               
            }
        });
    }
}

var productsControl = new products();
productsControl.init();