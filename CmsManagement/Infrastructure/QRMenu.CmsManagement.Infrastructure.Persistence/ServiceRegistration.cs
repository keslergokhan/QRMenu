using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QRMenu.CmsManagement.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRMenu.CmsManagement.Infrastructure.Persistence.Configuration;
using System.Reflection;
using QRMenu.CmsManagement.Core.Application.Interfaces.Repositories;
using QRMenu.CmsManagement.Core.Domain.Entities;
using QRMenu.CmsManagement.Infrastructure.Persistence.Concrete.Repositories;
using QRMenu.CmsManagement.Core.Application;

namespace QRMenu.CmsManagement.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddApplicationService();
            serviceDescriptors.AddDbContext<QRMenuContext>(opt=>opt.UseSqlServer(AppSettingsConfig.ConnectionMsSql));
            serviceDescriptors.AddScoped<IReadRepository<Admin>, ReadRepository<Admin>>();
            serviceDescriptors.AddScoped<IWriteRepository<Admin>, WriteRepository<Admin>>();
            serviceDescriptors.AddScoped<IWriteRepository<Logger>, WriteRepository<Logger>>();
            serviceDescriptors.AddScoped<IWriteRepository<Language>, WriteRepository<Language>>();
        }
    }
}
