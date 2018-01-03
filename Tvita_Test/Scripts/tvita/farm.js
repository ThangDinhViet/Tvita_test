$(function () {
    var target = undefined;
    var canvas = $('#farm_map')[0];
    $(canvas).hide();
    var provine_position = {
        Hoa_Binh: { x1: 295, y1: 400, x2: 430, y2: 445 },
        Lao_Cai: { x1: 295, y1: 478, x2: 412, y2: 515 },
        Tay_Nguyen: { x1: 295, y1: 1034, x2: 460, y2: 1070 },
        DB_Song_Cuu_Long: { x1: 295, y1: 1167, x2: 445, y2: 1198 },
        Bac_Giang: { x1: 920, y1: 413, x2: 1062, y2: 429 },
        Hung_Yen: { x1: 920, y1: 551, x2: 1059, y2: 565 },
        DB_Song_Hong: { x1: 905, y1: 731, x2: 1059, y2: 760 }
    }
    var scale = 1;
    function draw() {
        $('#farm_map').show();

        var img_natural_width = $('.farm-map')[0].naturalWidth;
        var img_natural_height = $('.farm-map')[0].naturalHeight;

        var img_screen_size = {
            width: $('.farm-map').width(),
            height: $('.farm-map').height()
        }

        scale = img_natural_width / img_screen_size.width;

        canvas.onmousemove = _handleMousemove;
        canvas.onclick = _handleClick

        canvas.setAttribute('width', img_screen_size.width);
        canvas.setAttribute('height', img_screen_size.height);

        var ctx = canvas.getContext("2d");
        ctx.rect(0, 0, img_screen_size.width, img_screen_size.height);
        ctx.drawImage($('.farm-map')[0], 0, 0, img_screen_size.width, img_screen_size.height);
        $('.farm-map').hide();
        $(canvas).show();
    }

    setTimeout(function () {
        draw();
    }, 500)

    function _handleMousemove(evt) {
        var bb, x, y;
        bb = canvas.getBoundingClientRect();
        x = (event.clientX - bb.left) * (canvas.width / bb.width);
        y = (event.clientY - bb.top) * (canvas.height / bb.height);
        target = undefined;
        $(canvas).removeClass('on-focus');
        $.each(provine_position, function (k, v) {
            if (x >= v.x1 / scale && x <= v.x2 / scale && y >= v.y1 / scale && y <= v.y2 / scale) {
                target = k;
                $(canvas).addClass('on-focus');
            }
        });
    }

    function _handleClick(evt) {
        if (target) {
            var modal = $('#remoteModalDialog');
            var content = modal.find('.remote-modal-content').empty();
            var provine_name = '';
            switch (target) {
                case 'Hoa_Binh':
                    provine_name = 'Hòa Bình'
                    break;
                case 'Lao_Cai':
                    provine_name = 'Lào Cai'
                    break;
                case 'Tay_Nguyen':
                    provine_name = 'Tây Nguyên'
                    break;
                case 'DB_Song_Cuu_Long':
                    provine_name = 'Đồng bằng Sông Cửu Long'
                    break;
                case 'Bac_Giang':
                    provine_name = 'Bắc Giang'
                    break;
                case 'Hung_Yen':
                    provine_name = 'Hưng Yên'
                    break;
                case 'DB_Song_Hong':
                    provine_name = 'Đồng bằng Sông Hồng'
                    break;
            }
            modal.find('.modal-title').text('Thông tin')
            content.append($('<h1></h1>').html(provine_name));
            modal.modal('show');
            
        }
    }

    $(window).on('resize', function () {
        $('#farm_map').hide();
        $('.farm-map').show();
        draw();
    })
})