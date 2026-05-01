using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "order");

            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.EnsureSchema(
                name: "error");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliverySettings",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MinDeliveryCharge = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    MaxDeliveryCharge = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    MinParcelCharge = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    MaxParcelCharge = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliverySettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLogs",
                schema: "error",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    Message = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    StackTrace = table.Column<string>(type: "text", nullable: true),
                    FileName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LineNumber = table.Column<int>(type: "integer", nullable: true),
                    StatusCode = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Societies",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Area = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    PinCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    WhatsAppId = table.Column<string>(type: "text", nullable: true),
                    LastActiveAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Role = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Quantity = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PresentCost = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    RevisedCost = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "order",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusinessName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    OwnerName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    WhatsAppNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    LogoUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    AdminUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchants_Users_AdminUserId",
                        column: x => x.AdminUserId,
                        principalSchema: "user",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCredentials",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PasswordSalt = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsBlocked = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCredentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCredentials_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MerchantId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CatalogDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ScheduledPublishAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    WhatsAppMessageTemplate = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogs_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalSchema: "user",
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MerchantSocieties",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MerchantId = table.Column<int>(type: "integer", nullable: false),
                    SocietyId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DeliveryInstructions = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantSocieties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchantSocieties_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalSchema: "user",
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MerchantSocieties_Societies_SocietyId",
                        column: x => x.SocietyId,
                        principalSchema: "user",
                        principalTable: "Societies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderTemplates",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MerchantId = table.Column<int>(type: "integer", nullable: false),
                    TemplateName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    RequireName = table.Column<bool>(type: "boolean", nullable: false),
                    RequireMobile = table.Column<bool>(type: "boolean", nullable: false),
                    RequireFlatVilla = table.Column<bool>(type: "boolean", nullable: false),
                    RequireSociety = table.Column<bool>(type: "boolean", nullable: false),
                    RequireBlock = table.Column<bool>(type: "boolean", nullable: false),
                    RequireWhatsApp = table.Column<bool>(type: "boolean", nullable: false),
                    CustomFieldsJson = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTemplates_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalSchema: "user",
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItems",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CatalogId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: true),
                    ItemName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Quantity = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItems_Catalogs_CatalogId",
                        column: x => x.CatalogId,
                        principalSchema: "order",
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "order",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProfiles",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MerchantSocietyId = table.Column<int>(type: "integer", nullable: false),
                    FullName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    MobileNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    FlatOrVillaNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Block = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    WhatsAppId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LastOrderAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TotalOrders = table.Column<int>(type: "integer", nullable: false),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerProfiles_MerchantSocieties_MerchantSocietyId",
                        column: x => x.MerchantSocietyId,
                        principalSchema: "user",
                        principalTable: "MerchantSocieties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderNumber = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, defaultValue: "Pending"),
                    TotalAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    RawMessage = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ConfirmedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeliveredAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CancelledAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CancellationReason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    MerchantSocietyId = table.Column<int>(type: "integer", nullable: false),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()"),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_MerchantSocieties_MerchantSocietyId",
                        column: x => x.MerchantSocietyId,
                        principalSchema: "user",
                        principalTable: "MerchantSocieties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ItemName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()"),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "order",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatusHistories",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    FromStatus = table.Column<int>(type: "integer", nullable: false),
                    ToStatus = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ChangedByUserId = table.Column<int>(type: "integer", nullable: true),
                    ChangedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderStatusHistories_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "order",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderStatusHistories_Users_ChangedByUserId",
                        column: x => x.ChangedByUserId,
                        principalSchema: "user",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    RazorpayOrderId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RazorpayPaymentId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PaymentLinkId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PaymentLinkUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, defaultValue: "INR"),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValue: "Pending"),
                    PaidAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FailureReason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    RetryCount = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    LinkExpiresAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    AddedByUserId = table.Column<int>(type: "integer", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()"),
                    UpdatedByUserId = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "order",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "order",
                table: "Categories",
                columns: new[] { "Id", "AddedByUserId", "AddedDate", "Name", "UpdatedByUserId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 5, 1, 9, 56, 20, 488, DateTimeKind.Local).AddTicks(2745), "Batters", null, null },
                    { 2, null, new DateTime(2026, 5, 1, 9, 56, 20, 490, DateTimeKind.Local).AddTicks(3041), "Accompaniments", null, null },
                    { 3, null, new DateTime(2026, 5, 1, 9, 56, 20, 490, DateTimeKind.Local).AddTicks(3064), "Ready to Eats", null, null },
                    { 4, null, new DateTime(2026, 5, 1, 9, 56, 20, 490, DateTimeKind.Local).AddTicks(3066), "Tiffin Items", null, null },
                    { 5, null, new DateTime(2026, 5, 1, 9, 56, 20, 490, DateTimeKind.Local).AddTicks(3067), "Podis", null, null },
                    { 6, null, new DateTime(2026, 5, 1, 9, 56, 20, 490, DateTimeKind.Local).AddTicks(3068), "Add Ons", null, null },
                    { 7, null, new DateTime(2026, 5, 1, 9, 56, 20, 490, DateTimeKind.Local).AddTicks(3070), "Sweet & Namkeen", null, null }
                });

            migrationBuilder.InsertData(
                schema: "order",
                table: "DeliverySettings",
                columns: new[] { "Id", "AddedByUserId", "AddedDate", "MaxDeliveryCharge", "MaxParcelCharge", "MinDeliveryCharge", "MinParcelCharge", "UpdatedByUserId", "UpdatedDate" },
                values: new object[] { 1, null, new DateTime(2026, 5, 1, 9, 56, 20, 507, DateTimeKind.Local).AddTicks(801), 40m, 15m, 25m, 5m, null, null });

            migrationBuilder.InsertData(
                schema: "order",
                table: "Products",
                columns: new[] { "Id", "AddedByUserId", "AddedDate", "CategoryId", "Name", "PresentCost", "Quantity", "RevisedCost", "UpdatedByUserId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(6440), 1, "Idly Dosa Batter", 70m, "1 kg", null, null, null },
                    { 2, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9365), 1, "Appam Batter", 100m, "1 kg", null, null, null },
                    { 3, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9373), 1, "4 Millets", 140m, "1 kg", null, null, null },
                    { 4, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9392), 1, "Pesarat Dosa", 120m, "1 kg", null, null, null },
                    { 5, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9393), 1, "Rava Dosa", 100m, "1 kg", null, null, null },
                    { 6, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9395), 1, "Paddu / Paniyaram Batter", 120m, "1 kg", null, null, null },
                    { 7, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9397), 1, "Udin Vada Batter", 100m, "500 gms", null, null, null },
                    { 8, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9399), 1, "Red Rice", 100m, "1 kg", null, null, null },
                    { 9, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9401), 1, "Ragi Dosa", 100m, "1 kg", null, null, null },
                    { 10, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9403), 1, "Banana Stem Batter", 120m, "1 kg", null, null, null },
                    { 11, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9405), 1, "Moringa Dosa", 120m, "1 kg", null, null, null },
                    { 12, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9407), 1, "Palak Dosa Batter", 120m, "1 kg", null, null, null },
                    { 13, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9442), 1, "Peanut Dosa Batter", 120m, "1 kg", null, null, null },
                    { 14, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9445), 1, "Curry Leaf Dosa", 120m, "1 kg", null, null, null },
                    { 15, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9447), 1, "Multi Dhal / Adai Batter", 120m, "1 kg", null, null, null },
                    { 16, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9449), 1, "Garlic Dosa Batter", 120m, "1 kg", null, null, null },
                    { 17, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9451), 1, "Wheat Dosa Batter", 100m, "1 kg", null, null, null },
                    { 18, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9453), 2, "Coconut Chutney", 30m, "100gms", null, null, null },
                    { 19, null, new DateTime(2026, 5, 1, 9, 56, 20, 505, DateTimeKind.Local).AddTicks(9455), 2, "Peanut Chutney", 30m, "100gms", 35m, null, null },
                    { 20, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(4), 2, "Tomato Chutney", 30m, "100gms", 35m, null, null },
                    { 21, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(10), 2, "Garlic Chutney", 35m, "100gms", 40m, null, null },
                    { 22, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(13), 2, "Onion Chutney", 30m, "100gms", 35m, null, null },
                    { 23, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(15), 2, "Mint Chutney", 30m, "100gms", 35m, null, null },
                    { 24, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(17), 2, "Chennai Tiffin Sambar", 30m, "300gms", 35m, null, null },
                    { 25, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(19), 2, "Coconut Milk", 100m, "300gms", null, null, null },
                    { 26, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(49), 2, "Kadala Curry", 100m, "350gms", 105m, null, null },
                    { 27, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(51), 3, "Plain Sevai", 100m, "500gms", null, null, null },
                    { 28, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(53), 3, "Idiyappam", 15m, "1 no", null, null, null },
                    { 29, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(55), 3, "Regular Idly", 10m, "1 no", 12m, null, null },
                    { 30, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(57), 3, "Puttu / 1 Cylinder", 80m, "1 no", 90m, null, null },
                    { 31, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(59), 3, "Mini Podi Idly", 100m, "30 nos", 105m, null, null },
                    { 32, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(61), 3, "Mini Idly Sambar", 100m, "30 nos", 105m, null, null },
                    { 33, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(63), 3, "Lemon Sevai", 75m, "250gms", 85m, null, null },
                    { 34, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(65), 3, "Coconut Sevai", 100m, "250gms", 105m, null, null },
                    { 35, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(67), 3, "Tomato Sevai", 100m, "250gms", 105m, null, null },
                    { 36, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(69), 3, "Garlic Sevai", 100m, "250gms", 105m, null, null },
                    { 37, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(71), 3, "Sweet Sevai", 100m, "250gms", 105m, null, null },
                    { 38, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(90), 3, "Puliyogare Sevai", 100m, "250gms", 105m, null, null },
                    { 39, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(92), 4, "Masal Dosa (with Sambar & Chutney)", 65m, "1", 70m, null, null },
                    { 40, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(95), 4, "Puri with Kurma - 3 Pieces", 80m, "1", 90m, null, null },
                    { 41, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(97), 4, "Chapathi", 15m, "1", null, null, null },
                    { 42, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(99), 4, "Sunday Fuel - Pongal, Vada with Sambar & Chutney (Sunday only)", 80m, "1", 85m, null, null },
                    { 43, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(101), 4, "Thatte Idly, Vada with Sambar & Chutney (Saturday only)", 60m, "1", 65m, null, null },
                    { 44, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(103), 5, "Sambar Podi", 160m, "200gms", null, null, null },
                    { 45, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(106), 5, "Idili/Dosa Podi", 160m, "200gms", null, null, null },
                    { 46, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(107), 5, "Gunpowder Podi", 80m, "100gms", null, null, null },
                    { 47, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(109), 5, "Groundnut Podi", 80m, "100gms", null, null, null },
                    { 48, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(122), 6, "Grated Coconut", 160m, "200gms", 160m, null, null },
                    { 49, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(124), 7, "Adhirasam (Kajaya)", 60m, "Pack of 4", 65m, null, null },
                    { 50, null, new DateTime(2026, 5, 1, 9, 56, 20, 506, DateTimeKind.Local).AddTicks(127), 7, "Thengapal Muruku (Big)", 60m, "Pack of 2", 65m, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CatalogId",
                schema: "order",
                table: "CatalogItems",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_ProductId",
                schema: "order",
                table: "CatalogItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_MerchantId",
                schema: "order",
                table: "Catalogs",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProfiles_MerchantSocietyId",
                schema: "user",
                table: "CustomerProfiles",
                column: "MerchantSocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProfiles_UserId_MerchantSocietyId",
                schema: "user",
                table: "CustomerProfiles",
                columns: new[] { "UserId", "MerchantSocietyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_StatusCode",
                schema: "error",
                table: "ExceptionLogs",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_StatusCode_Timestamp",
                schema: "error",
                table: "ExceptionLogs",
                columns: new[] { "StatusCode", "Timestamp" });

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_Timestamp",
                schema: "error",
                table: "ExceptionLogs",
                column: "Timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_AdminUserId",
                schema: "user",
                table: "Merchants",
                column: "AdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantSocieties_MerchantId_SocietyId",
                schema: "user",
                table: "MerchantSocieties",
                columns: new[] { "MerchantId", "SocietyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MerchantSocieties_SocietyId",
                schema: "user",
                table: "MerchantSocieties",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                schema: "order",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddedDate",
                schema: "order",
                table: "Orders",
                column: "AddedDate",
                filter: "\"IsDeleted\" = false");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MerchantSocietyId",
                schema: "order",
                table: "Orders",
                column: "MerchantSocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderNumber",
                schema: "order",
                table: "Orders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Status",
                schema: "order",
                table: "Orders",
                column: "Status",
                filter: "\"IsDeleted\" = false");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                schema: "order",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatusHistories_ChangedByUserId",
                schema: "order",
                table: "OrderStatusHistories",
                column: "ChangedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatusHistories_OrderId",
                schema: "order",
                table: "OrderStatusHistories",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTemplates_MerchantId_IsDefault",
                schema: "order",
                table: "OrderTemplates",
                columns: new[] { "MerchantId", "IsDefault" },
                unique: true,
                filter: "\"IsDefault\" = true");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                schema: "order",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentLinkId",
                schema: "order",
                table: "Payments",
                column: "PaymentLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "order",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "user",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCredentials_UserId",
                schema: "user",
                table: "UserCredentials",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "user",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                schema: "user",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogItems",
                schema: "order");

            migrationBuilder.DropTable(
                name: "CustomerProfiles",
                schema: "user");

            migrationBuilder.DropTable(
                name: "DeliverySettings",
                schema: "order");

            migrationBuilder.DropTable(
                name: "ExceptionLogs",
                schema: "error");

            migrationBuilder.DropTable(
                name: "OrderItems",
                schema: "order");

            migrationBuilder.DropTable(
                name: "OrderStatusHistories",
                schema: "order");

            migrationBuilder.DropTable(
                name: "OrderTemplates",
                schema: "order");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "order");

            migrationBuilder.DropTable(
                name: "RefreshTokens",
                schema: "user");

            migrationBuilder.DropTable(
                name: "UserCredentials",
                schema: "user");

            migrationBuilder.DropTable(
                name: "Catalogs",
                schema: "order");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "order");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "order");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "order");

            migrationBuilder.DropTable(
                name: "MerchantSocieties",
                schema: "user");

            migrationBuilder.DropTable(
                name: "Merchants",
                schema: "user");

            migrationBuilder.DropTable(
                name: "Societies",
                schema: "user");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "user");
        }
    }
}
