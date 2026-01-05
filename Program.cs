using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MicroservicesIntermediateStorage.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace MicroservicesIntermediateStorage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Register Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register EF Core DbContext with SQL Server connection string and TrustServerCertificate option
            builder.Services.AddDbContext<Data.BankingDbContext>(options =>
            {
                var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DefaultConnection"))
                {
                    TrustServerCertificate = true
                };
                options.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
            });

            // Register application services
builder.Services.AddScoped<IIntermediateStorageService, IntermediateStorageService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ITransactionService, TransactionService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

            app.MapControllers();

            // Set the application to listen on port 2304
            app.Urls.Clear();
            app.Urls.Add("http://localhost:2304");

            app.Run();
        }
    }
}
