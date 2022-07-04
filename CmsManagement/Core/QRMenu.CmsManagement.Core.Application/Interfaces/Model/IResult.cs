using QRMenu.CmsManagement.Core.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Interfaces.Model
{
    /// <summary>
    ///     Geri dönüş tipi
    ///     Satatus = durum bilgisi
    ///     Message = iletilen mesaj
    ///     ErrorMessage = hata mesajı
    /// </summary>
    public interface IResult
    {
        /// <summary>
        ///     Hata veya olabilecek problemlere karşı geriye döndürülen hata mesajı
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        ///    Bilgilendirme vb. gibi başarılı işlem sonucu geriye döndürülecek mesajdır
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        ///     İlgili hata sınıfı
        /// </summary>
        public Exception Exception { get; set; }
        /// <summary>
        ///     İşlem sonucu başarılı,uyarı,hata gibi durumları bildirir<br></br>
        ///     ResultStatusEnum tipindedir (Success=1,Error=2,Warning=3)
        /// </summary>
        public ResultStatusEnum Status { get; set; }
        /// <summary>
        ///     Result message değerini ekle ve status değerini warning olarak ayarla
        /// </summary>
        /// <param name="message"></param>
        public IResult SetWarningMessage(string warningMessage);
        /// <summary>
        ///     Result errorMessage değerini ekle ve status değerini error olarak ayarla
        /// </summary>
        /// <param name="message"></param>
        public IResult SetErrorMessage(string errorMessage);
        /// <summary>
        ///     Result message değerini ekle ve status değerini Success olarak ayarla
        /// </summary>
        /// <param name="message"></param>
        public IResult SetSuccessMessage(string SuccessMessage);
        /// <summary>
        ///     İlgli hata sınıfını ekle
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public IResult SetException(Exception exception);

        /// <summary>
        ///     Günvelik sebebi ile exception ve exceptionMessage değerlerini siler
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public IResult ClearException();
    }
}
