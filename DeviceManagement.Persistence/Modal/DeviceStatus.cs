using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeviceManagement.Persistence.Modal
{
    public class DeviceStatus
    {
        [Key]
        [Required]
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<UserDevice> UserDevice { get; set; }
    }
}
