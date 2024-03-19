using System.ComponentModel.DataAnnotations;

namespace Villa_WebAPI.Models
{
    public class VillaDTO
    {
        public int Id { get; set; }
        // Data Annotations were taken care by [ApiController] attribute, if that is not there we need to write custom code for ModelState
        [Required(ErrorMessage="Villa Name is Required")]
        [MaxLength(20,ErrorMessage ="Villa name cannot be more than 20 characters")]
        public string Name { get; set; }

        public int Occupency { get; set; }

        public int Sqft { get; set; }
    }
}
