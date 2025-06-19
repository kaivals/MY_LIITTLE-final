using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mylittle_project.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserDealerAndPortalAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandingTexts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FontName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FontSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FontWeight = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandingTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DealerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dealers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DealerSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DurationInMonths = table.Column<int>(type: "int", nullable: false),
                    AutoRenew = table.Column<bool>(type: "bit", nullable: false),
                    QueueIfUnavailable = table.Column<bool>(type: "bit", nullable: false),
                    PlanStartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Portal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantNickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subdomain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndustryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDealers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BusinessInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDealers_BusinessInfos_BusinessInfoId",
                        column: x => x.BusinessInfoId,
                        principalTable: "BusinessInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DealerId = table.Column<int>(type: "int", nullable: false),
                    DealerId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Portal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Dealers_DealerId1",
                        column: x => x.DealerId1,
                        principalTable: "Dealers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AssignedCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionDealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedCategories_DealerSubscriptions_SubscriptionDealerId",
                        column: x => x.SubscriptionDealerId,
                        principalTable: "DealerSubscriptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminUsers_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brandings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimaryColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccentColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brandings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brandings_BrandingTexts_TextId",
                        column: x => x.TextId,
                        principalTable: "BrandingTexts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Brandings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WelcomeMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallToAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutUs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentSettings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subdomain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomDomain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnableApiAccess = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DomainSettings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnableCategoriesManagement = table.Column<bool>(type: "bit", nullable: false),
                    EnableProducts = table.Column<bool>(type: "bit", nullable: false),
                    EnableBrands = table.Column<bool>(type: "bit", nullable: false),
                    EnableReviews = table.Column<bool>(type: "bit", nullable: false),
                    EnableProductTags = table.Column<bool>(type: "bit", nullable: false),
                    EnableCustomerInformation = table.Column<bool>(type: "bit", nullable: false),
                    EnableBillingInfo = table.Column<bool>(type: "bit", nullable: false),
                    EnableShippingInfo = table.Column<bool>(type: "bit", nullable: false),
                    EnableDeliveryMethod = table.Column<bool>(type: "bit", nullable: false),
                    EnablePaymentMethods = table.Column<bool>(type: "bit", nullable: false),
                    EnableStripe = table.Column<bool>(type: "bit", nullable: false),
                    EnablePayPal = table.Column<bool>(type: "bit", nullable: false),
                    EnableCashOnDelivery = table.Column<bool>(type: "bit", nullable: false),
                    EnableAdvancedFeatures = table.Column<bool>(type: "bit", nullable: false),
                    EnableApiAccess = table.Column<bool>(type: "bit", nullable: false),
                    EnableThemeCustomization = table.Column<bool>(type: "bit", nullable: false),
                    EnableDealerPlan = table.Column<bool>(type: "bit", nullable: false),
                    EnableMultiAdminPanel = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureSettings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnableTaxCalculations = table.Column<bool>(type: "bit", nullable: false),
                    EnableShipping = table.Column<bool>(type: "bit", nullable: false),
                    EnableFilters = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTrial = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortalAssignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DealerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortalAssignments_UserDealers_DealerUserId",
                        column: x => x.DealerUserId,
                        principalTable: "UserDealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrandingMedia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaviconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackgroundImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandingMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandingMedia_Brandings_BrandingId",
                        column: x => x.BrandingId,
                        principalTable: "Brandings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorPreset",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccentColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorPreset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorPreset_Brandings_BrandingId",
                        column: x => x.BrandingId,
                        principalTable: "Brandings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RangeStart = table.Column<double>(type: "float", nullable: true),
                    RangeEnd = table.Column<double>(type: "float", nullable: true),
                    Step = table.Column<double>(type: "float", nullable: true),
                    Options = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filters_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_TenantId",
                table: "ActivityLogs",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUsers_TenantId",
                table: "AdminUsers",
                column: "TenantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignedCategories_SubscriptionDealerId",
                table: "AssignedCategories",
                column: "SubscriptionDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandingMedia_BrandingId",
                table: "BrandingMedia",
                column: "BrandingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brandings_TenantId",
                table: "Brandings",
                column: "TenantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brandings_TextId",
                table: "Brandings",
                column: "TextId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorPreset_BrandingId",
                table: "ColorPreset",
                column: "BrandingId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentSettings_TenantId",
                table: "ContentSettings",
                column: "TenantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DomainSettings_TenantId",
                table: "DomainSettings",
                column: "TenantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeatureSettings_TenantId",
                table: "FeatureSettings",
                column: "TenantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filters_StoreId",
                table: "Filters",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DealerId1",
                table: "Orders",
                column: "DealerId1");

            migrationBuilder.CreateIndex(
                name: "IX_PortalAssignments_DealerUserId",
                table: "PortalAssignments",
                column: "DealerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_TenantId",
                table: "Stores",
                column: "TenantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_TenantId",
                table: "Subscriptions",
                column: "TenantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDealers_BusinessInfoId",
                table: "UserDealers",
                column: "BusinessInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "AssignedCategories");

            migrationBuilder.DropTable(
                name: "BrandingMedia");

            migrationBuilder.DropTable(
                name: "ColorPreset");

            migrationBuilder.DropTable(
                name: "ContentSettings");

            migrationBuilder.DropTable(
                name: "DomainSettings");

            migrationBuilder.DropTable(
                name: "FeatureSettings");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "PortalAssignments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "DealerSubscriptions");

            migrationBuilder.DropTable(
                name: "Brandings");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "UserDealers");

            migrationBuilder.DropTable(
                name: "BrandingTexts");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Dealers");

            migrationBuilder.DropTable(
                name: "BusinessInfos");
        }
    }
}
