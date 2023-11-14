using Agenda.Application.Agenda.Services;
using Agenda.Domain.Agendas.Repository;
using Agenda.Infrastructure.Context;
using Agenda.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Agenda.Application.ConfigurationModule).Assembly);


builder.Services.AddDbContext<AgendaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AgenteApi"));
});

builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();
builder.Services.AddScoped<ICompromissoRepository, CompromissoRepository>();

builder.Services.AddScoped<IContatoService, ContatoService>();
builder.Services.AddScoped<IAgendaService, AgendaService>();
builder.Services.AddScoped<ICompromissoService, CompromissoService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
