using Application.Interfaces.RestEase;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RestEase.HttpClientFactory;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRadzenComponents();

var apiBaseUrl = (builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5089").TrimEnd('/') + "/";

builder.Services.AddHttpClient("DemoApi")
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiBaseUrl))
    .UseWithRestEaseClient<IConfigApi>()
    .UseWithRestEaseClient<IRealtimeApi>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
