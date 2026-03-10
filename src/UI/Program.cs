using Application.Interfaces.RestEase;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MudBlazor.Services;
using RestEase.HttpClientFactory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var apiBaseUrl = (builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5089").TrimEnd('/') + "/";

builder.Services.AddHttpClient("DemoApi")
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiBaseUrl))
    .UseWithRestEaseClient<IConfigApi>()
    .UseWithRestEaseClient<IRealtimeApi>();

builder.Services.AddMudServices();

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
