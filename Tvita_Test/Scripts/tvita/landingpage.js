$(document).ready(function () {

    $('.nav-link').bind('click', function (e) {
        e.preventDefault(); // prevent hard jump, the default behavior

        var target = $(this).attr("href"); // Set the target as variable

        // perform animated scrolling by getting top-position of target-element and set it as scroll target
        $('html, body').stop().animate({
            scrollTop: $(target).offset().top
        }, 600, function () {
            location.hash = target; //attach the hash (#jumptarget) to the pageurl
        });

        return false;
    });

    $(function () {
        var mainmenu = $("#main-nav").offset().top;
        $(window).scroll(function () {
            if ($(window).scrollTop() > mainmenu) {
                $("#main-nav").addClass('fixed-top');
            }
            else {
                $("#main-nav").removeClass('fixed-top');
            }
        });
    })
    
    $('#btn1').click(function () {
        var ischeck1 = $('#check1').is(":checked")
        var ischeck2 = $('#check2').is(":checked")
        var ischeck3 = $('#check3').is(":checked")
        var count = 0;
        $(".validateInput").each(function () {
            if ($(this).val() == "" || $(this).val() == null || $(this).val() == undefined) {
                $(this).addClass('error');
                count = 1;
            }
            else
                $(this).removeClass('error');
        });
        if (count != 0 || $("#num1").val() < 0 || $("#num2").val() < 0 || $("#num3").val() < 0)
        {
            $('#status').text('Xin hãy điền đầy đủ các trường thông tin để chúng tôi liên lạc với bạn !!!')
            $('#remoteModalDialog').modal('show');
        }
        else
        {
            $.ajax({
                url: 'LandingPage/AddOrder',  //(rec)= Controller's-name 
                //(recieveData) = Action's method name
                type: 'POST',
                data: {
                    //Get the input from Document Object Model
                    //by their ID
                    name: $("#name").val(),
                    phone: $("#phone").val(),
                    address: $("#address").val(),
                    email: $("#email").val(),
                    datedeli: $("#datedeli").val(),
                    note: $("#note").val(),
                    check1: ischeck1,
                    check2: ischeck2,
                    check3: ischeck3,
                    num1: $("#num1").val(),
                    num2: $("#num2").val(),
                    num3: $("#num3").val(),
                    price: $('#priceInput').val(),
                },
                success: function (status) {
                    if (status.status == 1)
                        $('#status').text('Bạn đã đặt hàng thành công. Chúng tôi sẽ liên hệ với bạn trong thời gian ngắn nhất. Xin cảm ơn')
                    else
                        $('#status').text('Đơn đặt hàng thất bại. Vui lòng thử lại sau !!!')
                    $('#remoteModalDialog').modal('show');
                }
            });
        }
        
    });

    $('#totalprice').click(function () {
        var totalprice = 0;
        var ischeck1 = $('#check1').is(":checked")
        var ischeck2 = $('#check2').is(":checked")
        var ischeck3 = $('#check3').is(":checked")
        if (ischeck1 == true)
            totalprice = totalprice + 299000 * $('#num1').val();
        if (ischeck2 == true)
            totalprice = totalprice + 250000 * $('#num2').val();
        if (ischeck3 == true)
            totalprice = totalprice + 229000 * $('#num3').val();
        $('#price').text(totalprice.toLocaleString('vi', {style : 'currency', currency : 'VND'}));
        $('#priceInput').val(totalprice)
        console.log(totalprice);
    });

    var date = new Date();
    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();
    if (month < 10) month = "0" + month;
    if (day < 10) day = "0" + day;
    var today = year + "-" + month + "-" + day;
    $("#datedeli").attr("value", today)
    $("#datedeli").on("change", function () {
        this.setAttribute(
            "data-date",
            moment(this.value, "YYYY-MM-DD")
            .format(this.getAttribute("data-date-format"))
        )
    }).trigger("change")
   
});



$(window).scroll(function () {
    var scrollDistance = $(window).scrollTop();

    // Show/hide menu on scroll
    //if (scrollDistance >= 850) {
    //		$('nav').fadeIn("fast");
    //} else {
    //		$('nav').fadeOut("fast");
    //}

    // Assign active class to nav links while scolling
    $('.page-section').each(function (i) {
        if ($(this).position().top <= scrollDistance) {
            $('.navigation a.active').removeClass('active');
            $('.navigation a').eq(i).addClass('active');
        }
    });
}).scroll();
