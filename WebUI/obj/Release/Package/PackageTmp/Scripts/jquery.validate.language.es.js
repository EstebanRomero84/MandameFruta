$(document).ready(function() {
    jQuery.extend(jQuery.validator.messages, {
        required: "Campo obligatorio.",
        remote: "Rellena este campo.",
        email: "Correo inválido",
        url: "Escriba una URL válida.",
        date: "Fecha inválida.",
        dateISO: "Escriba una fecha (ISO) válida.",
        number: "Número inválido.",
        digits: "Escriba sólo dígitos.",
        creditcard: "Escriba un número de tarjeta válido.",
        equalTo: "Escriba el mismo valor de nuevo.",
        accept: "Escriba un valor con una extensión aceptada.",
        maxlength: jQuery.validator.format("No escribas más de {0} caracteres."),
        minlength: jQuery.validator.format("No escribas menos de {0} caracteres."),
        rangelength: jQuery.validator.format("Escriba un valor entre {0} y {1} caracteres."),
        range: jQuery.validator.format("Escriba un valor entre {0} y {1}."),
        max: jQuery.validator.format("Escriba un valor menor o igual a {0}."),
        min: jQuery.validator.format("Escriba un valor mayor o igual a {0}.")
    });
});