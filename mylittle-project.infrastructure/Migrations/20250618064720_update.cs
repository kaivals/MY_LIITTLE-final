using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mylittle_project.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EnableAdvancedFeatures",
                table: "FeatureSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableCategoriesManagement",
                table: "FeatureSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableCustomerInformation",
                table: "FeatureSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnablePaymentMethods",
                table: "FeatureSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnableAdvancedFeatures",
                table: "FeatureSettings");

            migrationBuilder.DropColumn(
                name: "EnableCategoriesManagement",
                table: "FeatureSettings");

            migrationBuilder.DropColumn(
                name: "EnableCustomerInformation",
                table: "FeatureSettings");

            migrationBuilder.DropColumn(
                name: "EnablePaymentMethods",
                table: "FeatureSettings");
        }
    }
}
