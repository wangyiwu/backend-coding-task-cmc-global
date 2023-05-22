using Application.Models.RequestModel.Ship;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Validatation;

public class CreateShipRequestValidator: AbstractValidator<CreateShipRequest>
{
    public CreateShipRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Velocity).NotEmpty();
    }
}
