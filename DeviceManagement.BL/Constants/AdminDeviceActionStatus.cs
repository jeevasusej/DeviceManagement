using DeviceManagement.Persistence.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManagement.BL.Constants
{
    public enum AdminDeviceActionStatus
    {
        /// <summary>
        /// Requested
        /// </summary>
        WaitingForApproval = UserDeviceActionStatus.WaitingForApproval, 
        Approved = DeviceStatus.Approved,
        Rejected = DeviceStatus.Rejected
    }
}
