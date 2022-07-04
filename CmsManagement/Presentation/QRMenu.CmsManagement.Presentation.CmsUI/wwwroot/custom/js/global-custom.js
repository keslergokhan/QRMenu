function RunInit(obj) {/*Init function yapısına sahip olan fucntion objelerimizi otomatik çalıştırmayı sağlar*/
    var $this = obj;
    if (obj != null && obj != undefined) {
        for (item in $this) {
            if ($this.hasOwnProperty(item)) {
                var $method = $this[item];

                //object içinde init ve selector tanımlanmış mı
                if ($method.init !== undefined && $method.selector !== undefined) {

                    //selector de tanımlanan eleman dom içerisinde var mı
                    if (document.querySelector($method.selector) !== undefined) {
                        $method.init($($method.selector));//varsa init functionunu çalıştır ve elemanı gönder
                    } else {
                        console.log($method.selector + " bulunamadı !");
                    }
                //sadece init varsa onu çalıştır
                } else if ($method.init !== undefined) {
                    $method.init();
                }
            }
        }
    }
}

/*juqert validator mesajları */
jQuery.extend(jQuery.validator.messages, {
    required: "Lütfen boş geçmeyiniz",
    remote: "Please fix this field.",
    email: "Lütfen geçerli bir e-posta adresi giriniz.",
    url: "Lütfen URL adresi formatı giriniz.",
    date: "Lütfen geçerli bir tarih giriniz.",
    dateISO: "Please enter a valid date (ISO).",
    number: "Lütfen geçerli bir numara giriniz.",
    digits: "Lütfen sadece rakamlar girniz",
    creditcard: "Please enter a valid credit card number.",
    equalTo: "Şifre uyuşmuyor lütfen tekrar deneyin.",
    accept: "Please enter a value with a valid extension.",
    maxlength: jQuery.validator.format("En fazla {0} karakter girilebilir."),
    minlength: jQuery.validator.format("En az {0} karakter girilebilir."),
    rangelength: jQuery.validator.format("Lütfen {0} ile {1} arasında bir değer giriniz"),
    range: jQuery.validator.format("Please enter a value between {0} and {1}."),
    max: jQuery.validator.format("Lütfen {0} küçük veya eşit uzunluk giriniz"),
    min: jQuery.validator.format("Lütfen {0} büyük veya eşit uzunluk giriniz")
});

/*sweetalert2 taslakları*/
const SuccessAlert = Swal.mixin({
    icon: 'success',
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 6000,
    timerProgressBar: true,
    didOpen: (toast) => {
        toast.addEventListener('mouseenter', Swal.stopTimer)
        toast.addEventListener('mouseleave', Swal.resumeTimer)
    }
});

const ErrorAlert = Swal.mixin({
    icon: 'error',
    toast: true,
    position: 'top-end',
    showConfirmButton: true,
    confirmButtonText:'Tamam',
    timer: 6000,
    timerProgressBar: true,
    didOpen: (toast) => {
        toast.addEventListener('mouseenter', Swal.stopTimer)
        toast.addEventListener('mouseleave', Swal.resumeTimer)
    }
});

const WarningAlert = Swal.mixin({
    icon: 'warning',
    toast: true,
    position: 'top-end',
    showConfirmButton: true,
    confirmButtonText: 'Tamam',
    timer: 6000,
    timerProgressBar: true,
    didOpen: (toast) => {
        toast.addEventListener('mouseenter', Swal.stopTimer)
        toast.addEventListener('mouseleave', Swal.resumeTimer)
    }
});