using ContactService.Data;
using ContactService.DTOs;
using ContactService.Models;
using AutoMapper;
using ContactService.Repositories;
using Common.Models;
namespace ContactService.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactDbContext _context;
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public ContactService(ContactDbContext context, IMapper mapper, IContactRepository contactRepository)
        {
            _context = context;
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<ServiceResponse<CreateContactResponseDto>> CreateContactAsync(CreateContactDto createContactDto)
        {
            try
            {
                var contact = _mapper.Map<Contact>(createContactDto);

                var contactItem = await _contactRepository.CreateContactAsync(contact);

                var createContactResponseDto = _mapper.Map<CreateContactResponseDto>(contactItem);
                return ServiceResponse<CreateContactResponseDto>.Success(createContactResponseDto);
            }
            catch (System.Exception)
            {
                return ServiceResponse<CreateContactResponseDto>.Failure("Failed to create contact");
            }
        }

        public async Task<ServiceResponse<string>> DeleteContactAsync(Guid id)
        {
            try
            {
                var response = await _contactRepository.DeleteContactAsync(id);
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

        public async Task<ServiceResponse<IEnumerable<CreateContactResponseDto>>> GetContactListAsync()
        {
            try
            {
                var contacts = await _contactRepository.GetContactListAsync();
                var contactList = _mapper.Map<IEnumerable<CreateContactResponseDto>>(contacts);
                return ServiceResponse<IEnumerable<CreateContactResponseDto>>.Success(contactList);
            }
            catch (System.Exception ex)
            {
                return ServiceResponse<IEnumerable<CreateContactResponseDto>>.Failure(ex.Message);
            }
        }
    }
}