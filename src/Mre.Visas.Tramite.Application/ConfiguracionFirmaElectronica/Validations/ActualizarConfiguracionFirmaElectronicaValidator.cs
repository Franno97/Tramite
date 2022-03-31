using FluentValidation;
using Mre.Visas.Tramite.Domain.Entities;

namespace Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Commands
{
    public class ActualizarConfiguracionFirmaElectronicaValidator : AbstractValidator<ActualizarConfiguracionFirmaElectronicaCommand>
    {
        public ActualizarConfiguracionFirmaElectronicaValidator()
        {
            RuleFor(e => e.ServicioId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

            RuleFor(e => e.TipoDocumentoCodigo)
                           .NotEmpty().WithMessage("{PropertyName} es requerido.")
                           .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

            RuleFor(e => e.ModeloFirma)
                           .NotEmpty().WithMessage("{PropertyName} es requerido.")
                           .NotNull().WithMessage("{PropertyName} no puede ser nulo.")
                           .IsEnumName(typeof(ModeloFirma), caseSensitive: false).WithMessage("El valor {PropertyValue} no es permitido para {PropertyName}.")
                           ;


            RuleFor(e => e.TamanioFirma)
                          .NotEmpty().WithMessage("{PropertyName} es requerido.")
                          .NotNull().WithMessage("{PropertyName} no puede ser nulo.")
                         .InclusiveBetween(1, 5).WithMessage("{PropertyName} debe tener valores de {From} a {To}")
            ;


            RuleFor(e => e.NumeroPagina)
                      .NotEmpty().WithMessage("{PropertyName} es requerido.")
                      .NotNull().WithMessage("{PropertyName} no puede ser nulo.")
                      .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor de 0.")
            ;

            RuleFor(e => e.PosicionX)
                               .NotEmpty().WithMessage("{PropertyName} es requerido.")
                               .NotNull().WithMessage("{PropertyName} no puede ser nulo.");


            RuleFor(e => e.PosicionY)
                                         .NotEmpty().WithMessage("{PropertyName} es requerido.")
                                         .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

        }
    }
}
