using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManagement.DL.Enum
{
    public enum DeviceStatus
    {
        /// <summary>
        /// Requested
        /// </summary>
        WaitingForApproval = 0,
        Approved = 1,
        Cancelled = 2,
        Rejected = 3
    }
}
