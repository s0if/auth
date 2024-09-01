using System.ComponentModel.DataAnnotations;

namespace crud.Models
{
    public class Employee
    {
        [Display(Name= "ID")]
        public int Id { get; set; }
        [DataType("varchar")]
        [MaxLength(50)]
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;
    }
}
