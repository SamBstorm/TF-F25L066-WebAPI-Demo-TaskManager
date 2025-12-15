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

            #region ADO.net
            //// Génération de la connection en Base de données
            //builder.Services.AddScoped<DbConnection>(context => new SqlConnection(configuration.GetConnectionString("TaskManager.Database")));

            //// Service de la DAL en ADO
            //builder.Services.AddScoped<IUserRepository<DAL.Entities.User>, DAL.Services.UserService>();
            #endregion

            #region EFCore
            ////Génération d'un DbContext lié à la Base de données
            builder.Services.AddDbContext<EF.TaskManagerDbContext>(context =>
                new EF.TaskManagerDbContext(
                    configuration.GetConnectionString("TaskManager.EntityFramework")!
                    ));

            //// Service de la DAL en EFCore
            builder.Services.AddScoped<IUserRepository<DAL.Entities.User>, EF.Services.UserService>();
            #endregion

            #region FakeService
            //// Pas de base de données => Directement injecter le FakeService comme Service de la DAL
            //builder.Services.AddScoped<IUserRepository<DAL.Entities.User>, DAL.Services.ApiKeyFakeService>();
            #endregion

            builder.Services.AddScoped<IUserRepository<BLL.Entities.User>, BLL.Services.UserService>();

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
