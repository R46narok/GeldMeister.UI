using GeldMeisterClient.Clients.Bank;
using GeldMeisterClient.Clients.Statement;
using GeldMeisterClient.Clients.User;
using GeldMeisterClient.Services.Bank;
using GeldMeisterClient.Services.Statement;
using GeldMeisterClient.Services.User.Authentication;
using GeldMeisterClient.Services.User.Management;
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
builder.Services
    .AddRefitClient<IAccountManagementClient>()
    .ConfigureHttpClient(x => x.BaseAddress = new Uri(builder.Configuration["Services:Users"]));
builder.Services
    .AddRefitClient<IBankClient>()
    .ConfigureHttpClient(x => x.BaseAddress = new Uri(builder.Configuration["Services:Banks"]));
builder.Services
    .AddRefitClient<IStatementClient>()
    .ConfigureHttpClient(x => x.BaseAddress = new Uri(builder.Configuration["Services:Banks"]));
builder.Services.AddScoped<TokenAuthenticationStateProvider, TokenAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<AccountManagementService, AccountManagementService>();
builder.Services.AddScoped<IAccountManagementService, AccountManagementService>();
builder.Services.AddScoped<BankService, BankService>();
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<StatementService, StatementService>();
builder.Services.AddScoped<IStatementService, StatementService>();
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