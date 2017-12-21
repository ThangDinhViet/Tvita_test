$(document).ready(function () {
    $('.dataTables').DataTable({
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
    $('#inputFile').filestyle({
        btnClass: 'btn-primary',
        'placeholder': 'Chọn tải lên file excel'
    })

    $("#saveNewEmployee").on("click", function () {
        var AddEmployeeModel = {
            Employee_Code: $('#employeeCode').val(),
            Employee_Name: $('#employeeName').val(),
            Employee_Phone: $('#employeePhone').val(),
            Employee_Address: $('#employeeAddress').val(),
            CreatedDate: $('#employeeDateCreated').val(),
        };
        $.ajax({
            url: window.location.href + '/Create',
            type: 'POST',
            contentType: 'application/json',
            dataType: 'jsonp',
            data: JSON.stringify(AddEmployeeModel),
            success: function (result) {
                if (result == true) {
                    window.location.href
                } else {
                    $QuickLoginErrors.text(result);
                }
            }
        });
    });
    // Setup - add a text input to each footer cell
    $('#tbl_source tfoot th').each(function () {
        var title = $(this).text();
        if ($(this)["0"].cellIndex == 2 || $(this)["0"].cellIndex == 3 || $(this)["0"].cellIndex == 4 || $(this)["0"].cellIndex == 5)
            $(this).html('<input class="form-control input-sm searchKey" type="text" placeholder="Tìm kiếm ' + title + '" />');
    });

    // DataTable
    var table = $('#tbl_source').DataTable();

    // Apply the search
    table.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });

});

function validate_fileupload(fileName) {
    var allowed_extensions = new Array("xlsx", "xls");
    var file_extension = fileName.split('.').pop().toLowerCase();

    for (var i = 0; i <= allowed_extensions.length; i++) {
        if (allowed_extensions[i] == file_extension) {
            return true;
        }
    }
    alert("File không hợp lệ. Chỉ được import file excel")
    return false;
}

