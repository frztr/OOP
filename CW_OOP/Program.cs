using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Global;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
.AddDbContext<AppDbContext>()
.AddTransient<Role.IService,Role.Service>()
.AddScoped<Role.IRepository, Role.Repository>()
// .AddTransient<IService<short,AddUserDto,UpdateUserDto,UserEntityDto>,UserService>()
// .AddScoped<IRepository<short,AddRoleDto,UpdateRoleDto,RoleEntityDto>,RoleRepository>()
// .AddScoped<IRepository<short,AddUserDto,UpdateUserDto,UserEntityDto>,UserRepository>()
;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = "AMS",
            ValidAudience = "AMSClient",
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("iDoBMJaATeQ4kW0g2Cj40d7ujuRWLygj")),
            ValidateIssuerSigningKey = true
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

