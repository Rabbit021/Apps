var ProfileViewModel = function () {
    var self = this;
    var url ="Contact/GetAllProfiles"

    var refresh = function () {
        $.post(url ,{}, function(data) {
            self.Profiles(data);
        });
    };

    self.Profiles = ko.observableArray([]);
    self.createProfile = function () {
        window.location.href = "/Contact/CreateEdit/0";
    };
    self.editProfile = function (profile) {
        window.location.href = "/Contact/CreateEdit/" + profile.ProfileId;
    };
    self.removeProfile = function (profile) {
        if (confirm(("Remove")))
            self.Profiles.remove(profile);
    }
    refresh();
};
ko.applyBindings(new ProfileViewModel());