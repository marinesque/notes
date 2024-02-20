using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Interfaces;

namespace Notes.Persistence
{
    public static class DependencyInjection
    {
        //Создаем метод расширения для добавления и регистрации контекста бд
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<NotesDBContext>(options => { options.UseSqlite(connectionString); });
            services.AddScoped<INotesDBContext>(provider => provider.GetService<NotesDBContext>());
            return services;
        }
    }
}