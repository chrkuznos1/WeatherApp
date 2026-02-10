//this added got azure keyvault--this is 1st addition
using Azure.Identity;
using System;
using WeatherApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register weather service
builder.Services.AddHttpClient<IWeatherService, WeatherService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddHealthChecks();

// Add Azure Key Vault-this is 2nd addition
//var keyVaultUrl = new Uri($"https://chrkuznosweatherapp-kv.vault.azure.net/");

 /*  before with info from appsettings.json 
var keyVaultUrl = new Uri(builder.Configuration["AzureKeyVault:Url"]);
builder.Configuration.AddAzureKeyVault(keyVaultUrl, new DefaultAzureCredential());
*/

// Read Key Vault URL from environment variable
var keyVaultUrl = Environment.GetEnvironmentVariable("KEYVAULT_URL"); 
if (!string.IsNullOrEmpty(keyVaultUrl)) 
{
 builder.Configuration.AddAzureKeyVault( new Uri(keyVaultUrl), new DefaultAzureCredential()
 ); 
 }



// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

// Add a simple health check endpoint
app.MapGet("/", () => "Weather API is running! Visit /swagger for API documentation.");

app.Run();
