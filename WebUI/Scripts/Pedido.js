var Pedido = function () {
    var $pedido = $("#contenidoPedido");
    var mostrarPedidoAjax = function (idPedido) {
        var Id = idPedido;
        $.ajax({
            type: 'post',
            url: '/Pedido/Pedido',
            data: { IdPedido: Id },
            dataType: 'html',
            beforeSend: function () {
            },
            complete: function () {
            },
            success: function (respuesta) {
                $pedido.hide().html(respuesta).fadeIn();
            }
        });
    };
    var aceptarPedido = function (idPedido) {
        var Id = idPedido;
        $.ajax({
            type: 'post',
            url: '/Pedido/Aceptar',
            data: { IdPedido: Id },
            dataType: 'html',
            beforeSend: function () {
            },
            complete: function () {
            },
            success: function (respuesta) {
                $pedido.fadeOut();  
                mostrarPedidoAjax(Id);
                $('#pedido-' + Id).addClass('Aceptado');
                $('#pedido-' + Id).removeClass('Pendiente');
            }
        });
    };
    var rechazarPedido = function (idPedido) {
        var Id = idPedido;
        $.ajax({
            type: 'post',
            url: '/Pedido/Rechazar',
            data: { IdPedido: Id },
            dataType: 'html',
            beforeSend: function () {
            },
            complete: function () {
            },
            success: function (response) {
                $pedido.fadeOut();
                mostrarPedidoAjax(Id);
                $('#pedido-' + Id).addClass('Rechazado');
                $('#pedido-' + Id).removeClass('Pendiente');
            }
        });
    };
    var eliminarPedido = function (idPedido, bandejaAEliminar) {
        var Id = idPedido;
        var visible = bandejaAEliminar;
        $.ajax({
            type: 'post',
            url: '/Pedido/Eliminar',
            data: { IdPedido: Id, Visible: visible },
            dataType: 'html',
            beforeSend: function () {
            },
            complete: function () {
            },
            success: function () {
                $('#pedido-' + Id).slideUp();
                $pedido.slideUp();
            }
        });
        if (!e) var e = window.event;
        e.cancelBubble = true;
        if (e.stopPropagation) e.stopPropagation();
    };

    var quitarClaseNoVisto = function () {
        $('#miPedido li').click(function (e) {
            e.preventDefault();
            if ($(this).hasClass('novisto')) {
                $(this).removeClass('novisto');
            }
        });
    };
    var mostrarPedidos = function () {
        $("#dropdown-menu-seleccionado").text("Todos");
        $("#miPedido li").slideDown();
    }
    var filtrarPedidos = function (filtro) {
        $("#dropdown-menu-seleccionado").text("" + filtro +"s");
        $('#miPedido .' + filtro + '').slideDown();
        $('#miPedido li').not('.' + filtro + '').slideUp();
    };

    return {
        init: function () {
            quitarClaseNoVisto();
        },
        mostrarPedidoAjax: function (idPedido) {
            mostrarPedidoAjax(idPedido);
        },
        aceptarPedido: function (idPedido) {
            aceptarPedido(idPedido);
        },
        rechazarPedido: function (idPedido) {
            rechazarPedido(idPedido);
        },
        eliminarPedido: function (idPedido, bandejaAEliminar) {
            eliminarPedido(idPedido, bandejaAEliminar);
        },
        mostrarPedidos: function () {
            mostrarPedidos();
        },
        filtrarPedidos: function (filtro) {
            filtrarPedidos(filtro);
        }
    };
}();