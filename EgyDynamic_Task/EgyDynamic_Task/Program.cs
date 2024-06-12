
using EgyDynamic_Task.Config;
using EgyDynamic_Task.Models;
using EgyDynamic_Task.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EgyDynamic_Task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //////// TO Open The Cors for the other domains:
            /// 1)
            string txt = "";


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //////// DB
            builder.Services.AddDbContext<EgyDynamic_TaskContext>(
                op => op.UseSqlServer(builder.Configuration.GetConnectionString("con")));


            /// 2)
            builder.Services.AddCors(option =>
            {
                option.AddPolicy(txt, builder => {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });


            /// For generic repo:
            builder.Services.AddScoped<UOW>();


            /// For Auto Mapper:
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);


            /// For token validation:
            builder.Services.AddAuthentication(option => option.DefaultAuthenticateScheme = "myscheme")
                .AddJwtBearer("myscheme",
                op =>
                {
                    string key = "Employee login Key string for security";
                    var secertkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
                    op.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = secertkey,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                }
                );


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            /// 3)
            app.UseCors(txt);


            app.MapControllers();

            app.Run();
        }
    }
}
