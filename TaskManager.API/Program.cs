using Microsoft.Data.SqlClient;
using System.Data.Common;
using TaskManager.API.Handlers.RouteConstraints;
using TaskManager.Common.Repositories;

namespace TaskManager.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration configuration = builder.Configuration;
            // Add services to the container.

            builder.Services.AddScoped<DbConnection>(context => new SqlConnection(configuration.GetConnectionString("TaskManager.Database")));

            //FakeSerives
            builder.Services.AddScoped<DAL.Services.ApiKeyFakeService>();

            //DB Services
            builder.Services.AddScoped<IUserRepository<BLL.Entities.User>, BLL.Services.UserService>();
            builder.Services.AddScoped<IUserRepository<DAL.Entities.User>, DAL.Services.UserService>();

            //Route configuration
            builder.Services.Configure<RouteOptions>(options => {
                options.ConstraintMap.Add("key", typeof(ApiKeyRouteConstraint));
            });

            //Base configuration
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
