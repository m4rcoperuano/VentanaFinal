var AjaxLoaders = function() {
    var DivLoader = function(divId, boolShow) {
        var $loader = $(divId).find('.div-loader');
        if (boolShow == true) {
            $loader.show();
        } else {
            $loader.fadeOut();
        }
    };

    return {
        DivLoader: DivLoader
    };
}();