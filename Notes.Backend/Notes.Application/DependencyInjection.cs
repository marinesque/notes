using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Notes.Application
{
    //У медиатора есть свой метод расширения для добавления самого себя
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}