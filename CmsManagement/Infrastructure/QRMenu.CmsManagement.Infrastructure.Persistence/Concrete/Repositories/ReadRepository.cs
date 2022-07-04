using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QRMenu.CmsManagement.Core.Application.Concrete.Model;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using QRMenu.CmsManagement.Core.Application.Interfaces.Repositories;
using QRMenu.CmsManagement.Infrastructure.Persistence.Context;

namespace QRMenu.CmsManagement.Infrastructure.Persistence.Concrete.Repositories
{
    public class ReadRepository<TEntity> : BaseRepository<TEntity>, IReadRepository<TEntity> where TEntity : class
    {
        public ReadRepository(QRMenuContext dbContext):base(dbContext)
        {

        }

        public async Task<IResultData<List<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] include)
        {
            IQueryable<TEntity> query = base.Table;
            try
            {
                if (filter != null)//where sorgu varsa
                    query = query.AsNoTracking().Where(filter).AsQueryable();
                if (include != null)//include varsa
                    foreach (var item in include)
                    {
                        query = query.AsNoTracking().Include(item).AsQueryable();
                    }
                var result = await query.ToListAsync();//asenkron olarka listeyi çektik
                return new ResultData<List<TEntity>>().SetDataSuccessMessage(result,"Liste başarıyla getirildi");
            }
            catch (Exception ex)
            {
                return new ResultData<List<TEntity>>().SetDataErrorMessage(null, ex.Message).SetException(ex);
            }
            finally
            {
                query = null;
            }
            
        }

        public async Task<IResultData<TEntity>> GetFindAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] include)
        {
            IQueryable<TEntity> query = base.Table;
            try
            {
                if (filter != null)//where sorgu varsa
                    query = query.AsNoTracking().Where(filter).AsQueryable();
                if (include != null)//include varsa
                    foreach (var item in include)
                    {
                        query = query.AsNoTracking().Include(item).AsQueryable();
                    }
                var result = await query.FirstOrDefaultAsync();//asenkron olarka listeyi çektik
                return new ResultData<TEntity>().SetDataSuccessMessage(result, "TEntity başarıyla getirildi");
            }
            catch (Exception ex)
            {
                return new ResultData<TEntity>().SetDataErrorMessage(null, ex.Message).SetException(ex);
            }
            finally
            {
                query = null;
            }
        }

        public async Task<IResultData<TEntity>> GetFindIdAsync(Guid id, Expression<Func<TEntity, bool>> filter = null)
        {
            TEntity result = null;
            try
            {
                result = await base.Table.FindAsync(id);
                
                return new ResultData<TEntity>().SetDataSuccessMessage(result, "ID değeri başarıyla getirildi");
            }
            catch (Exception ex)
            {
                return new ResultData<TEntity>().SetDataErrorMessage(result, ex.Message).SetException(ex);
            }
            finally
            {
                result = null;
            }
        }

        public IFilter<TEntity> Query()
        {
            return new Filter<TEntity>(base.Table);
        }
    }
}
