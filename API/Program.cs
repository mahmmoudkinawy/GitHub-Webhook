var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<WebhookEventProcessor, GitHubWebhookService>();

builder.Services.AddDbContext<WebhookDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGitHubWebhooks();
});

app.Run();
