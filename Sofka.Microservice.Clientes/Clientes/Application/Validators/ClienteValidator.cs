namespace Sofka.Microservice.Clientes.Clientes.Application.Validators;

using FluentValidation;
using Sofka.Microservice.Clientes.Clientes.Application.Commands;

public class CrearClienteCommandValidator : AbstractValidator<CrearClienteCommand>
{
    public CrearClienteCommandValidator()
    {
        RuleFor(x => x.Nombres)
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres.")
            .MaximumLength(100).WithMessage("El nombre no puede tener más de 100 caracteres.");

        RuleFor(x => x.Direccion)
            .NotEmpty().WithMessage("La dirección es obligatoria.")
            .MinimumLength(5).WithMessage("La dirección debe tener al menos 5 caracteres.")
            .MaximumLength(200).WithMessage("La dirección no puede tener más de 200 caracteres.");

        RuleFor(x => x.Telefono)
            .NotEmpty().WithMessage("El teléfono es obligatorio.")
            .Matches(@"^\d{10}$").WithMessage("El teléfono debe tener 10 dígitos.");

        RuleFor(x => x.Contrasenia)
            .NotEmpty().WithMessage("La contraseña es obligatoria.")
            .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres.")
            .MaximumLength(50).WithMessage("La contraseña no puede tener más de 50 caracteres.");
    }
}
