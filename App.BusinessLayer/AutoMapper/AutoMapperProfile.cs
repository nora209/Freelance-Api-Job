using App.BusinessLayer.DTOs;
using App.DataAccessLayer.Models;
using AutoMapper;

namespace App.BusinessLayer.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patient, PatientRead>();
            CreateMap<PatientWrite, Patient>();
            CreateMap<Issue, IssueRead>();
            CreateMap<IssueWrite, Issue>();
            CreateMap<Issue, IssueChildRead>();
        }
    }
}
