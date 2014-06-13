﻿var DummyProfile = [{
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

var ProfileViewModel = function() {
    var self = this;
    var refresh = function() {
        self.Profiles(DummyProfile);
    }

    self.Profiles = ko.observableArray([]);

    self.createProfile = function() {
        window.location.href="/Contact/CreateEdit/0";
    };

    self.editProfile = function(profile) {
        window.location.href="/Contact/CreateEdit/" + profile.ProfileId;
    };
    self.removeProfile = function(profile) {
        if(confirm(("Remove")))
            self.Profiles.remove(profile);
    }
    refresh();
};
ko.applyBindings(new ProfileViewModel());