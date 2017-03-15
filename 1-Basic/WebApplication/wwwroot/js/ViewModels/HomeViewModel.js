function HomeViewModel() {
    var self = this;

    var xhr;

    self.loading = ko.observable(true);

    var requestModel = hashashin.toObject();

    self.searchText = ko.observable(requestModel.searchText || "").extend({ rateLimit: 400 });;
    self.selectedOrder = ko.observable(requestModel.sortOrder || "DateDescending");

    self.items = ko.observableArray([]);

    self.load = function(page) {
        if (xhr) {
            xhr.abort();
        }

        self.loading(true);

        page = page || requestModel.page || 1;

        var query = {
            page: page,
            sortOrder: self.selectedOrder(),
            searchText: self.searchText()
        };
        hashashin.fromObject(query);

        xhr = $.get("/home/data", query)
            .done(function(data) {

                self.pager = new PagerViewModel(data, self.load);
                self.items([]);
                for (var i = 0; i < data.items.length; i++) {
                    self.items.push(new ItemViewModel(data.items[i]));
                }

                xhr = null;

                //Just to simulate some actual data retreival ;)
                setTimeout(function () {
                        self.loading(false);
                    },
                    150);
            });
    };

    self.searchText.subscribe(function() {
        self.load();
    });

    self.selectedOrder.subscribe(function() {
        self.load();
    });

    //could move this to hashashin
    window.onhashchange = function () {
        if (self.loading()) {
            return;
        }
        self.load(hashashin.get("page"));
    };


    self.load();
}