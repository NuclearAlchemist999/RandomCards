using Microsoft.EntityFrameworkCore;
using RandomCards.Data;
using RandomCards.Repositories.CardRepository;
using RandomCards.Services.CardService;

namespace RandomCards
{
    public static class RegisterDependencies
    {
        /// <summary>
        /// This exists to make the Program cleaner.
        /// </summary>
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
#if DEBUG
            var connectionString = configuration["ConnectionStrings:RandomCards"];
#else
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
#endif
            services.AddDbContext<CardDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICardService, CardService>();
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
#if DEBUG
            var origin = "http://127.0.0.1:5173/";
#else
            var origin = "https://randomcardsgame.onrender.com";
#endif
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .WithOrigins(origin);
                });
            });
        }
    }
}
