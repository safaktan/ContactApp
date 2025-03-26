namespace ContactService.DTOs
{
    public class CreateContactResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
    }
    
}