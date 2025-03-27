using ContactService.DTOs;
using ContactService.Models;

namespace ContactService.Repositories
{
    public interface IContactDetailRepository
    {
        Task<List<ContactDetail>> CreateContactDetailAsync(List<ContactDetail> contactDetail);
        Task<Contact> GetContactInfoAndDetailByContactIdAsync(Guid contactId);
        Task<string> DeleteAllContactDetailByContactIdAsync(Guid contactId);
    }
    
}