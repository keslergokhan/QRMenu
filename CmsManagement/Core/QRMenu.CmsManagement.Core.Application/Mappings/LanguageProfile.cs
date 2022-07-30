using AutoMapper;
using QRMenu.CmsManagement.Core.Application.Features.Commands.LanguageCommand.Command;
using QRMenu.CmsManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application.Mappings
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageAddCommand, Language>();
        }
    }
}
