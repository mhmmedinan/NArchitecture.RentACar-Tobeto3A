using FluentValidation;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator:AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(r=>r.UserForRegisterDto.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(r => r.UserForRegisterDto.Email).NotEmpty().EmailAddress();
        RuleFor(r => r.UserForRegisterDto.Password).NotEmpty().WithMessage("Your password cannot be empty")
            .MinimumLength(8).WithMessage("Your password length must be at least 8")
            .MaximumLength(16).WithMessage("Your password length must not exceed 16")
            .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter") //regex
            .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter")
            .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number")
            .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!?*.)");

    }
}
