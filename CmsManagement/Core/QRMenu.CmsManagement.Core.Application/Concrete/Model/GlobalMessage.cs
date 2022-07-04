using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Concrete.Model
{
    public static class GlobalMessage
    {
        /// <summary>
        /// Tebrikler, İşlem başarıyla tamamlandı !
        /// </summary>
        public static string globalSuccess => "Tebrikler, İşlem başarıyla tamamlandı !";
        /// <summary>
        /// Üzgünüz, işlem sırasında teknik bir problem yaşandı
        /// </summary>
        public static string globalError => "Üzgünüz, işlem sırasında teknik bir problem yaşandı lütfen daha sonra tekrar deneyin";
        /// <summary>
        /// Pardon, beklenmedik bir durum yaşandı lütfen problemi bildiriniz.
        /// </summary>
        public static string globalWarning => "Pardon, beklenmedik bir durum yaşandı lütfen problemi bildiriniz.";

    }

}
