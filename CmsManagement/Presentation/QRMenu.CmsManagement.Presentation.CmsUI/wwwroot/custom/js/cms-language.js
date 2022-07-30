var cmsLanguage = {
    base: {
        init: function () {
            console.log("language");
        }
    },
    cmsLanguageAddValidate: {
        selector: "#cmsLanguageAdd",
        init:function (form) {
            let $this = form;
            form.validate({
                rules: {
                    LanguageName: {
                        required: true,
                        minlength: 3,
                        maxlength:20
                    },
                    LanguageCode: {
                        required: true,
                        minlength: 2,
                        maxlength: 5
                    },
                    LanguageFlag: {
                        required:true
                    },
                    LanguageFlag: {
                        required: true
                    },
                    Sorting: {
                        required: true,
                        number:true
                    }
                },
                submitHandler: function (form) {
                    cmsLanguage.cmsLanguageFormAddPostAjax($this);
                }
            });

        }
    },
    cmsLanguageFormAddPostAjax: function (form) {
        SuccessAlert.fire({ title: "İşleminiz sürdürülüyor !" });

        $.post(form.data("url"), form.serialize()).done(function (data) {
            console.log(data);
            if (data.status !== undefined) {
                if (data.status == 1) {
                    SuccessAlert.fire({ title: "İşlem başarılı", html: "Beni yönlendir  <br> <a href='diller'>Diller Tablosu </a>" });
                    form.trigger("reset");
                } else if (data.status == 3) {
                    WarningAlert.fire({ title: "Üzgünüm !", text: data.message })
                } else {
                    ErrorAlert.fire({ title: "Üzgünüm !", text: data.errorMessage })
                }
            }
            
        }).fail(function (data) {
            ErrorAlert.fire({
                title: "Üzgünüz !",
                text: "Beklenmedik bir problem yaşandı lütfen daha sonra tekrar deneyin !",
            });
        })

    }
};

RunInit(cmsLanguage);