
using MedLab.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MedLab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<MedLabDatabaseContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MedLabDBContext")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


            builder.Services.AddAuthorization();
            builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<MedLabDatabaseContext>();

/*            builder.Services
                 .AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                 .AddEntityFrameworkStores<MedLabDatabaseContext>()
                 .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key!"]))
                    };
                });

            builder.Services.AddAuthorization(Options =>
            {
                Options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
                Options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));

            });*/

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.MapIdentityApi<IdentityUser>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            /*app.UseAuthentication();*/


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
