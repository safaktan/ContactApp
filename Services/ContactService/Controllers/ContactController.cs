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
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper, IContactDetailService contactDetailService)
        {
            _contactService = contactService;
            _mapper = mapper;
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
        public async Task<IActionResult> DeleteContactAsync([FromBody]Guid id)
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
        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetContactInfoAndDetailByContactIdAsync([FromBody]Guid contactId)
        {
            var response = await _contactDetailService.GetContactInfoAndDetailByContactIdAsync(contactId);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{contactId}")]
        public async Task<IActionResult> DeleteAllContactDetailByContactIdAsync([FromBody]Guid contactId)
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