var Mapa = function () {
    var iconBase = '/img/iconos/';
    var iconos = {0: {icon: iconBase + 'anana.png'},1: {icon: iconBase + 'arandano.png'},2: {icon: iconBase + 'arandanorojo.png'        },        3: {            icon: iconBase + 'banana.png'},4: {icon: iconBase + 'cereza.png'},5: {icon: iconBase + 'ciruela.png'},6: {icon: iconBase + 'coco.png'        },        7: {            icon: iconBase + 'damasco.png'        },        8: {            icon: iconBase + 'durazno.png'        },        9: {            icon: iconBase + 'frambuesa.png'        },        10: {            icon: iconBase + 'frutilla.png'        },        11: {            icon: iconBase + 'granada.png'        },        12: {            icon: iconBase + 'grosella.png'        },        13: {            icon: iconBase + 'higo.png'        },        14: {            icon: iconBase + 'kiwi.png'        },        15: {            icon: iconBase + 'lima.png'        },        16: {            icon: iconBase + 'limon.png'        },        17: {            icon: iconBase + 'mandarina.png'        },        18: {            icon: iconBase + 'mango.png'        },        19: {            icon: iconBase + 'manzana.png'        },        20: {            icon: iconBase + 'maracuya.png'        },        21: {            icon: iconBase + 'melon.png'        },        22: {            icon: iconBase + 'membrillo.png'        },        23: {            icon: iconBase + 'mora.png'        },        24: {            icon: iconBase + 'naranja.png'        },        25: {            icon: iconBase + 'palta.png'        },        26: {            icon: iconBase + 'pera.png'        },        27: {            icon: iconBase + 'pomelo.png'        },        28: {            icon: iconBase + 'sandia.png'        },        29: {            icon: iconBase + 'uva.png'        }    };
    var arboles = ['Ananá', 'Arándano', 'Arándanorojo', 'Banana', 'Cereza', 'Ciruela', 'Coco', 'Damasco', 'Durazno', 'Frambuesa', 'Frutilla', 'Granada', 'Grosella Negra', 'Higo', 'Kiwi', 'Lima', 'Limón','Mandarina', 'Mango', 'Manzana', 'Maracuyá', 'Melón', 'Membrillo', 'Mora', 'Naranja', 'Palta', 'Pera', 'Pomelo', 'Sandía', 'Uva'];
    var marker;

    var initMap = function (marcadores) {
        var map = new google.maps.Map(document.getElementById('mapa'), {
            center: { lat: -34.9314, lng: -57.9489 },
            zoom: 14
        });
        $.each(marcadores, function (i, item) {
            addMarker(item.Latitud, item.Longitud, item.Variedad, item.Id);
        })

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
    };
    var geoFindMe = function () {
        var output = document.getElementById("out");

        if (!navigator.geolocation) {
            output.innerHTML = "<p>Geolocation is not supported by your browser</p>";
            return;
        }

        function success(position) {
            var latitude = position.coords.latitude;
            var longitude = position.coords.longitude;

            output.innerHTML = '<p>Latitude is ' + latitude + '° <br>Longitude is ' + longitude + '°</p>';

            var img = new Image();
            img.src = "http://maps.googleapis.com/maps/api/staticmap?center=" + latitude + "," + longitude + "&zoom=13&size=300x300&sensor=false";

            output.appendChild(img);
        }

        function error() {
            output.innerHTML = "Unable to retrieve your location";
        }

        output.innerHTML = "<p>Locating…</p>";

        navigator.geolocation.getCurrentPosition(success, error);
    };
    var calcularDistancia = function () { };

    function handleLocationError(browserHasGeolocation, infoWindow, pos) {
        infoWindow.setPosition(pos);
        infoWindow.setContent(browserHasGeolocation ?
            'Error: The Geolocation service failed.' :
            'Error: Your browser doesn\'t support geolocation.');
    }

    return {
        geoFindMe: function () {
            geoFindMe();
        },
        initMap: function (marcadores) {
            initMap(marcadores);
        }
    };
}();