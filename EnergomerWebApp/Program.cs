using EnergomerWebApp.Domain.Service;
using EnergomerWebApp.Domain.Service.Impl;
using EnergomerWebApp.Infrastructure.Repository;
using EnergomerWebApp.Infrastructure.Repository.Impl;

namespace EnergomerWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<Application.Services.IFieldService, Application.Services.Impl.FieldService>();
            builder.Services.AddScoped<Domain.Service.IFieldService, Domain.Service.Impl.FieldService>();
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
