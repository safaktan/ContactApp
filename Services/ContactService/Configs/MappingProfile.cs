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
        }
    }
    
}