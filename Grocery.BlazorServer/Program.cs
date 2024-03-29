using Grocery.Business.Data;
using Grocery.BlazorServer.Services;
using Grocery.Infrastructure;
using Grocery.Infrastructure.EF;
using Grocery.UI.Services;
using Microsoft.EntityFrameworkCore;

// using Microsoft.AspNetCore.Components;
// using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IDataService,DataService>();

builder.Services.AddDbContext<ERPDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Grocery.BlazorServer")
        );
});
builder.Services.AddScoped<DbContext, ERPDbContext>();
builder.Services.AddScoped( typeof(IRepository<,>), typeof(EFRepository<,>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
