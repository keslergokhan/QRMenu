var cmsAdminProfile = {
    base: {
        init: function () {
            console.log("admin kullanici profil sayfası");
        }
    },
    cmsAdminProfileFormValidate: {
        selector: "#cmsAdminProfile",
        init: function (form) {
            let $this = form;
            $this.validate({
                rules: {
                    adminName: {
                        required: true,
                        minlength: 3,
                        maxlength: 25
                    },
                    adminSurname: {
                        required: true,
                        minlength: 3,
                        maxlength: 25
                    },
                    adminEmail: {
                        required: true,
                        email: true,
                        minlength: 5,
                        maxlength: 25
                    },
                    adminPassword: {
                        minlength: 6,
                        maxlength: 20
                    },
                    adminPasswordNew: {
                        minlength: 6,
                        maxlength: 20
                    },
                    adminPasswordNewControl: {
                        minlength: 6,
                        maxlength: 20,
                        equalTo: "#adminPasswordNew"
                    }
                }, submitHandler: function (form) {
                    cmsAdminProfile.cmsAdminProfilFormPostAjax($this);
                }
            });

        }
    },
    cmsAdminProfilFormPostAjax: function (form) {
        SuccessAlert.fire({ title: "İşleminiz sürdürülüyor !" });

        $.post(form.data("url"), form.serialize()).done(function (data) {
            console.log(data);
        }).fail(function (data) {
            ErrorAlert.fire({
                title: "Üzgünüz !",
                text: "Beklenmedik bir problem yaşandı lütfen daha sonra tekrar deneyin !",
            });
        })
    }
}

RunInit(cmsAdminProfile);