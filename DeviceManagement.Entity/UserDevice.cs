using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeviceManagement.Entity
{
    public class UserDevice
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long DeviceId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public bool IsApproved { get; set; }

        public bool IsRejected { get; set; }
        public string RejectedReason { get; set; }

        public DateTime ApprovedOn { get; set; }

        public DateTime ReturnedOn { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }

        public User User { get; set; }
        public Device Device { get; set; }

        public User CreatedUser { get; set; }
        public User UpdatedUser { get; set; }
    }
}
