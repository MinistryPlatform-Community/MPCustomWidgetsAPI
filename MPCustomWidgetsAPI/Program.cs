using Microservices.Interfaces;
using Microservices.Providers;
using MicroServices.Filters;
using MicroServices.Interfaces;
using MicroServices.Providers;
using MicroServices.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Allow Access to Configuration Object
var configuration = builder.Configuration;

var WideOpenPolicy = "WideOpenPolicy";

// Add services to the container.
builder.Services.AddCors(options => {
    options.AddPolicy(name: WideOpenPolicy, policy =>
        policy
            .AllowAnyOrigin()            
            .AllowAnyHeader()
            .AllowAnyMethod());
    }
);

// Disable ModelState
builder.Services.Configure<ApiBehaviorOptions>(options => {
    //options.SuppressModelStateInvalidFilter = true;
});

// Add services to the container.
builder.Services.AddControllers()
    // Added to remove lowercaseing properties
    .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);



// Add APIKey Support
builder.Services.AddScoped<ApiKeyAuthorizationFilter>();
builder.Services.AddScoped<IApiKeyProvider, ApiKeyProvider>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MP Custom Widgets API", Version = "v1", Description = "Custom Widgets API." });
    c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "Microservices.xml"));
    c.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Description = "ApiKey must appear in header",
        In = ParameterLocation.Header,
        Name = "X-API-KEY", //header with api key
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme"
    });

    var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };

    var requirement = new OpenApiSecurityRequirement
    {
        { key, new List<string>() }
    };

    c.AddSecurityRequirement(requirement);
});

// Add HttpContext
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IDomainProvider, DomainProvider>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ICustomWidgetRepository, CustomWidgetRepository>();
builder.Services.AddScoped<ITrackingProvider, TrackingProvider>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

// Add HttpClient
builder.Services.AddHttpClient();
builder.Services.AddApplicationInsightsTelemetry(configuration.GetValue<string>("ApplicationInsights:ConnectionString"));

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


var appRoot = configuration.GetValue<string>("AppRoot");

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
    c.EnableTryItOutByDefault();
    c.InjectStylesheet($"{appRoot}/swagger-ui/custom.css");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
