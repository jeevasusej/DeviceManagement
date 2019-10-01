using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManagement.BL.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? LastLoginOn { get; set; }
        public bool IsActive { get; set; }
    }
}
