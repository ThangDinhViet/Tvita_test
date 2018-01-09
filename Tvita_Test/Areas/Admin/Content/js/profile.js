$(document).ready(function () {
    $('#generate').on("click", function () {
        var GenerateProfileModel = {
            Product: $('#product').val(),
            DateCreated: $('#dateCreated').val(),
            DateEnd: $('#dateEnd').val(),
            Temple: $('#temple').val(),
            Barcode: $('#barcode').val(),
            Chanel: $('#chanel').val(),
            Factory: $('#factory').val(),
            ProductUnitCode: $('#productUnitCode').val(),
        };
        var LinkModel = {
            Link: "tvita.com.vn"
        }
        $.ajax({
            url: window.location.href + '/CreateQR',
            type: "POST",
            data: JSON.stringify({ 'link': 'tvita.com.vn' }),
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.status == "Success") {
                    alert("Done");
                } else {
                    alert("Error occurs on the Database level!");
                }
            },
            error: function () {
                alert("An error has occured!!!");
            }
        });
        $.ajax({
            url: window.location.href + '/Create',
            type: 'POST',
            contentType: 'application/json',
            dataType: 'jsonp',
            data: JSON.stringify(GenerateProfileModel),
            success: function (result) {
                if (result == true) {
                    window.location.href
                } else {
                    $QuickLoginErrors.text(result);
                }
            }
        });
    });
});