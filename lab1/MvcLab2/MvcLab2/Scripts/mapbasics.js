ymaps.ready(init);
var myMap;

function init() {
    myMap = new ymaps.Map("map", {
        center: [48.71939, 44.50184], // Волгоград
        zoom: 11
    }//, {
      //  balloonMaxWidth: 200,
       // searchControlProvider: 'yandex#search'
    //}
	);

    // Обработка события, возникающего при щелчке
    // левой кнопкой мыши в любой точке карты.
    // При возникновении такого события откроем балун.
    myMap.events.add('click', function (e) {
        if (!myMap.balloon.isOpen()) {
            var coords = e.get('coords');
            myMap.balloon.open(coords, {
                contentHeader: 'Место выбрано!',
                contentBody: '<p></p>' +
                    '<p>Координаты щелчка: ' + [
                    coords[0].toPrecision(6),
                    coords[1].toPrecision(6)
                    ].join(', ') + '</p>',
                contentFooter: '<sup>Щелкните еще раз</sup>'

            });
            var coordints = '' + coords[0].toPrecision(6) + ',' + coords[1].toPrecision(6);
            $.ajax({
                url: '/Home/Action',
                type: 'POST',
                dataType: 'json',
                data: JSON.stringify(coordints),
                contentType: 'application/json; charset=utf-8'
                //success: function (data) {
                //    // get the result and do some magic with it
                //    var message = data.Message;
                //    $("#resultMessage").html(message);
                //}
            });
            //download(coords, "test", "txt");
        }
        else {
            myMap.balloon.close();
        }
    });

    // Обработка события, возникающего при щелчке
    // правой кнопки мыши в любой точке карты.
    // При возникновении такого события покажем всплывающую подсказку
    // в точке щелчка.
    myMap.events.add('contextmenu', function (e) {
        myMap.hint.open(e.get('coords'), 'Для указания координат щелкните левой кнопкой');
    });

    // Скрываем хинт при открытии балуна.
    myMap.events.add('balloonopen', function (e) {
        myMap.hint.close();
    });
}

// Function to download data to a file
function download(data, filename, type) {
    var file = new Blob([data], { type: type });
    if (window.navigator.msSaveOrOpenBlob) // IE10+
        window.navigator.msSaveOrOpenBlob(file, filename);
    else { // Others
        var a = document.createElement("a"),
                url = URL.createObjectURL(file);
        a.href = url;
        a.download = filename;
        document.body.appendChild(a);
        a.click();
        setTimeout(function () {
            document.body.removeChild(a);
            window.URL.revokeObjectURL(url);
        }, 0);
    }
}