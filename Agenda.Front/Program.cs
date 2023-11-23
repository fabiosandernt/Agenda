using Agenda.Application;
using Agenda.Application.Account.Services;
using Agenda.Application.Account.Services.JwtServices;
using Agenda.Application.Agenda.Services;
using Agenda.Domain.Agendas.Repository;
using Agenda.Infrastructure.Context;
using Agenda.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddAutoMapper(typeof(Agenda.Application.ConfigurationModule).Assembly);
        builder.Services
                .RegisterApplication(builder.Configuration);




        builder.Services.AddDbContext<AgendaContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("AgendaApi"));
        });

        builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
        builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();
        builder.Services.AddScoped<ICompromissoRepository, CompromissoRepository>();
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        builder.Services.AddScoped<IUsuarioService, UsuarioService>();
        builder.Services.AddScoped<IContatoService, ContatoService>();
        builder.Services.AddScoped<IAgendaService, AgendaService>();
        builder.Services.AddScoped<ICompromissoService, CompromissoService>();

        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IJwtService, JwtService>();




        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();

    }
    //public void ConfigureServices(this IServiceCollection services,
    //IConfiguration configuration)
    //{
    //    services.AddAuthentication(x =>
    //    {
    //        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    //        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //    }).AddJwtBearer(x =>
    //    {
    //        x.TokenValidationParameters = new TokenValidationParameters
    //        {
    //            ValidateIssuerSigningKey = true,
    //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JwtSecurity:SecurityKey"])),
    //            ValidateIssuer = false,
    //            ValidateAudience = false,
    //            ValidateLifetime = true
    //        };
    //    });

    //}
}
