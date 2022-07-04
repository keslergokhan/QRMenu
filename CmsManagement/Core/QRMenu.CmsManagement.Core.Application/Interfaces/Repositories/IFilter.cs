using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using QRMenu.CmsManagement.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Interfaces.Repositories
{
    /// <summary>
    ///     Asenkron olarka çalışan db linq sorguları yapmamızı sağlar
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IFilter<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IFilter<TEntity> Where(Expression<Func<TEntity, bool>> where);
        public IFilter<TEntity> Select(Expression<Func<TEntity, TEntity>> where);
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> any);
        public Task<IResultData<TEntity>> FirstOrDefaultAsync();
        public IFilter<TEntity> Select<TResult>(Expression<Func<TEntity, TResult>> where) where TResult : class;
        public Task<IResultData<List<TEntity>>> TolistAsyc();
        public Task<IResultData<List<object>>> ToObjectlistAsyc();
    }
}
