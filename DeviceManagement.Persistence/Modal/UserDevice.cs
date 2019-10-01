using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeviceManagement.Persistence.Modal
{
    public class UserDevice
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public long DeviceId { get; set; }
        public byte Status { get; set; }
        public string RequestDesciption { get; set; }
        public string RejectedComments { get; set; }
        public string CancelledComments { get; set; }
        public string ReturnedComments { get; set; }
        public DateTime RequestedOn { get; set; }
        public DateTime? RejectedOn { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime? ReturnedOn { get; set; }
        public User User { get; set; }
        public Device Device { get; set; }
        public DeviceStatus DeviceStatus { get; set; }
    }
}
