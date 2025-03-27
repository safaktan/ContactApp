namespace ContactService.DTOs
{
    public class CreateContactDetailResponseDto
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public List<ContactDetailDto> ContactDetails { get; set; }
    }
    
}