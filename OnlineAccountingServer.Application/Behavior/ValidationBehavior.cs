using FluentValidation;
using FluentValidation.Results;
using MediatR;
using OnlineAccountingServer.Application.Messaging;
using System.Reflection.Metadata.Ecma335;

namespace OnlineAccountingServer.Application.Behavior
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class, ICommand<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())  // Validator listemde herhangi bir validator yoksa o zaman await ile beraber next diyerek işlemimizi devam ettirsin. Bir sonraki işleme geçirsin
            {
                return await next();
            }
            // Eğer validator varsa;  yani request'ime ait validator   varsa yapıyı kontrol ettirip validationContext oluşturuyorum.
            var context = new ValidationContext<TRequest>(request);

            // Validasyon kurallarına takılan tüm errorları yakalayıp, error listesi olusturalim.
            var errorDictionary = _validators.Select(x => x.Validate(context)).SelectMany(x => x.Errors).Where(x => x != null)
                .GroupBy(x=>x.PropertyName,x=>x.ErrorMessage, (propertyName, errorMessage) => new
                {
                    Key = propertyName,
                    Values = errorMessage.Distinct().ToArray() 
                })
                .ToDictionary(x=>x.Key, x => x.Values[0]);

            if (errorDictionary.Any()) // errordictionary'de herhangi bir kayıt varsa 
            {
                var errors = errorDictionary.Select(s=> new ValidationFailure
                {
                    PropertyName = s.Value,
                    ErrorCode = s.Key
                });
                throw new ValidationException(errors);
            }
            return await next();
        }
    }
}
