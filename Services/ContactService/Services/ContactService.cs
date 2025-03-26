using ContactService.Data;
using ContactService.DTOs;
using ContactService.Models;
using AutoMapper;
using ContactService.Repositories;

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

        public async Task<CreateContactResponseDto> CreateContactAsync(CreateContactDto createContactDto)
        {
            var contact = _mapper.Map<Contact>(createContactDto);

            var contactItem = await _contactRepository.CreateContactAsync(contact);
          
            return _mapper.Map<CreateContactResponseDto>(contactItem);
        }
    }
    
}