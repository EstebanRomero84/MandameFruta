var Login = function () {
    var $containerModalLogin = $("#myModal");
    var $containerResetear = $("#containerResetear");
    var $containerLogin = $("#containerLogin");
    var mostrarModalLogin = function (url) {
        $.ajax({
            url: url,
            type: 'GET',
            dataType: 'html',
            beforeSend: function () {
                App.blockUI();
            },
            complete: function () {
                App.unblockUI();
            },
            success: function (respuesta) {
                $containerModalLogin.html(respuesta);
                $containerModalLogin.modal();
            }
        });
    };
    var mostrarLogin = function () {
        $("#containerLogin").slideDown(); $("#containerResetear").slideUp();
    };
    var mostrarRestaurarCuenta = function () {
        $("#containerLogin").slideUp(); $("#containerResetear").slideDown();
    };
    var initResetearForm = function () {
        $("form", $containerResetear).submit(function (event) {
            if (!$(this).valid()) {
                return;
            }
            event.preventDefault();
            $.ajax({
                type: 'POST',
                url: $(this).attr('action'),
                data: $(this).serialize(),
                dataType: 'json',
                beforeSend: function () {
                    App.blockUI($containerResetear);
                },
                complete: function () {
                    App.unblockUI($containerResetear);
                },
                success: function (response) {
                    App.showMessage(response.Success, response.Message);
                    if (response.Success) {
                        mostrarLogin();
                    }
                }
            });
        });
    };
    var onSucces = function (result, status, xhr) {
        var ct = xhr.getResponseHeader("content-type") || "";
        if (ct.indexOf('json') > -1) {
            window.location.href = result.url;
        }
    };
    var focusOnModal = function () {
        $('.modal').on('shown.bs.modal', function () {
            $(this).find('[autofocus]').focus();
        });
    };

    //* END:CORE HANDLERS *//

    return {
        init: function () {
            initResetearForm();
            focusOnModal();
        },
        onSucces: function (result, status, xhr) {
            onSucces(result, status, xhr);
        },
        mostrarRestaurarCuenta: function () {
            mostrarRestaurarCuenta();
        },
        mostrarModalLogin: function (url) {
            mostrarModalLogin(url);
        },
        mostrarLogin: function () {
            mostrarLogin();
        }
    };
}();