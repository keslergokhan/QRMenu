var adminLogin = {
    base: {
        init:function () {
            console.log("Admin Login");
        }
    },
    adminLoginFormValidate: {
        selector:"#login",
        init: function (form) {

            form.validate({
                rules: {
                    adminEmail: {
                        required: true,
                        email: true,
                        minlength: 5,
                        maxlength: 25
                    },
                    adminPassword: {
                        required: true,
                        minlength: 6,
                        maxlength: 20
                    },
                },
                submitHandler: function () {
                    adminLogin.adminLoginFormPost(form);
                }
            });

        }
    },
    adminLoginFormPost: function (form) {
        $.post(form.data("url"), form.serialize()).done(function (data) {
            console.log(data);
            if (data.status == 1) {
                SuccessAlert.fire({
                    title: "Merhaba !" + data.data.adminName + " " + data.data.adminSurName,
                    text: "Hoş geldiniz ",
                });
                window.location.href = "/yonetim";
            } else if (data.status == 3) {
                WarningAlert.fire({
                    title: "Üzgünüz !",
                    text: data.message,
                });
            } else {
                ErrorAlert.fire({
                    title: "Üzgünüz !",
                    text: data.errorMessage,
                });
            }
        }).fail(function (data) {
            ErrorAlert.fire({
                title: "Üzgünüz !",
                text: "Beklenmedik bir problem yaşandı lütfen daha sonra tekrar deneyin !",
            });
        });
    }



}

RunInit(adminLogin);