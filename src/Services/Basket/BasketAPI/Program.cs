



using Microsoft.AspNetCore.Diagnostics.HealthChecks;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));

});
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly); //FluentValidation for DI
builder.Services.AddHealthChecks().AddNpgSql(builder.Configuration.GetConnectionString("Database")); //register postgresql healthcheck with .net healthcheck container
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database"));
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);
}).UseLightweightSessions();

var app = builder.Build();

app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    }
);

app.MapCarter();

app.Run();