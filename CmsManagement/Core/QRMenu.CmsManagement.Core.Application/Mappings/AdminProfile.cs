using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using QRMenu.CmsManagement.Core.Application.Concrete.Dtos.Reads.Admin;
using QRMenu.CmsManagement.Core.Application.Features.Commands.AdminComman.Command;
using QRMenu.CmsManagement.Core.Application.Features.Queries.AdminQueri.Queries;
using QRMenu.CmsManagement.Core.Domain.Entities;

namespace QRMenu.CmsManagement.Core.Application.Mappings
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<AdminRegisterComman, Admin>();
            CreateMap<AdminRegisterComman, AdminReadDto>();
            CreateMap<AdminLoginQuery, Admin>();
            CreateMap<Admin, AdminReadDto>();
            CreateMap<AdminProfileUpdateComman, Admin>();
            CreateMap<Admin, AdminProfileUpdateComman> ();
        }
    }
}
