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
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactAsync(CreateContactDto createContactDto)
        {
            var response = await _contactService.CreateContactAsync(createContactDto);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        public async Task<IActionResult> DeleteContactAsync(Guid id)
        {
            var response = await _contactService.DeleteContactAsync(id);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        public async Task<IActionResult> GetContactListAsync()
        {
            var response = await _contactService.GetContactListAsync();

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }

}