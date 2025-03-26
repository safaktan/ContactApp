using ContactService.DTOs;
using ContactService.Models; // Assuming ServiceResponse is in this namespace

namespace ContactService.Services
{
    public interface IContactService
    {
        //TODO - Change the return type (Common/ServiceResponse) to the appropriate response type
        //TODO - Add methods for CRUD operations
        Task<CreateContactResponseDto> CreateContactAsync(CreateContactDto createContactDto);
       //Task<List<CreateContactResponseDto>> GetContactsAsync();
        //Task<CreateContactResponseDto> GetContactAsync(Guid id);
        //Task<CreateContactResponseDto> UpdateContactAsync(Guid id, CreateContactDto createContactDto);
        //Task DeleteContactAsync(Guid id);
    }
    
}