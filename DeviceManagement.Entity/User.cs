using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.Entity
{
    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public byte RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<UserDevice> UserDevice { get; set; }

    }
}