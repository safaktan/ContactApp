using AutoMapper;
using ContactService.DTOs;
using ContactService.Models;

namespace ContactService.Configs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<Contact, CreateContactResponseDto>().ReverseMap();
            CreateMap<ContactDetailDto, ContactDetail>().ReverseMap();
            CreateMap<CreateContactDetailDto, List<ContactDetail>>()
            .ConvertUsing(src => src.ContactDetails.Select(cd => new ContactDetail
            {
                ContactId = src.ContactId,
                PhoneNumber = cd.PhoneNumber,
                EmailAddress = cd.EmailAddress,
                Location = cd.Location
            }).ToList());

            CreateMap<List<ContactDetail>, CreateContactDetailResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.First().Id))
            .ForMember(dest => dest.ContactId, opt => opt.MapFrom(src => src.First().ContactId))
            .ForMember(dest => dest.ContactDetails, opt => opt.MapFrom(src =>
            src.Select(cd => new ContactDetailDto
            {
                PhoneNumber = cd.PhoneNumber,
                EmailAddress = cd.EmailAddress,
                Location = cd.Location
            }).ToList()));

            CreateMap<Contact, ContactInfoAndDetailResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
            .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company))
            .ForMember(dest => dest.ContactDetails, opt => opt.MapFrom(src =>
            src.ContactDetails.Select(cd => new ContactDetailDto
            {
                PhoneNumber = cd.PhoneNumber,
                EmailAddress = cd.EmailAddress,
                Location = cd.Location
            }).ToList()));
        }
    }
}