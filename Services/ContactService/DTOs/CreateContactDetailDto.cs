namespace ContactService.DTOs
{
    public class CreateContactDetailDto
    {
        public Guid ContactId { get; set; }
        public List<ContactDetailDto> ContactDetails { get; set; }
    }
}