using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.Api.Models
{
    public class UserModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public bool IsActive { get; set; }

    }
}