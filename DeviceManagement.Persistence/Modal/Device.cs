using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeviceManagement.Persistence.Modal
{
    public class Device
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Provide device description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Comments on deletion
        /// </summary>
        public string Comments { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
        
        /// <summary>
        /// Total device count
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// After assigned to user, available devices
        /// </summary>
        public int Available { get; set; }
        public ICollection<UserDevice> UserDevice { get; set; }
    }
}
