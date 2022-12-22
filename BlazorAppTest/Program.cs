using BlazorAppTest.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<CustomAuthProvider>();

//BAD
//builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>(p => p.GetRequiredService<CustomAuthProvider>()); //equivalent to below
builder.Services.AddScoped<AuthenticationStateProvider>(p => p.GetRequiredService<CustomAuthProvider>()); //equivalent to above


//GOOD
//builder.Services.TryAddScoped<AuthenticationStateProvider>(p => p.GetRequiredService<CustomAuthProvider>());
//builder.Services.TryAddScoped<CustomAuthProvider>();


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
