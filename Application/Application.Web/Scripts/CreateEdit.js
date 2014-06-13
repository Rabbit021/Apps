var url = window.location.pathname;
var profiledId = url.substring(url.lastIndexOf("/") + 1);

var DummyProfile = [{
    "ProfileId": 1,
    "FirstName": "Anand",
    "LastName": "Pandey",
    "Email": "anand@anandpandey.com"
}, {
    "ProfileId": 2,
    "FirstName": "John",
    "LastName": "Cena",
    "Email": "john@cena.com"
}]

var Profile = function (profile) {
    var self = this;
    self.ProfileId = ko.observable(profile ? profile.ProfileId : 0);
    self.FirstName = ko.observable(profile ? profile.FirstName : '');
    self.LastName = ko.observable(profile ? profile.LastName : '');
    self.Email = ko.observable(profile ? profile.Email : '');
};

var ProfileCollection = function () {
    var self = this;
    if (profiledId == 0) {
        self.profile = ko.observable(new Profile());
    } else {
        var currentProfile = $.grep(DummyProfile, function (e) {
            return e.ProfileId == profiledId;
        });
        self.profile = ko.observable(new Profile(currentProfile[0]));
    }
    self.backToProfileList = function () {
        window.location.href = "./contact";
    };

    self.saveProfile = function () {
        alert(JSON.stringify(ko.toJSON(self.profile())));
    };
}

ko.applyBindings(new ProfileCollection());