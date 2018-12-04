using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeviceManagement.Entity
{
    public class Device
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }

        public ICollection<Credential> Credentials { get; set; }
        public ICollection<UserDevice> UserDevice { get; set; }

        public User CreatedUser { get; set; }
        public User UpdatedUser { get; set; }
    }
}
