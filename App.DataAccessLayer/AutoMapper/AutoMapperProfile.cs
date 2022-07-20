using App.DataAccessLayer.DOTS.IssueDOTS;
using App.DataAccessLayer.DOTS.PatientDOTs;
using App.DataAccessLayer.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<patient, PatientRead>();
            CreateMap<PatientWrite, patient>();
            CreateMap<Issue, IssueRead>();
            CreateMap<IssueWrite, Issue>();
            CreateMap<Issue, IssueChildRead>();
        }
    }
}
