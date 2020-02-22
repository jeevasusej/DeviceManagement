using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeviceManagement.DL.Modal
{
    public class AuditTrail
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Action { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        public User User { get; set; }
    }
}
