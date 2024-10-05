﻿using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands
{
    public class StreamerCommandValidator
        : AbstractValidator<StreamerCommand>
    {
        public StreamerCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} no puede execeder los 50 caracteres");

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("{Url} no puede estar en blanco");
        }
    }
}
