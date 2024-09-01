using System.ComponentModel.DataAnnotations;

namespace crud.Models
{
    public class User
    {
        [Key]
        [Display(Name = "id")]
        public Guid Id { get; set; }
        [Display(Name="name")]
        public string? Name { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string? Password { get; set; }
        [Display (Name = "action")]
        public bool IsActive { get; set; }
        [Display(Name="create")]
        public DateTime CreatedAt { get; set; }
    }
}
