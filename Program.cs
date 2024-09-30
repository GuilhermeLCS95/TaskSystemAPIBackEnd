
using Microsoft.EntityFrameworkCore;
using TaskSystemAPIBackEnd.Data;
using TaskSystemAPIBackEnd.Repositories;
using TaskSystemAPIBackEnd.Repositories.Interfaces;

namespace TaskSystemAPIBackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Configurar o SQL Server
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<TaskSystemDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));


            //Configurar dependências
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();


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
