var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddSingleton<ILogger>(sp =>
    sp.GetRequiredService<ILoggerFactory>().CreateLogger("Default"));

builder.Services.AddMemoryCache();
builder.Services.AddHostedService<PiGrow.Services.MqttClientService>();
builder.Services.AddHostedService<PiGrow.Services.ConditionCheckerService>();
builder.Services.AddHostedService<PiGrow.Services.ArduinoService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
