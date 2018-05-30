$(function () {
    $.ajax({
        type: "GET",
        dataType: 'json',
        url: Config.AppUrl + "/GotoKitchen/GetRelatedKitchen/",
        contentType: 'application/json',
        data: { id: $('#idKitchen').val() },
        success: function (resp) {
            if (resp.data.length != 0) {
                $.each(resp.data, function (k, v) {
                    if ($('.lan.active').text() == "VI")
                    {
                        var div = $('<div class="col-sm-4 col-md-4 col-lg-4"><div class="n-item"><div class="n-cover"><img src="../../Content/images/photos/transparent-388x388.png" style="background-image: Url(\'' + Config.AppUrl + '/Content/pictures/' + v.Post_Pic_URL + '\')">' + '</div><div class="n-content">' + v.Post_Name + '</div><div class="n-detail-content" data-maxrow="5">' + v.Post_Description + '</div><div class="n-view-more"><a href="' + Config.AppUrl + "/GotoKitchen/Details/" + v.Post_ID + '">' + $.i18n("view_more") + '</a></div></div></div>');
                        $('#relatedKitchen').append(div)
                    }
                    else
                    {
                        var div = $('<div class="col-sm-4 col-md-4 col-lg-4"><div class="n-item"><div class="n-cover"><img src="../../Content/images/photos/transparent-388x388.png" style="background-image: Url(\'' + Config.AppUrl + '/Content/pictures/' + v.Post_Pic_URL + '\')">' + '</div><div class="n-content">' + v.Post_Name_EN + '</div><div class="n-detail-content" data-maxrow="5">' + v.Post_Description_EN + '</div><div class="n-view-more"><a href="' + Config.AppUrl + "/GotoKitchen/Details/" + v.Post_ID + '">' + $.i18n("view_more") + '</a></div></div></div>');
                        $('#relatedKitchen').append(div)
                    }
                });
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
})