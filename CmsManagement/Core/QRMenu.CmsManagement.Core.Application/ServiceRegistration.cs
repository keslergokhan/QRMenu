using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using FluentValidation;

namespace QRMenu.CmsManagement.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection serviceDescriptors)
        {
            // MediatR kütüphanesini
            serviceDescriptors.AddMediatR(typeof(ServiceRegistration).GetTypeInfo().Assembly);
            // AutoMapper kütüphanesini
            serviceDescriptors.AddAutoMapper(typeof(ServiceRegistration).GetTypeInfo().Assembly);
            //Fluent Validation kütüphanesini Ioc injecte ediyoruz...
            serviceDescriptors.AddValidatorsFromAssembly(typeof(ServiceRegistration).GetTypeInfo().Assembly);
            //Fluent validation
            serviceDescriptors.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            
        }
    }
}
