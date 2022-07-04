var adminRegister = {
    base: {
        init : function () {
            console.log("base init");
        }
    },/*Admin kayıt form validation*/
    formValidation: {
        selector: "#register",
        init: function () {
            let $this = $(this.selector);

            $this.validate({
                rules: {
                    adminName: {
                        required: true,
                        minlength: 3,
                        maxlength:30
                    },
                    adminSurname: {
                        required: true,
                        minlength: 3,
                        maxlength:30
                    },
                    adminEmail: {
                        required: true,
                        email: true,
                        minlength: 5,
                        maxlength:25
                    },
                    adminPolicy: {
                        required: true,
                    },
                    adminPassword: {
                        required: true,
                        minlength: 6,
                        maxlength:20
                    },
                    adminPasswordControl: {
                        required: true,
                        minlength: 6,
                        maxlength: 20,
                        equalTo:"#adminPassword"
                    }
                }, submitHandler: function (form) {
                    adminRegister.formPostAjax($this);
                }
                
                
            });
            

            
        }
    },/*Admin kayıt*/
    formPostAjax: function (form) {
        SuccessAlert.fire({ title: "İşleminiz sürdürülüyor !" })
        $.post("/kayit", form.serialize()).done(function (data) {
            console.log(data);
            if (data.status !== undefined) {
                if (data.status == 1) {
                    SuccessAlert.fire({ title: "İşlem başarılı", html: data.message+'<br><a href="/giris">Şimdi girişe git.</a>' });
                    form.trigger("reset");
                } else if (data.status == 3) {
                    WarningAlert.fire({ title: "Üzgünüm !", text: data.message })
                } else {
                    ErrorAlert.fire({ title: "Üzgünüm !", text: data.errorMessage })
                }
            }
        });
    }
    
}

RunInit(adminRegister);