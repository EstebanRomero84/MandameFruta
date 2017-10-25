var Mapa = function () {
    var iconBase = '/img/iconos/';
    var iconos = {0: {icon: iconBase + 'anana.png'},1: {icon: iconBase + 'arandano.png'},2: {icon: iconBase + 'arandanorojo.png'        },        3: {            icon: iconBase + 'banana.png'},4: {icon: iconBase + 'cereza.png'},5: {icon: iconBase + 'ciruela.png'},6: {icon: iconBase + 'coco.png'        },        7: {            icon: iconBase + 'damasco.png'        },        8: {            icon: iconBase + 'durazno.png'        },        9: {            icon: iconBase + 'frambuesa.png'        },        10: {            icon: iconBase + 'frutilla.png'        },        11: {            icon: iconBase + 'granada.png'        },        12: {            icon: iconBase + 'grosella.png'        },        13: {            icon: iconBase + 'higo.png'        },        14: {            icon: iconBase + 'kiwi.png'        },        15: {            icon: iconBase + 'lima.png'        },        16: {            icon: iconBase + 'limon.png'        },        17: {            icon: iconBase + 'mandarina.png'        },        18: {            icon: iconBase + 'mango.png'        },        19: {            icon: iconBase + 'manzana.png'        },        20: {            icon: iconBase + 'maracuya.png'        },        21: {            icon: iconBase + 'melon.png'        },        22: {            icon: iconBase + 'membrillo.png'        },        23: {            icon: iconBase + 'mora.png'        },        24: {            icon: iconBase + 'naranja.png'        },        25: {            icon: iconBase + 'palta.png'        },        26: {            icon: iconBase + 'pera.png'        },        27: {            icon: iconBase + 'pomelo.png'        },        28: {            icon: iconBase + 'sandia.png'        },        29: {            icon: iconBase + 'uva.png'        }    };
    var arboles = ['Ananá', 'Arándano', 'Arándanorojo', 'Banana', 'Cereza', 'Ciruela', 'Coco', 'Damasco', 'Durazno', 'Frambuesa', 'Frutilla', 'Granada', 'Grosella Negra', 'Higo', 'Kiwi', 'Lima', 'Limón','Mandarina', 'Mango', 'Manzana', 'Maracuyá', 'Melón', 'Membrillo', 'Mora', 'Naranja', 'Palta', 'Pera', 'Pomelo', 'Sandía', 'Uva'];
    var marker;
    var map;

    var initMap = function (marcadores) {
        map = new google.maps.Map(document.getElementById('mapa'), {
            center: { lat: -34.9314, lng: -57.9489 },
            zoom: 14
        });
        //Try HTML5 geolocation.
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var pos = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude
                };
                //Inserto la posicion en campo oculto del formulario de busqueda
                $('#Posicion').val(pos.lat + ', ' + pos.lng);
                map.setCenter(pos);
            }, function () {
                handleLocationError(true, infoWindow, map.getCenter());
                });
        } else {
            // Browser doesn't support Geolocation
            handleLocationError(false, infoWindow, map.getCenter());
        }
        if (marcadores!=null) {
            $.each(marcadores, function (i, item) {
                addMarker(item.Latitud, item.Longitud, item.Variedad, item.Id);
            })
        }
        function addMarker(lat, long, variedad, id) {
            var contentString = '<div id="content">' +
                                    '<h5 id="firstHeading" class="firstHeading">' + arboles[variedad] + '</h5>' +
                                    '<div id="bodyContent">' +
                                    '<a href="/Buscador/Detalle/' + id + '">Ver detalles</a>' + 
                                    '</div>' +
                                '</div>';
            var location = new google.maps.LatLng(lat, long);
            var marker = new google.maps.Marker({
                position: location,
                map: map,
                icon: iconos[variedad].icon
            });
            var infowindow = new google.maps.InfoWindow({
                content: contentString
            });
            marker.addListener('click', function () {
                google.maps.event.addListener(map, "click", function (event) {
                    infowindow.close();
                });
                infowindow.open(map, marker);
            });

        }
        map.addListener('click', function (e) {
            placeMarkerAndPanTo(e.latLng, map);
            insertarLatLng(e.latLng);
            obtenerDireccion(e.latLng);
        });
        //mostrar punto en mapa cuando la direccion del arbol ya esta ingresada(editar arbol)
        if ($('#Direccion').val() != null) {
            var latLng = {
                lat: parseFloat($('#Latitud').val()),
                lng: parseFloat($('#Longitud').val())
            }; 
            placeMarkerAndPanTo(latLng, map);
        }

    };
    function placeMarkerAndPanTo(latLng, map) {
            var marker = new google.maps.Marker({
                position: latLng,
                map: map,
                draggable: true
            });
            map.panTo(latLng);
            arrastrarMarcador(marker);
        }
    function handleLocationError(browserHasGeolocation, infoWindow, pos) {
        infoWindow.setPosition(pos);
        infoWindow.setContent(browserHasGeolocation ?
            'Error: The Geolocation service failed.' :
            'Error: Your browser doesn\'t support geolocation.');
    }
    function arrastrarMarcador(marker) {
        google.maps.event.addListener(marker, 'dragend', function (e) {
            insertarLatLng(e.latLng);
            obtenerDireccion(e.latLng);
        });
    }
    function obtenerPosicion(direccion) {
        var url = 'https://maps.googleapis.com/maps/api/geocode/json?address=' + direccion + '&key=AIzaSyBqGcfcsaTBLx40K7RoHgQTLnV05qX2mZI';
        $.ajax({
            type: "POST",
            url: url,
            success: function (respuesta) {
                var latLng = {
                    lat: respuesta.results[0].geometry.location.lat,
                    lng: respuesta.results[0].geometry.location.lng
                };
                placeMarkerAndPanTo(latLng, map);
                insertarLatLng(latLng);
            }
        });
    }; 
    function insertarLatLng(latLng) {
        $('#Latitud').val(latLng.lat);
        $('#Longitud').val(latLng.lng);
    };
    function obtenerDireccion(latLng) {
        var pos = latLng.lat() + ', ' + latLng.lng();
        var url = 'https://maps.googleapis.com/maps/api/geocode/json?latlng=' + pos + '&language=es&key=AIzaSyBqGcfcsaTBLx40K7RoHgQTLnV05qX2mZI';
        $.ajax({
            type: "POST",
            url: url,
            success: function (respuesta) {
                var calle = respuesta.results[0].address_components[1].short_name;
                var numero = respuesta.results[0].address_components[0].short_name;
                var ciudad = respuesta.results[0].address_components[2].short_name;
                var provincia = respuesta.results[0].address_components[4].short_name;
                var pais = respuesta.results[0].address_components[5].long_name;
                var direccion = calle + ' ' + numero + ', ' + ciudad + ', ' + provincia + ', ' + pais;
                map.panTo(latLng);
                insertarDireccion(direccion);
            }
        });
    };
    function insertarDireccion(direccion) {
        $('#Direccion').val(direccion);
    };
    var marcarDireccion = function () {
        obtenerPosicion($('#Direccion').val());
    };

    return {
        initMap: function (marcadores) {
            initMap(marcadores);
        },
        marcarDireccion() {
            marcarDireccion();
        }
    };
}();

//funcion marcar direccion en mapa:
//tomar valor del campo y pasarselo a placeMarkerAndPanTo