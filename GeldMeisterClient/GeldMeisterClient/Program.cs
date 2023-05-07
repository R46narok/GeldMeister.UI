using GeldMeisterClient.Clients;
using GeldMeisterClient.Services.User.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services
    .AddRefitClient<IAuthenticationClient>()
    .ConfigureHttpClient(x => x.BaseAddress = new Uri(builder.Configuration["Services:Users"]));
builder.Services
    .AddRefitClient<IAuthorizationClient>()
    .ConfigureHttpClient(x => x.BaseAddress = new Uri(builder.Configuration["Services:Users"]));
builder.Services.AddScoped<TokenAuthenticationStateProvider, TokenAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddAuthenticationCore();
builder.Services.AddAuthorizationCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();