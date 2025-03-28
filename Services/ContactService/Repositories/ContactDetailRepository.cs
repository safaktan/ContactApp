using System.Net.WebSockets;
using Common.DTOs;
using ContactService.Data;
using ContactService.DTOs;
using ContactService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ContactService.Repositories
{
    public class ContactDetailRepository : IContactDetailRepository
    {
        private readonly ContactDbContext _context;

        public ContactDetailRepository(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContactDetail>> CreateContactDetailAsync(List<ContactDetail> contactDetail)
        {
            await _context.ContactDetails.AddRangeAsync(contactDetail);
            await _context.SaveChangesAsync();

            return contactDetail;
        }

        public async Task<Contact> GetContactInfoAndDetailByContactIdAsync(Guid contactId)
        {

            var contactInfoAndDetail = await _context.Contacts.Where(x => x.Id == contactId).Include(x => x.ContactDetails).FirstOrDefaultAsync();

            return contactInfoAndDetail;

        }

        public async Task<string> DeleteAllContactDetailByContactIdAsync(Guid contactId)
        {
            var contact = await _context.Contacts.Where(x => x.Id == contactId).Include(x => x.ContactDetails).FirstOrDefaultAsync();
            if (contact == null)
            {
                return "Contact not found";
            }

            _context.ContactDetails.RemoveRange(contact.ContactDetails);
            await _context.SaveChangesAsync();
            return "Success";
        }

        public async Task<List<ReportResultDto>> GetReportDataByLocationAsync()
        {
            var result = await _context.ContactDetails.GroupBy(x => x.Location).Select(x => new ReportResultDto
            {
                Location = x.Key,
                ContactCount = x.Select(z => z.ContactId).Distinct().Count(),
                PhoneNumberCount = x.Count(z => !string.IsNullOrWhiteSpace(z.PhoneNumber))
            }).ToListAsync();

            return result;
        }
    }
}