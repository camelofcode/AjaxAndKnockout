function ItemViewModel(data) {
   var self = this;

    self.name = ko.observable(data.name);
    self.description = ko.observable(data.description);
    self.date = ko.observable(data.date);

    self.showAlert = function () {
        alert("You clicked " + self.name());
    };
}