using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using QRMenu.CmsManagement.Core.Domain.Common;
using QRMenu.CmsManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Interfaces.Repositories
{
    public interface IWriteRepository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        ///     Asenkron olarak TEntity ekle
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="seve"> Ekledikten sonra db kaydet, default=true</param>
        /// <returns>Task<IResult></returns>
        public Task<IResultData<Guid>> AddAsync(TEntity entity,bool seve=true);
        /// <summary>
        ///     Asenkron olarak TEntity listesi ekle
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="seve"> Ekledikten sonra db kaydet, default=true</param>
        /// <returns></returns>
        public Task<IResult> AddRangeAsync(List<TEntity> entity, bool seve = true);

        /// <summary>
        ///     Asenkron olarak gönderilen TEntity değeri ile eşleşen kayıtı güncelle
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="seve"> Ekledikten sonra db kaydet, default=true</param>
        /// <returns></returns>
        public Task<IResult> UpdateAsync(TEntity entity, bool seve = true);
        /// <summary>
        ///     Asenkron olarak gönderilen TEntity değeri ile eşleşen kayıtı sil
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="seve"> Ekledikten sonra db kaydet, default=true</param>
        /// <returns></returns>
        public Task<IResult> DeleteAsync(TEntity entity, bool seve = true);
        /// <summary>
        ///     Asenkron olarak gönderilen id değeri ile eşleşen ilk kayıtı sil
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="seve"> Ekledikten sonra db kaydet, default=true</param>
        /// <returns></returns>
        public Task<IResult> DeleteByIdAsync(Guid Id, bool seve = true);
        /// <summary>
        ///     Asenkron olarak gönderilen TEntity listesindeki elemanlar ile eşleşen değerleri sil
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="seve"> Ekledikten sonra db kaydet, default=true</param> 
        /// <returns></returns>
        public Task<IResult> DeleteAllAsync(List<TEntity> entities, bool seve = true);
        /// <summary>
        ///     Yapılan işlemleri kaydet...
        /// </summary>
        /// <param name="seve"> Ekledikten sonra db kaydet, default=true</param>
        /// <returns></returns>
        public Task<IResultData<int>> SeveAsync();
    }
}
