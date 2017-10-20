
var Buscador = function () {
    var frutas = new Bloodhound({
        limit: 10,
        datumTokenizer: Bloodhound.tokenizers.whitespace,
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: "/Home/BuscarEnListado/?query=%QUERY",
        wildcard: "%QUERY"
    });
    var Buscador = function () {
        $('#buscar').typeahead(
            {
                highlight: true,
                hint: true,
                minLength: 2
            },
            {
                limit: 10,
                source: frutas.ttAdapter()
            });
    };
    var focus = function () {
        $('#buscar').focus();
    };

    return {
        init: function () {
            Buscador();
        },
        focus: function () {
            focus();
        }
    };
}();

jQuery(document).ready(function () {
    Buscador.init();
});