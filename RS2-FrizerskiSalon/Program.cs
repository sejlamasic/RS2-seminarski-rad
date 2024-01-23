using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RS2_FrizerskiSalon.Configuration;
using RS2_FrizerskiSalon.Database;
using RS2_FrizerskiSalon.Extensions;
using RS2_FrizerskiSalon.Services;
using System.Text;
using Microsoft.AspNetCore.Cors;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<FrizerskiStudioRsiiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        var config = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = ctx =>
            {
                if (ctx.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    ctx.Response.Headers.Add("Token-Expired", "true");
                }
                ctx.Response.Headers["Content-Type"] = "application/json";
                ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                ctx.Fail("Expired token");
                return ctx.Response.WriteAsync(JsonConvert.SerializeObject(new { message = "Unauthorized" }));
            }
        };
    });

builder.Services.AddAutoMapper(typeof(IKlijentService));


builder.Services.AddTransient<IKlijentService, KlijentService>();
builder.Services.AddTransient<IUposlenikService, UposlenikService>();
builder.Services.AddTransient<IReadService<FrizerskiSalon.Modal.Spol, object>, BaseReadService<FrizerskiSalon.Modal.Spol, Spol, object>>();
builder.Services.AddTransient<IReadService<FrizerskiSalon.Modal.Zanimanje, object>, BaseReadService<FrizerskiSalon.Modal.Zanimanje, Zanimanje, object>>();
builder.Services.AddTransient<IReadService<FrizerskiSalon.Modal.TipProizvodum, object>, BaseReadService<FrizerskiSalon.Modal.TipProizvodum, TipProizvodum, object>>();
builder.Services.AddTransient<IProizvodService, ProizvodService>();
builder.Services.AddTransient<IIzvjestajService, IzvjestajService>();
builder.Services.AddTransient<IObavijestService, ObavijestService>();
builder.Services.AddTransient<IReadService<FrizerskiSalon.Modal.TipTermina, object>, BaseReadService<FrizerskiSalon.Modal.TipTermina, TipTermina, object>>();
builder.Services.AddTransient<IStavkePortfoliumService, StavkePortfoliumService>();
builder.Services.AddTransient<ITerminService, TerminService>();
builder.Services.AddTransient<IPortfolioService, PortfolioService>();
builder.Services.AddTransient<IStavkeNarudzbeService, StavkeNarudzbeService>();
builder.Services.AddTransient<INarudzbaService, NarudzbaService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger<Program>();

    try
    {
        var ctx = scope.ServiceProvider.GetRequiredService<FrizerskiStudioRsiiContext>();
        ctx.MigrateAndSeedDatabase();
    }
    catch (Exception ex)
    {
        logger.LogCritical(ex, ex.Message);
        return;
    }
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

