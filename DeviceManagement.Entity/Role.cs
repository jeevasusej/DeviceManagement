using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeviceManagement.Entity
{
    public class Role
    {
        [Key]
        [Required]
        public byte Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
