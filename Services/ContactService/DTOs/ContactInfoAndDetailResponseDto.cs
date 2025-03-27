namespace ContactService.DTOs
{
    public class ContactInfoAndDetailResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public List<ContactDetailDto> ContactDetails { get; set; }
    }
    
}