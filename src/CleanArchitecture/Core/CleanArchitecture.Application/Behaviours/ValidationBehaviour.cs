using MediatR;
using FluentValidation;

namespace CleanArchitecture.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse>
        (
            IEnumerable<IValidator<TRequest>> validators
        )
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
                return await next();

            ValidationContext<TRequest> context = new(request);
            // Captura cada una de las validaciones
            var validationResults = await Task.WhenAll
                                              (
                                                  _validators.Select(v =>
                                                                  v.ValidateAsync(context, cancellationToken)
                                                             )
                                              );

            var failures = validationResults.SelectMany(r =>
                                                r.Errors
                                            )
                                            .Where(f =>
                                               f is not null
                                            )
                                            .ToList();

            if (failures.Count > 0)
                throw new ValidationException(failures);

            return await next();
        }
    }
}
