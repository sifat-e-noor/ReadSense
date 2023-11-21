using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ReadSenseApi.Authorization;
using ReadSenseApi.Database;
using ReadSenseApi.Helpers;
using ReadSenseApi.Services;
using ReadSenseApi.SignalRHubs;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(opts =>
{
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
});

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is null)
{
    throw new Exception("SQL Server Connection string is null");
}

builder.Services.AddDbContext<ReadSenseDBContext>(options => options.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "ReadSense API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    
    // Set the comments path for the Swagger JSON and UI
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    option.IncludeXmlComments(xmlPath);
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddAutoMapper(typeof(Program));


// configure DI for application services
builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEnvironmentService, EnvironmentService>();
builder.Services.AddScoped<IReadSettingsService, ReadSettingsService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IScrollingEventService, ScrollingEventService>();
builder.Services.AddScoped<IDataDownloadService, DataDownloadService>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["AppSettings:Secret"]!)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };

    // Sending the access token in the query string is required when using WebSockets or ServerSentEvents
    // due to a limitation in Browser APIs. We restrict it to only calls to the
    // SignalR hub in this code.
    // See https://docs.microsoft.com/aspnet/core/signalr/security#access-token-logging
    // for more information about security considerations when using
    // the query string to transmit the access token.
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];

            // If the request is for our hub...
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) &&
                (path.StartsWithSegments("/hub")))
            {
                // Read the token out of the query string
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});
builder.Services.AddSingleton<IUserIdProvider, EmailBasedUserIdProvider>();

var app = builder.Build();

// Ensure the database is created.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ReadSenseDBContext>();
    await context.Database.MigrateAsync();
}

// global cors policy
var clientUrlSection = app.Configuration.GetSection("AppSettings:ClientUrl") ?? throw new Exception("Client URL is null");
var clientUrls = clientUrlSection.Get<string[]>() ?? throw new Exception("Client URL is null");
app.UseCors(x =>x.WithOrigins(clientUrls)
     .AllowAnyMethod()
     .AllowAnyHeader()
     .AllowCredentials());


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapHub<ScrollEventHub>("/hub");
app.MapControllers();

// default page
app.UseMiddleware<DefaultPageMiddleware>();

app.Run();
