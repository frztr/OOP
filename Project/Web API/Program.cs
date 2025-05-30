
using System.Text.Json.Serialization;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Global;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services
.AddDbContext<AppDbContext>(ServiceLifetime.Transient)
.AddScoped<IPostService,PostService>()
.AddTransient<IPostRepository, PostRepository>()
.AddScoped<IFriendshipsStatusService,FriendshipsStatusService>()
.AddTransient<IFriendshipsStatusRepository, FriendshipsStatusRepository>()
.AddScoped<IUserService,UserService>()
.AddTransient<IUserRepository, UserRepository>()
.AddScoped<IMessageService,MessageService>()
.AddTransient<IMessageRepository, MessageRepository>()
.AddScoped<ICommentLikeService,CommentLikeService>()
.AddTransient<ICommentLikeRepository, CommentLikeRepository>()
.AddScoped<IRoleService,RoleService>()
.AddTransient<IRoleRepository, RoleRepository>()
.AddScoped<ICommentService,CommentService>()
.AddTransient<ICommentRepository, CommentRepository>()
.AddScoped<ICountryService,CountryService>()
.AddTransient<ICountryRepository, CountryRepository>()
.AddScoped<IPostLikeService,PostLikeService>()
.AddTransient<IPostLikeRepository, PostLikeRepository>()
.AddScoped<ICityService,CityService>()
.AddTransient<ICityRepository, CityRepository>()
.AddScoped<IFriendshipsService,FriendshipsService>()
.AddTransient<IFriendshipsRepository, FriendshipsRepository>();

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