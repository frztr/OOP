
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Global;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services
.AddDbContext<AppDbContext>(ServiceLifetime.Transient)
.AddScoped<IVehicleService,VehicleService>()
.AddTransient<IVehicleRepository, VehicleRepository>()
.AddScoped<IMileageMeasurementHistoryService,MileageMeasurementHistoryService>()
.AddTransient<IMileageMeasurementHistoryRepository, MileageMeasurementHistoryRepository>()
.AddScoped<IRefuelingHistoryService,RefuelingHistoryService>()
.AddTransient<IRefuelingHistoryRepository, RefuelingHistoryRepository>()
.AddScoped<IOilTypeService,OilTypeService>()
.AddTransient<IOilTypeRepository, OilTypeRepository>()
.AddScoped<IRepairConsumedSparePartService,RepairConsumedSparePartService>()
.AddTransient<IRepairConsumedSparePartRepository, RepairConsumedSparePartRepository>()
.AddScoped<IMaintenanceHistoryService,MaintenanceHistoryService>()
.AddTransient<IMaintenanceHistoryRepository, MaintenanceHistoryRepository>()
.AddScoped<IFuelMeasurementHistoryService,FuelMeasurementHistoryService>()
.AddTransient<IFuelMeasurementHistoryRepository, FuelMeasurementHistoryRepository>()
.AddScoped<IPlannedMaintenanceScheduleService,PlannedMaintenanceScheduleService>()
.AddTransient<IPlannedMaintenanceScheduleRepository, PlannedMaintenanceScheduleRepository>()
.AddScoped<IVehiclePhotoService,VehiclePhotoService>()
.AddTransient<IVehiclePhotoRepository, VehiclePhotoRepository>()
.AddScoped<IManufacturerService,ManufacturerService>()
.AddTransient<IManufacturerRepository, ManufacturerRepository>()
.AddScoped<IVehicleStatusService,VehicleStatusService>()
.AddTransient<IVehicleStatusRepository, VehicleStatusRepository>()
.AddScoped<IVehicleModelService,VehicleModelService>()
.AddTransient<IVehicleModelRepository, VehicleModelRepository>()
.AddScoped<ISparePartService,SparePartService>()
.AddTransient<ISparePartRepository, SparePartRepository>()
.AddScoped<IRoleService,RoleService>()
.AddTransient<IRoleRepository, RoleRepository>()
.AddScoped<IVehicleCategoryService,VehicleCategoryService>()
.AddTransient<IVehicleCategoryRepository, VehicleCategoryRepository>()
.AddScoped<IMaintenanceTypeService,MaintenanceTypeService>()
.AddTransient<IMaintenanceTypeRepository, MaintenanceTypeRepository>()
.AddScoped<IVehicleDocumentService,VehicleDocumentService>()
.AddTransient<IVehicleDocumentRepository, VehicleDocumentRepository>()
.AddScoped<IDriverService,DriverService>()
.AddTransient<IDriverRepository, DriverRepository>()
.AddScoped<IUserService,UserService>()
.AddTransient<IUserRepository, UserRepository>()
.AddScoped<IFuelTypeService,FuelTypeService>()
.AddTransient<IFuelTypeRepository, FuelTypeRepository>()
.AddScoped<IRepairHistoryService,RepairHistoryService>()
.AddTransient<IRepairHistoryRepository, RepairHistoryRepository>()
.AddScoped<IDocumentTypeService,DocumentTypeService>()
.AddTransient<IDocumentTypeRepository, DocumentTypeRepository>()
.AddScoped<IAutomechanicService,AutomechanicService>()
.AddTransient<IAutomechanicRepository, AutomechanicRepository>();

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