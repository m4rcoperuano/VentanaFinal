var CardBuilder = function () {
    var _canvas = "";
    var _canvasID = "";

    var Initialize = function (canvasId, editImageId) {
        _canvasID = "#" + canvasId;
        var currentCanvasWidth = $(editImageId).width();
        var currentCanvasHeight = $(editImageId).height();
        _canvas = new fabric.Canvas(canvasId);

        var $imgElem = $(editImageId);
        var imgInstance = new fabric.Image($imgElem.get(0), {
            left: currentCanvasWidth / 2,
            top: currentCanvasHeight / 2,
            angle: 0,
            selectable: false
        });

        _canvas.setHeight(currentCanvasHeight);
        _canvas.setWidth(currentCanvasWidth);

        $imgElem.hide();
        _canvas.add(imgInstance);
    };

    return {
        Initialize: Initialize
    };
}();