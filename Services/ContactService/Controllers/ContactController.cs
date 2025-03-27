using AutoMapper;
using ContactService.DTOs;
using ContactService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IContactDetailService _contactDetailService;

        public ContactController(IContactService contactService, IContactDetailService contactDetailService)
        {
            _contactService = contactService;
            _contactDetailService = contactDetailService;
        }

        [HttpPost("CreateContact")]
        public async Task<IActionResult> CreateContactAsync([FromBody]CreateContactDto createContactDto)
        {
            var response = await _contactService.CreateContactAsync(createContactDto);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactAsync(Guid id)
        {
            var response = await _contactService.DeleteContactAsync(id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        [HttpGet("GetAllContacts")]
        public async Task<IActionResult> GetContactListAsync()
        {
            var response = await _contactService.GetContactListAsync();

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("CreateContactDetail")]
        public async Task<IActionResult> CreateContactDetailAsync([FromBody]CreateContactDetailDto createContactDetailDto)
        {
            var response = await _contactDetailService.CreateContactDetailAsync(createContactDetailDto);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        [HttpGet("GetContactInfoAndDetailByContactId/{contactId}")]
        public async Task<IActionResult> GetContactInfoAndDetailByContactIdAsync(Guid contactId)
        {
            var response = await _contactDetailService.GetContactInfoAndDetailByContactIdAsync(contactId);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("DeleteAllContactDetailByContactId/{contactId}")]
        public async Task<IActionResult> DeleteAllContactDetailByContactIdAsync(Guid contactId)
        {
            var response = await _contactDetailService.DeleteAllContactDetailByContactIdAsync(contactId);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }

}