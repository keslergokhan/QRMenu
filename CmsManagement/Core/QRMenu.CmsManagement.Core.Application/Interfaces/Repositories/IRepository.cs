using Microsoft.EntityFrameworkCore;
using QRMenu.CmsManagement.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Interfaces.Repositories
{
    /// <summary>
    ///     BaseRepository<br></br>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> Table { get; }
    }
}
