using Common.Models;
using ContactService.Data;
using ContactService.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<Contact> CreateContactAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return contact;
        }
        public async Task<string> DeleteContactAsync(Guid id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return "Contact not found";
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return "Success";
        }

        public async Task<IEnumerable<Contact>> GetContactListAsync()
        {
            return await _context.Contacts.ToListAsync();
        }
    }
    
}