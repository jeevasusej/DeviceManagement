using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeviceManagement.Entity
{
    public class Credential
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public long DeviceId { get; set; }

        [Required]
        [StringLength(250)]
        public string Password { get; set; }

        [StringLength(250)]
        public string Username { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }

        public Device Device { get; set; }

        public User CreatedUser { get; set; }
        public User UpdatedUser { get; set; }
    }
}
