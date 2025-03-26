using System.ComponentModel.DataAnnotations;
namespace ContactService.DTOs
{    
    public class CreateContactDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
    }
}
