using DeviceManagement.BL.Constants;
using DeviceManagement.BL.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManagement.BL.Modal
{
    public class LoginModalValidator : AbstractValidator<LoginModal>
    {
        private readonly IAuthBL _authBl;

        public LoginModalValidator(IAuthBL authBl)
        {
            _authBl = authBl;
            
            RuleFor(rm => rm.Username).NotNull().WithMessage("Username should not be empty")
                .MaximumLength(AppConstants.Username_Max_Length).WithMessage(rm => string.Format("Username should not exceed more than {0} characters", 255))
                .MinimumLength(AppConstants.Username_Min_Length).WithMessage(rm => string.Format("Minimum characters needed for username {0} characters", 4));

            RuleFor(rm => rm.Password).NotNull().WithMessage("Password should not be empty")
                .MaximumLength(AppConstants.Password_Max_Length).WithMessage(rm => string.Format("Username should not exceed more than {0} characters", 255))
                .MinimumLength(AppConstants.Password_Min_Length).WithMessage(rm => string.Format("Minimum characters needed for username {0} characters", 4));
        }
    }

    public class LoginModal
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
