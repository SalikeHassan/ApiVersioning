using Microsoft.AspNetCore.Mvc.Versioning;

namespace Tutorial.ApiVersioning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //Code for api versioning
            builder.Services.AddApiVersioning(opt =>
            {
                //Code to setup api versioning
                opt.ReportApiVersions = true;
                opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;

                //Code to setup header api versioning
               // opt.ApiVersionReader = new HeaderApiVersionReader("X-API-Version");

            });

            //Code to fix the swagger while using multiple version of api
            //Install package Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
            builder.Services.AddVersionedApiExplorer(opt =>
            {
                opt.GroupNameFormat = "'v'VVV";
                opt.SubstituteApiVersionInUrl = true;
            });

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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}