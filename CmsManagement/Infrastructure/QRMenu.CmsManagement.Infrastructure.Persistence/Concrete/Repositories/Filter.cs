using Microsoft.EntityFrameworkCore;
using QRMenu.CmsManagement.Core.Application.Concrete.Model;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using QRMenu.CmsManagement.Core.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Infrastructure.Persistence.Concrete.Repositories
{
    public class Filter<TEntity> : IFilter<TEntity> where TEntity : class
    {

        public DbSet<TEntity> Table { get; }
        private IQueryable<TEntity> _query;
        private IQueryable<object> _objectQuery;

        public Filter(DbSet<TEntity> table)
        {
            this._query = table.AsNoTracking().AsQueryable();
        }

        public IFilter<TEntity> Where(Expression<Func<TEntity, bool>> where)
        {
            _query = _query.Where(where);
            return this;

        }
        public IFilter<TEntity> Select(Expression<Func<TEntity, TEntity>> where)
        {
            _query = _query.Select(where);
            return this;
        }

        public IFilter<TEntity> Select<TResult>(Expression<Func<TEntity, TResult>> where) where TResult : class
        {
            _objectQuery = _query.Select(where);

            return this;
        }

        public async Task<IResultData<TEntity>> FirstOrDefaultAsync()
        {
            try
            {
                TEntity entity = await _query.FirstOrDefaultAsync();
                return new ResultData<TEntity>().SetDataSuccessMessage(entity, "Entity başarıyla getirildi");
            }
            catch (Exception ex)
            {

                return new ResultData<TEntity>().SetDataErrorMessage(null, ex.Message).SetException(ex);
            }
            finally
            {
                _query = null;
            }
        }

        public async Task<IResultData<List<TEntity>>> TolistAsyc()
        {
            try
            {
                var result = await _query.ToListAsync();
                return new ResultData<List<TEntity>>().SetDataSuccessMessage(result, "Liste başarıyla getirildi");
            }
            catch (Exception ex)
            {
                return new ResultData<List<TEntity>>().SetDataErrorMessage(null, ex.Message).SetException(ex);
            }
            finally
            {
                _query = null;
            }

        }

        public async Task<IResultData<List<object>>> ToObjectlistAsyc()
        {
            try
            {
                var result = await _objectQuery.ToListAsync();
                return new ResultData<List<object>>().SetDataSuccessMessage(result, "Liste başarıyla getirildi");
            }
            catch (Exception ex)
            {
                return new ResultData<List<object>>().SetDataErrorMessage(null, ex.Message).SetException(ex);
            }
            finally
            {
                _query = null;
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> any)
        {
            var debeen = await this._query.AnyAsync(any);
            return await this._query.AnyAsync(any);
        }
    }
}
