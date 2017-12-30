$(function () {
    var target = undefined;
    var canvas = $('#farm_map')[0];
    $(canvas).hide();
    var provine_position = {
        Quoc_Te: { x1: 183, y1: 911, x2: 328, y2: 1019 },
        Noi_Dia: { x1: 660, y1: 1037, x2: 805, y2: 1135 },
        Tvita: { x1: 373, y1: 1373, x2: 548, y2: 1487 }
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
        //console.log(x, y)
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
            var name = '';
            switch (target) {
                case 'Noi_Dia':
                    name = 'Nội Địa'
                    break;
                case 'Quoc_Te':
                    name = 'Quốc Tế'
                    break;
                case 'Tvita':
                    name = 'TVita'
                    break;
            }
            modal.find('.modal-title').text('Thông tin')
            content.append($('<h1></h1>').html(name));
            modal.modal('show');

        }
    }

    $(window).on('resize', function () {
        $('#farm_map').hide();
        $('.farm-map').show();
        draw();
    })
})