using DeveloperStore.Users.Domain.Enums;
using FluentValidation;

namespace DeveloperStore.Users.Application.Commands.UpdateUser
{
    public class UpdateUserCommandValidator: AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID must be greater than 0.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(50).WithMessage("Username must not exceed 50 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("Name is required.");

            RuleFor(x => x.Name.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

            RuleFor(x => x.Name.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

            RuleFor(x => x.Address)
                .NotNull().WithMessage("Address is required.");

            RuleFor(x => x.Address.City)
                .NotEmpty().WithMessage("City is required.");

            RuleFor(x => x.Address.Street)
                .NotEmpty().WithMessage("Street is required.");

            RuleFor(x => x.Address.Number)
                .GreaterThan(0).WithMessage("Number must be greater than 0.");

            RuleFor(x => x.Address.ZipCode)
                .NotEmpty().WithMessage("Zip code is required.");

            RuleFor(x => x.Address.Geolocation)
                .NotNull().WithMessage("Geolocation is required.");

            RuleFor(x => x.Address.Geolocation.Lat)
                .NotEmpty().WithMessage("Latitude is required.");

            RuleFor(x => x.Address.Geolocation.Long)
                .NotEmpty().WithMessage("Longitude is required.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(BeAValidStatus).WithMessage("Invalid status value.");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required.")
                .Must(BeAValidRole).WithMessage("Invalid role value.");
        }

        private bool BeAValidStatus(string status)
        {
            return Enum.TryParse(typeof(UserStatus), status, out _);
        }

        private bool BeAValidRole(string role)
        {
            return Enum.TryParse(typeof(UserRole), role, out _);
        }
    }
}
