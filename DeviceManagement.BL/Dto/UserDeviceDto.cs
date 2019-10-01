using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManagement.BL.Dto
{
   public class UserDeviceDto
    {
        public int DeviceId { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string PersonName { get; set; }
        public string DeviceName { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsRejected { get; set; }
        public string RequestDesciption { get; set; }
        public string RejectedComments { get; set; }
        public string CancelledComments { get; set; }
        public string ReturnedComments { get; set; }
        public DateTime RequestedOn { get; set; }
        public DateTime? RejectedOn { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime? ReturnedOn { get; set; }
    }
}
