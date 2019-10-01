using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManagement.BL.Dto
{
    public class DeviceDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        /// <summary>
        /// Provide device description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Comments on deletion
        /// </summary>
        public string Comments { get; set; }
        
        /// <summary>
        /// Total device count
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// After assigned to user, available devices
        /// </summary>
        public int Available { get; set; }
    }
}
