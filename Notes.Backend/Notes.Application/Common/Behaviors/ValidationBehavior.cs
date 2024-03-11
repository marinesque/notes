using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;

namespace Notes.Application.Common.Behaviors
{
    //Чтобы валидация работала, нужно встроитьб ее в пайплпайн медиатора
    //Схожий паттерн как фильтры в ASP.NET MVC
    //Когда нужно внести в приложение логику, которая должна отрабатывать до вызова действий контроллера
    //Реализуем метод IPipelineBehavior.Handle
    //request - объект запроса, переданный через IMediatr.Send
    //next - асинхронное продолжение для следующего действия в цепочке вызова нашего Behavior
    //Делегат next не принимает TRequest в качестве входного параметра, то мы можем изменять входной запрос, но не заменять его
    //Если есть ошибки - выводим. Если нет - идем дальше
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();
            
            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }

            return next();
        }
    }
}