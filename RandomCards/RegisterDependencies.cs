﻿using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using RandomCards.Data;
using RandomCards.Repositories.CardRepository;

namespace RandomCards
{
    public static class RegisterDependencies
    {
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
        }
    }


}
