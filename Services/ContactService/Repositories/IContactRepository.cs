using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactService.Models;

namespace ContactService.Repositories
{
    public interface IContactRepository
    {
        Task<Contact> CreateContactAsync(Contact contact);


        //Task<IEnumerable<Contact>> GetContactsAsync();
        //Task<Contact> GetContactAsync(Guid id);
        //Task<Contact> UpdateContactAsync(Contact contact);
        //Task DeleteContactAsync(Guid id);
    }
    
}