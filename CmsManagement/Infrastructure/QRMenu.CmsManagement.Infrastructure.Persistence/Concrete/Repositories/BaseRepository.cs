using Microsoft.EntityFrameworkCore;
using QRMenu.CmsManagement.Core.Application.Interfaces.Repositories;
using QRMenu.CmsManagement.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Infrastructure.Persistence.Concrete.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _dbContext;

        public DbSet<TEntity> Table => _dbContext.Set<TEntity>();

        public BaseRepository(QRMenuContext dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
