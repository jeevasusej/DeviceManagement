using DeviceManagement.DL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManagement.BL.Constants
{
    public enum UserDeviceActionStatus
    {
        /// <summary>
        /// Requested
        /// </summary>
        WaitingForApproval = DeviceStatus.WaitingForApproval,
        Cancelled = DeviceStatus.Cancelled
    }
}
