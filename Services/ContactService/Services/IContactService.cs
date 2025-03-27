using Common.Models;
using ContactService.DTOs;

namespace ContactService.Services
{
    public interface IContactService
    {
        Task<ServiceResponse<CreateContactResponseDto>> CreateContactAsync(CreateContactDto createContactDto);
        Task<ServiceResponse<string>> DeleteContactAsync(Guid id);
        Task<ServiceResponse<IEnumerable<CreateContactResponseDto>>> GetContactListAsync();
        Task<ServiceResponse<CreateContactResponseDto>> GetContactByIdAsync(Guid id);
        //Task<CreateContactResponseDto> UpdateContactAsync(Guid id, CreateContactDto createContactDto);
    }
    
}