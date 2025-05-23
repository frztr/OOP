
using System.Text.Json.Serialization;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Global;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services
.AddDbContext<AppDbContext>(ServiceLifetime.Transient)
.AddScoped<IPaymentService,PaymentService>()
.AddTransient<IPaymentRepository, PaymentRepository>()
.AddScoped<IUserService,UserService>()
.AddTransient<IUserRepository, UserRepository>()
.AddScoped<IBookingService,BookingService>()
.AddTransient<IBookingRepository, BookingRepository>()
.AddScoped<IEventCategoryService,EventCategoryService>()
.AddTransient<IEventCategoryRepository, EventCategoryRepository>()
.AddScoped<IBookingStatusService,BookingStatusService>()
.AddTransient<IBookingStatusRepository, BookingStatusRepository>()
.AddScoped<IEventService,EventService>()
.AddTransient<IEventRepository, EventRepository>()
.AddScoped<IPaymentStatusService,PaymentStatusService>()
.AddTransient<IPaymentStatusRepository, PaymentStatusRepository>()
.AddScoped<IRoleService,RoleService>()
.AddTransient<IRoleRepository, RoleRepository>()
.AddScoped<IReviewService,ReviewService>()
.AddTransient<IReviewRepository, ReviewRepository>()
.AddScoped<ILocationService,LocationService>()
.AddTransient<ILocationRepository, LocationRepository>()
.AddScoped<IPaymentMethodService,PaymentMethodService>()
.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = AppConfig.ISSUER,
            ValidAudience = AppConfig.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConfig.KEY)),
            ValidateIssuerSigningKey = true
        };
});
builder.Services.AddLogging(builder =>
{
    builder.SetMinimumLevel(LogLevel.Trace);
});
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.ConfigureHttpJsonOptions(opts =>{
    opts.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();