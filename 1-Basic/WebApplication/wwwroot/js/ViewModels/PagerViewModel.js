function PagerViewModel(data, load) {
    var self = this;

    if (data.totalPages > 0 && (data.currentPage < 1 || data.currentPage > data.totalPages)) {
        load(1);
        return;
    }

    self.currentPage = ko.observable(data.currentPage);
    self.totalPages = ko.observable(data.totalPages);

    hashashin.set("page", data.currentPage);

    self.visible = ko.pureComputed(function() {
        return self.totalPages() > 1;
    });

    self.setPage = function(page) {
        self.currentPage(page);
        load(self.currentPage());
    };

    self.up = function() {
        self.currentPage(self.currentPage() +1);
        load(self.currentPage());
    };

    self.down = function() {
        self.currentPage(self.currentPage() - 1);
        load(self.currentPage());
    };

    self.canGoUp = ko.pureComputed(function() {
        return self.currentPage() < self.totalPages();
    });

    self.canGoDown = ko.pureComputed(function () {
       return self.currentPage() > 1;
    });
}