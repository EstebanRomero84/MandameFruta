var GeoPicker = function () {
    var lookupGeoData = function () {
        myGeoPositionGeoPicker({
            returnFieldMap: {
                'Latitud': '<LAT>',
                'Longitud': '<LNG>',
                'Direccion': '<STREET> <STREETNUMBER>, <CITY>, <COUNTRY_LONG>'
            },
            startPositionInputFieldIds: ['Direccion'],
            windowTitle: 'Mandame Fruta'
        });
    };


    return {
        lookupGeoData: function () {
            lookupGeoData();
        }
    };
}();