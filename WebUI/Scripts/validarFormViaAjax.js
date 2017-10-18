var validarFormViaAjax = function() {
    var $containerValidar = $(".contenido-target");

    var initValidarForm = function () {
        $("form", $containerValidar).submit(function (event) {
            event.preventDefault();

            if ($("form", $containerValidar).valid()) {
                $.ajax({
                type: 'POST',
                url: $(this).attr('action'),
                data: $(this).serialize(),
                dataType: 'json',
                beforeSend: function () {
                    //App.blockUI();
                },
                complete: function () {
                    //App.unblockUI();
                },
                success: function (response) {                    
                    if (response.Success) {
                        window.location.replace("/Dashboard");
                        App.showMessage(response.Success, response.Message);
                    }                    
                }
            });
            }
        });
    };

    //* END:CORE HANDLERS *//

    return {
        init: function () {
            initValidarForm();
        }
    };
}();