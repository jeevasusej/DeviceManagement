using AutoMapper;
using DeviceManagement.BL.Contracts;
using DeviceManagement.BL.Dto;
using DeviceManagement.BL.Modal;
using DeviceManagement.DL.Contracts.UnitOfWork;
using DeviceManagement.DL.Modal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.BL
{
    public class UserBL : IUserBL
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserBL(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public Task<bool> DeleteUser(Guid adminId, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<UserDto>> GetAdmins(Guid adminId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<UserDeviceDto>> GetDeviceUserAvailability(Guid adminId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<UserDto>> GetDeviceUsers(Guid adminId, long deviceId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUser(Guid adminId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<UserDto>> GetUsers(Guid adminId, bool excludeInActive = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserDetails(Guid userid, UpdateUserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
