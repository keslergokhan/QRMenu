using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using QRMenu.CmsManagement.Infrastructure.Persistence.Configuration;
using QRMenu.CmsManagement.Infrastructure.Persistence.Context;

namespace QRMenu.CmsManagement.Infrastructure.Persistence
{
    /// <summary>
    /// Design Time Db Context Factory
    /// Powershell gibi console üzerinden migration işlemleri yapabilmemize imkan tanıyan sınıf
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<QRMenuContext>
    {
        public QRMenuContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder builder = new();
            builder.UseSqlServer(AppSettingsConfig.ConnectionMsSql);
            return new(builder.Options);
        }
    }
}
