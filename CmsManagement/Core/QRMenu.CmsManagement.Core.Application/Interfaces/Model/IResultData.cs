using AutoMapper;
using QRMenu.CmsManagement.Core.Application.Concrete.Dtos.Reads.Admin;
using QRMenu.CmsManagement.Core.Application.Features.Commands.AdminComman.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Interfaces.Model
{
    public interface IResultData<T> : IResult
    {
        /// <summary>
        ///     Result olarak döndürülecek olan generic nesne
        /// </summary>
        public T? Data { get; set; }
        /// <summary>
        ///     Bir generic data ekle
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IResultData<T> SetData(T data);
        /// <summary>
        ///     Generic data ile beraber bir mesaj ekle ve satatus değerini success yap
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public IResultData<T> SetDataSuccessMessage(T data, string message);
        /// <summary>
        ///     Generic data ile beraber bir mesaj ekle ve satatus değerini warning yap
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public IResultData<T> SetDataWarningMessage(T data, string message);
        /// <summary>
        ///     Generic data ile beraber bir mesaj ekle ve satatus değerini error yap
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public IResultData<T> SetDataErrorMessage(T data,string errorMessage);

        /// <summary>
        ///     İlgili hata sınıfı ekle
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public IResultData<T> SetException(Exception exception);

        /// <summary>
        ///     Result message değerini ekle ve status değerini warning olarak ayarla
        /// </summary>
        /// <param name="message"></param>
        public IResultData<T> SetWarningMessage(string warningMessage);
        /// <summary>
        ///     Result errorMessage değerini ekle ve status değerini error olarak ayarla
        /// </summary>
        /// <param name="message"></param>
        public IResultData<T> SetErrorMessage(string errorMessage);
        /// <summary>
        ///     Result message değerini ekle ve status değerini Success olarak ayarla
        /// </summary>
        /// <param name="message"></param>
        public IResultData<T> SetSuccessMessage(string SuccessMessage);
        /// <summary>
        ///     Günvelik sebebi ile exception ve exceptionMessage değerlerini siler
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public IResultData<T> ClearException();

    }
}
