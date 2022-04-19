using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Presentation.Data;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;
var SQLConn = new SQLConnConfig(Configuration.GetConnectionString("DefaultConnection"));

// Add services to the container.
builder.Services.AddSingleton<SQLConnConfig>(SQLConn);
builder.Services.AddServerSideBlazor(X => X.DetailedErrors = true);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

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
