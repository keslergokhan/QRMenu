using AutoMapper;
using Microsoft.Extensions.Logging;
using QRMenu.CmsManagement.Core.Application.Features.Commands.LoggerComman.Command;
using QRMenu.CmsManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Mappings
{
    public class LoggerProfile : Profile
    {
        public LoggerProfile()
        {
            CreateMap<LoggerAddComman, Logger>();
        }
    }
}
