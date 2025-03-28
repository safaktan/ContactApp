using AutoMapper;
using Common.DTOs;
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
            CreateMap<ReportGeneratedDto, List<ReportDetail>>()
            .ConvertUsing(src => src.ReportResultDtoList.Select(cd => new ReportDetail
            {
                ReportId = src.ReportId,
                Location = cd.Location,
                ContactCount = cd.ContactCount,
                PhoneNumberCount = cd.PhoneNumberCount
            }).ToList());
        }
    }
    
}