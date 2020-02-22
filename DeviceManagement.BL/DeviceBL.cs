using AutoMapper;
using DeviceManagement.BL.Constants;
using DeviceManagement.BL.Contracts;
using DeviceManagement.BL.Dto;
using DeviceManagement.DL.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.BL
{
    public class DeviceBL : IDeviceBL
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DeviceBL(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void DeleteDevice(Guid adminid, long id)
        {
            throw new NotImplementedException();
        }

        public Task<DeviceDto> GetDevice(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DeviceDto>> GetDevices(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<UserDeviceDto>> GetUserDevices(Guid userid)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DeviceDto>> GetUserDevices(Guid adminid, Guid userid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDeviceStatus(Guid userid, long deviceId, UserDeviceActionStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDeviceStatus(Guid adminid, Guid userid, long deviceId, AdminDeviceActionStatus status)
        {
            throw new NotImplementedException();
        }

        public void UpsertDevice(DeviceDto device)
        {
            throw new NotImplementedException();
        }
    }
}
