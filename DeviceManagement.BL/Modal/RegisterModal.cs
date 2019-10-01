using DeviceManagement.BL.Constants;
using DeviceManagement.BL.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.BL.Modal
{
    public class RegisterModalValidator : AbstractValidator<RegisterModal>
    {
        private readonly IAuthBL _authBl;

        public RegisterModalValidator(IAuthBL authBl)
        {
            _authBl = authBl;

            RuleFor(rm => rm.Username).NotNull().WithMessage("Username should not be empty")
                .MaximumLength(AppConstants.Username_Max_Length).WithMessage(rm => string.Format("Username should not exceed more than {0} characters",  255))
                .MinimumLength(AppConstants.Username_Min_Length).WithMessage(rm => string.Format("Minimum characters needed for username {0} characters", 4))
                .MustAsync((username, cancellation) => UserExist(username))
                .WithMessage("Email already taken");

            RuleFor(rm => rm.Name).NotNull().WithMessage("Name should not be empty")
                .MaximumLength(AppConstants.PersonName_Max_Length).WithMessage(rm => string.Format("Name should not exceed more than {0} characters", 255))
                .MinimumLength(AppConstants.PersonName_Min_Length).WithMessage(rm => string.Format("Minimum characters needed for Name {0} characters", 4));

            RuleFor(rm => rm.Email).NotNull().WithMessage("Email should not be empty")
                .EmailAddress().WithMessage("A valid email is required");

            RuleFor(rm => rm.Password).NotNull().WithMessage("Password should not be empty")
                .MaximumLength(AppConstants.Password_Max_Length).WithMessage(rm => string.Format("Username should not exceed more than {0} characters", 255))
                .MinimumLength(AppConstants.Password_Min_Length).WithMessage(rm => string.Format("Minimum characters needed for username {0} characters", 4));
        }

        async Task<bool> UserExist(string username)
        {
            return !await _authBl.UserExists(username);
        }
    }
    public class RegisterModal
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
