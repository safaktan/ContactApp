using AutoMapper;
using ReportService.DTOs;
using ReportService.Models;

namespace ReportService.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReportDto,Report>().ReverseMap();
            CreateMap<ReportDetailDto, ReportDetail>().ReverseMap();
        }
    }
    
}