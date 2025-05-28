using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "document_type",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fuel_type",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fuel_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "maintenance_type",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenance_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "manufacturer",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "spare_part",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    count_left = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spare_part", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_category",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_status",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oil_type",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    fuel_type_id = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oil_type", x => x.id);
                    table.ForeignKey(
                        name: "FK_oil_type_fuel_type_fuel_type_id",
                        column: x => x.fuel_type_id,
                        principalTable: "fuel_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    fio = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password_hash = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    role_id = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_model",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    manufacturer_id = table.Column<short>(type: "smallint", nullable: false),
                    vehicle_category_id = table.Column<short>(type: "smallint", nullable: false),
                    power = table.Column<short>(type: "smallint", nullable: false),
                    fuel_type_id = table.Column<short>(type: "smallint", nullable: false),
                    load_capacity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_model", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehicle_model_fuel_type_fuel_type_id",
                        column: x => x.fuel_type_id,
                        principalTable: "fuel_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicle_model_manufacturer_manufacturer_id",
                        column: x => x.manufacturer_id,
                        principalTable: "manufacturer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicle_model_vehicle_category_vehicle_category_id",
                        column: x => x.vehicle_category_id,
                        principalTable: "vehicle_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "automechanic",
                columns: table => new
                {
                    user_id = table.Column<short>(type: "smallint", nullable: false),
                    qualification = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_automechanic", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_automechanic_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "driver",
                columns: table => new
                {
                    user_id = table.Column<short>(type: "smallint", nullable: false),
                    driver_license = table.Column<long>(type: "bigint", nullable: false),
                    experience = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driver", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_driver_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vin_number = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: false),
                    plate_number = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    vehiclemodel_id = table.Column<int>(type: "integer", nullable: false),
                    release_year = table.Column<short>(type: "smallint", nullable: false),
                    registration_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status_id = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehicle_vehicle_model_vehiclemodel_id",
                        column: x => x.vehiclemodel_id,
                        principalTable: "vehicle_model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicle_vehicle_status_status_id",
                        column: x => x.status_id,
                        principalTable: "vehicle_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fuel_measurement_history",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    volume = table.Column<decimal>(type: "numeric", nullable: false),
                    measurement_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vehicle_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fuel_measurement_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_fuel_measurement_history_vehicle_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "maintenance_history",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vehicle_id = table.Column<int>(type: "integer", nullable: false),
                    maintenance_type_id = table.Column<short>(type: "smallint", nullable: false),
                    completed_work = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    automechanic_id = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenance_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_maintenance_history_automechanic_automechanic_id",
                        column: x => x.automechanic_id,
                        principalTable: "automechanic",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_maintenance_history_maintenance_type_maintenance_type_id",
                        column: x => x.maintenance_type_id,
                        principalTable: "maintenance_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_maintenance_history_vehicle_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mileage_measurement_history",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    km_count = table.Column<decimal>(type: "numeric", nullable: false),
                    measurement_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vehicle_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mileage_measurement_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_mileage_measurement_history_vehicle_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "planned_maintenance_schedule",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    planned_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    maintenance_type_id = table.Column<short>(type: "smallint", nullable: false),
                    vehicle_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planned_maintenance_schedule", x => x.id);
                    table.ForeignKey(
                        name: "FK_planned_maintenance_schedule_maintenance_type_maintenance_t~",
                        column: x => x.maintenance_type_id,
                        principalTable: "maintenance_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_planned_maintenance_schedule_vehicle_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "refueling_history",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    volume = table.Column<decimal>(type: "numeric", nullable: false),
                    oil_type_id = table.Column<short>(type: "smallint", nullable: false),
                    fuelstation_tin_number = table.Column<long>(type: "bigint", nullable: false),
                    vehicle_id = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    driver_id = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refueling_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_refueling_history_driver_driver_id",
                        column: x => x.driver_id,
                        principalTable: "driver",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_refueling_history_oil_type_oil_type_id",
                        column: x => x.oil_type_id,
                        principalTable: "oil_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_refueling_history_vehicle_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "repair_history",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vehicle_id = table.Column<int>(type: "integer", nullable: false),
                    datetime_begin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    datetime_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    completed_work = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: true),
                    servicestation_tin_number = table.Column<long>(type: "bigint", nullable: true),
                    automechanic_id = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repair_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_repair_history_automechanic_automechanic_id",
                        column: x => x.automechanic_id,
                        principalTable: "automechanic",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK_repair_history_vehicle_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_document",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    doctype_id = table.Column<short>(type: "smallint", nullable: false),
                    src = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    vehicle_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_document", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehicle_document_document_type_doctype_id",
                        column: x => x.doctype_id,
                        principalTable: "document_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicle_document_vehicle_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_photo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    src = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    vehicle_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_photo", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehicle_photo_vehicle_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "repair_consumed_spare_part",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    repair_id = table.Column<int>(type: "integer", nullable: false),
                    spare_part_id = table.Column<int>(type: "integer", nullable: false),
                    part_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repair_consumed_spare_part", x => x.id);
                    table.ForeignKey(
                        name: "FK_repair_consumed_spare_part_repair_history_repair_id",
                        column: x => x.repair_id,
                        principalTable: "repair_history",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_repair_consumed_spare_part_spare_part_spare_part_id",
                        column: x => x.spare_part_id,
                        principalTable: "spare_part",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "name" },
                values: new object[] { (short)1, "admin" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "fio", "login", "password_hash", "role_id" },
                values: new object[] { (short)1, "adm", "admin", "21232F297A57A5A743894A0E4A801FC3", (short)1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_document_type_name",
                table: "document_type",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_driver_driver_license",
                table: "driver",
                column: "driver_license",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fuel_measurement_history_vehicle_id",
                table: "fuel_measurement_history",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_type_name",
                table: "fuel_type",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_maintenance_history_automechanic_id",
                table: "maintenance_history",
                column: "automechanic_id");

            migrationBuilder.CreateIndex(
                name: "IX_maintenance_history_maintenance_type_id",
                table: "maintenance_history",
                column: "maintenance_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_maintenance_history_vehicle_id",
                table: "maintenance_history",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_maintenance_type_name",
                table: "maintenance_type",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_manufacturer_name",
                table: "manufacturer",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mileage_measurement_history_vehicle_id",
                table: "mileage_measurement_history",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_oil_type_fuel_type_id",
                table: "oil_type",
                column: "fuel_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_oil_type_name",
                table: "oil_type",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_planned_maintenance_schedule_maintenance_type_id",
                table: "planned_maintenance_schedule",
                column: "maintenance_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_planned_maintenance_schedule_vehicle_id",
                table: "planned_maintenance_schedule",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_refueling_history_driver_id",
                table: "refueling_history",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "IX_refueling_history_oil_type_id",
                table: "refueling_history",
                column: "oil_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_refueling_history_vehicle_id",
                table: "refueling_history",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_repair_consumed_spare_part_repair_id",
                table: "repair_consumed_spare_part",
                column: "repair_id");

            migrationBuilder.CreateIndex(
                name: "IX_repair_consumed_spare_part_spare_part_id",
                table: "repair_consumed_spare_part",
                column: "spare_part_id");

            migrationBuilder.CreateIndex(
                name: "IX_repair_history_automechanic_id",
                table: "repair_history",
                column: "automechanic_id");

            migrationBuilder.CreateIndex(
                name: "IX_repair_history_vehicle_id",
                table: "repair_history",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_name",
                table: "role",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_spare_part_name",
                table: "spare_part",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_login",
                table: "user",
                column: "login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_role_id",
                table: "user",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_plate_number",
                table: "vehicle",
                column: "plate_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_status_id",
                table: "vehicle",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_vehiclemodel_id",
                table: "vehicle",
                column: "vehiclemodel_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_vin_number",
                table: "vehicle",
                column: "vin_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_category_name",
                table: "vehicle_category",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_document_doctype_id",
                table: "vehicle_document",
                column: "doctype_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_document_src",
                table: "vehicle_document",
                column: "src",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_document_vehicle_id",
                table: "vehicle_document",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_model_fuel_type_id",
                table: "vehicle_model",
                column: "fuel_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_model_manufacturer_id",
                table: "vehicle_model",
                column: "manufacturer_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_model_vehicle_category_id",
                table: "vehicle_model",
                column: "vehicle_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_photo_src",
                table: "vehicle_photo",
                column: "src",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_photo_vehicle_id",
                table: "vehicle_photo",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_status_name",
                table: "vehicle_status",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "fuel_measurement_history");

            migrationBuilder.DropTable(
                name: "maintenance_history");

            migrationBuilder.DropTable(
                name: "mileage_measurement_history");

            migrationBuilder.DropTable(
                name: "planned_maintenance_schedule");

            migrationBuilder.DropTable(
                name: "refueling_history");

            migrationBuilder.DropTable(
                name: "repair_consumed_spare_part");

            migrationBuilder.DropTable(
                name: "vehicle_document");

            migrationBuilder.DropTable(
                name: "vehicle_photo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "maintenance_type");

            migrationBuilder.DropTable(
                name: "driver");

            migrationBuilder.DropTable(
                name: "oil_type");

            migrationBuilder.DropTable(
                name: "repair_history");

            migrationBuilder.DropTable(
                name: "spare_part");

            migrationBuilder.DropTable(
                name: "document_type");

            migrationBuilder.DropTable(
                name: "automechanic");

            migrationBuilder.DropTable(
                name: "vehicle");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "vehicle_model");

            migrationBuilder.DropTable(
                name: "vehicle_status");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "fuel_type");

            migrationBuilder.DropTable(
                name: "manufacturer");

            migrationBuilder.DropTable(
                name: "vehicle_category");
        }
    }
}
