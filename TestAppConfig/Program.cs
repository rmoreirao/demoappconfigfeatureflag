using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

// Get connection string for Azure App Configuration.
string? connectionString = builder.Configuration.GetConnectionString("AppConfig");

// Set connection string and cache expiration interval for feature flags
builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(connectionString)
        .UseFeatureFlags(featureFlagOptions => {
            featureFlagOptions.CacheExpirationInterval = TimeSpan.FromSeconds(10);
        });
});

// Add Azure App Configuration to the container of services.
builder.Services.AddAzureAppConfiguration();

// Add feature management to the container of services.
builder.Services.AddFeatureManagement();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.Configure<Settings>(builder.Configuration.GetSection("TestApp:Settings"));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Add App Configuration - this will enable the dynamic configuration of feature flags.
app.UseAzureAppConfiguration();

app.MapRazorPages();

app.Run();
