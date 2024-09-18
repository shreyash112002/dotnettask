using Microsoft.Extensions.FileProviders;
using Npgsql;
using DotnetTask.DAO;
namespace DotnetTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("PostgreDB");
            builder.Services.AddScoped((provider) => new NpgsqlConnection(connectionString));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAny", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
                options.AddPolicy("FrontEndClient", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
                .WithOrigins("http://localhost:3000"));
            });
            builder.Services.AddScoped<IUserDaoImp, UserDaoImp>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
               Path.Combine(builder.Environment.ContentRootPath, "Images")),
                RequestPath = "/Image"
            });
            app.UseCors("AllowAny");
            app.UseCors("FrontEndClient");
          
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
