using EnergomerWebApp.Application.Services;
using EnergomerWebApp.Application.Services.Impl;
using EnergomerWebApp.Infrastructure;
using EnergomerWebApp.Infrastructure.Impl;

namespace EnergomerWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<IFieldService, FieldService>();
            builder.Services.AddTransient<ICalculationService, CalculationService>();

            builder.Services.AddSingleton<IRepository<Database.Xml.Centroids.kml>, CentroidRepository>();
            builder.Services.AddSingleton<IRepository<Database.Xml.Fields.kml>, FieldRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
