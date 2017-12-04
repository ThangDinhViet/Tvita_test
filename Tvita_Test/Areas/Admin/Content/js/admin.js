$(document).ready(function () {
    $('#dataTables-example').DataTable({
        responsive: true
    });
    var date_input = $('.date');
    var container = $('.bootstrap-iso form').length > 0 ? $('.bootstrap-iso form').parent() : "body";
    date_input.datepicker({
        format: 'mm/dd/yyyy',
        container: container,
        todayHighlight: true,
        autoclose: true,
    })
    $(".btn-save").on("click", function () {
        var AddEmployeeModel = {
            Employee_Code: $('#employeeCode').val(),
            Employee_Name: $('#employeeName').val(),
            Employee_Phone: $('#employeePhone').val(),
            Employee_Address: $('#employeeAddress').val(),
            CreatedDate: $('#employeeDateCreated').val(),
        };
        $.ajax({
            url: 'http://192.168.1.31:8008/Admin/Employee/Create',
            type: 'POST',
            contentType: 'application/json',
            dataType: 'jsonp',
            data: JSON.stringify(AddEmployeeModel),
            success: function (result) {
                if (result == true) {
                    window.location = "/Dashboard";
                } else {
                    $QuickLoginErrors.text(result);
                }
            }
        });
    });
});