using AutoMapper;
using Common.Models;
using ContactService.DTOs;
using ContactService.Models;
using ContactService.Repositories;

namespace ContactService.Services
{
    public class ContactDetailService : IContactDetailService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactDetailRepository _contactDetailRepository;
        private readonly IMapper _mapper;

        public ContactDetailService(IContactRepository contactRepository, IContactDetailRepository contactDetailRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _contactDetailRepository = contactDetailRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<CreateContactDetailResponseDto>>> CreateContactDetailAsync(CreateContactDetailDto createContactDetailDto)
        {
            try
            {
                var contactItem = await _contactRepository.GetContactByIdAsync(createContactDetailDto.ContactId);

                if(contactItem == null)
                {
                    return ServiceResponse<List<CreateContactDetailResponseDto>>.Failure("Contact not found");
                }

                var contactDetailList = _mapper.Map<List<ContactDetail>>(createContactDetailDto);
                var createdContactDetail = await _contactDetailRepository.CreateContactDetailAsync(contactDetailList);
                var createContactDetailResponseDtoList = _mapper.Map<List<CreateContactDetailResponseDto>>(createdContactDetail);

                return ServiceResponse<List<CreateContactDetailResponseDto>>.Success(createContactDetailResponseDtoList);
            }
            catch (System.Exception ex)
            {
                return ServiceResponse<List<CreateContactDetailResponseDto>>.Failure(ex.Message);
            }
        }

        public async Task<ServiceResponse<ContactInfoAndDetailResponseDto>> GetContactInfoAndDetailByContactIdAsync(Guid contactId)
        {
            try
            {
                var contactInfoAndDetail = await _contactDetailRepository.GetContactInfoAndDetailByContactIdAsync(contactId);
                if(contactInfoAndDetail == null)
                {
                    return ServiceResponse<ContactInfoAndDetailResponseDto>.Failure("Contact not found");
                }
                var contactInfoAndDetailResponseDto = _mapper.Map<ContactInfoAndDetailResponseDto>(contactInfoAndDetail);

                return ServiceResponse<ContactInfoAndDetailResponseDto>.Success(contactInfoAndDetailResponseDto);
            }
            catch (System.Exception ex)
            {
                return ServiceResponse<ContactInfoAndDetailResponseDto>.Failure(ex.Message);
            }
        }
        
        public async Task<ServiceResponse<string>> DeleteAllContactDetailByContactIdAsync(Guid contactId)
        {
            try
            {
                var response = await _contactDetailRepository.DeleteAllContactDetailByContactIdAsync(contactId);
                if (response != "Success")
                {
                    return ServiceResponse<string>.Failure(response);
                }
                return ServiceResponse<string>.Success(response);
            }
            catch (System.Exception ex)
            {
                return ServiceResponse<string>.Failure(ex.Message);
            }
        }
    }
}