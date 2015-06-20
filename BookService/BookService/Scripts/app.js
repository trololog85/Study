var ViewModel = function() {
    var self = this;
    self.books = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();

    var booksuri = '/api/books/';

    function ajaxHelper(uri, method, data) {
        self.error('');
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function(jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllBooks() {
        ajaxHelper(booksuri, 'GET').done(function(data) {
            self.books(data);
        });
    }

    getAllBooks();

    self.getBookDetail = function(item) {
        ajaxHelper(booksuri + item.Id, 'GET').done(function(data) {
            self.detail(data);
        });
    }
};

ko.applyBindings(new ViewModel());