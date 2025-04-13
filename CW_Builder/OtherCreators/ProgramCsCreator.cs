using System;

public class ProgramCsCreator
{
    public static string Create(Entity[] entities)
    {
        return $@"
using System.Text.Json.Serialization;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Global;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services
.AddDbContext<AppDbContext>(ServiceLifetime.Transient)
{String.Join("\n", entities.Select(x => $@".AddScoped<I{x.Name}Service,{x.Name}Service>()
.AddTransient<I{x.Name}Repository, {x.Name}Repository>()"))};

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {{options.TokenValidationParameters = new TokenValidationParameters
        {{
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = AppConfig.ISSUER,
            ValidAudience = AppConfig.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConfig.KEY)),
            ValidateIssuerSigningKey = true
        }};
}});
builder.Services.AddLogging(builder =>
{{
    builder.SetMinimumLevel(LogLevel.Trace);
}});
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.ConfigureHttpJsonOptions(opts =>{{
    opts.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
}});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{{
    app.UseSwagger();
    app.UseSwaggerUI();
}}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();";
    }
}
// ""J9gGkPrHnbT6rZHjkiaGLvFpRGkEMMDr""

// ""{new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz", 32)
        // .Select(s => s[new Random().Next(62)]).ToArray())}""