$(document).ready(function () {
    $('.dataTables').DataTable({
        responsive: true
    });
    //var date_input = $('.date');
    //var container = $('.bootstrap-iso form').length > 0 ? $('.bootstrap-iso form').parent() : "body";
    //date_input.datepicker({
    //    format: 'mm/dd/yyyy',
    //    container: container,
    //    todayHighlight: true,
    //    autoclose: true,
    //})
    

    $("#saveNewProduct").on("click", function () {
        //var AddEmployeeModel = {
        //    Employee_Code: $('#employeeCode').val(),
        //    Employee_Name: $('#employeeName').val(),
        //    Employee_Phone: $('#employeePhone').val(),
        //    Employee_Address: $('#employeeAddress').val(),
        //    CreatedDate: $('#employeeDateCreated').val(),
        //};
        //$.ajax({
        //    url: window.location.href + '/Create',
        //    type: 'POST',
        //    contentType: 'application/json',
        //    dataType: 'jsonp',
        //    data: JSON.stringify(AddEmployeeModel),
        //    success: function (result) {
        //        if (result == true) {
        //            window.location.href
        //        } else {
        //            $QuickLoginErrors.text(result);
        //        }
        //    }
        //});
    });
});

function validate_fileuploadpicture(fileName) {
    var allowed_extensions = new Array("jpg", "jpeg", "png");
    var file_extension = fileName.split('.').pop().toLowerCase();

    for (var i = 0; i <= allowed_extensions.length; i++) {
        if (allowed_extensions[i] == file_extension) {
            return true;
        }
    }
    alert("File không hợp lệ. Chỉ được import file ảnh")
    return false;
}

