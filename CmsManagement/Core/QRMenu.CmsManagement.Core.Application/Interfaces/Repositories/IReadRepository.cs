using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using QRMenu.CmsManagement.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace QRMenu.CmsManagement.Core.Application.Interfaces.Repositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        ///     TEntity tipinde List döndürür, Expression varsa onu uygular
        /// </summary>
        /// <param name="filter">Expression<Func<TEntity,bool></param>
        /// <param name="include">Expression<Func<TEntity,object>>[]</param>
        /// <returns>Task<IResultData<List<TEntity>>></returns>
        public Task<IResultData<List<TEntity>>> GetAllAsync(Expression<Func<TEntity,bool>> filter=null,params Expression<Func<TEntity,object>>[] include);
        /// <summary>
        ///     TEntity tipinde ilgili Expression sorgusunu çalıştırarak ilk değeri getirir
        /// </summary>
        /// <param name="filter">Expression<Func<TEntity, bool>></param>
        /// <param name="include">Expression<Func<TEntity, object>>[]</param>
        /// <returns>Task<IResultData<TEntity>></returns>
        public Task<IResultData<TEntity>> GetFindAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] include);
        /// <summary>
        ///     TEntity tipinde ilgili Guid değerine sahip olan ilk değeri getir, Expression varsa bunu uygular
        /// </summary>
        /// <param name="filter">Expression<Func<TEntity, bool>></param>
        /// <param name="include">Expression<Func<TEntity, object>>[]</param>
        /// <returns>Task<IResultData<TEntity>></returns>
        public Task<IResultData<TEntity>> GetFindIdAsync(Guid id,Expression<Func<TEntity, bool>> filter = null);
        /// <summary>
        ///     Asenkron olarak linq sorgulamları yapmanı sağlar IFilter interface sınıfnı kullanır
        /// </summary>
        /// <returns></returns>
        public IFilter<TEntity> Query();
    }
}
