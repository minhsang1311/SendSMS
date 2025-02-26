using System.ComponentModel.DataAnnotations;

namespace PhoneManagement.Models
{
    public class PhoneModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}