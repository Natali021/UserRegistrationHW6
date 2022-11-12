using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UserRegistration_HW6.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Unicode]
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string UserFullName { get; set; }

        [Unicode]
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string UserLogin { get; set; }

        [Unicode]
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string UserPassword { get; set; }

        [Unicode]
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Role { get; set; }

        public override string ToString()
            => $"[{Id}]\tName: {UserFullName}\tLogin: {UserLogin}";
    }
}
