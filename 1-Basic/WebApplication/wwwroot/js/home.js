(function () {

    var model = new HomeViewModel();
    ko.applyBindings(model, document.getElementById( "model-anchor"));

}($, ko));