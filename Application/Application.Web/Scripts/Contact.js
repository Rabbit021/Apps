var ProfileViewModel = function () {
    var self = this;
    var url = "Contact/GetAllProfiles"
    var delurl = "Contact/DeleteProfiles";

    var refresh = function () {
        $.post(url, {}, function (data) {
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
        $.post(delurl, { Id: profile.ProfileId }, function (data) {
            self.Profiles(data);
        });
    }
    refresh();
};
ko.applyBindings(new ProfileViewModel());