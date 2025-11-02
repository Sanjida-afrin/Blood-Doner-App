using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDoner.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDonationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_BloodDoners_BloodDonerEntityId",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "BloodDonerEntityId",
                table: "Donations",
                newName: "CampaignId");

            migrationBuilder.RenameIndex(
                name: "IX_Donations_BloodDonerEntityId",
                table: "Donations",
                newName: "IX_Donations_CampaignId");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_BloodDonerId",
                table: "Donations",
                column: "BloodDonerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_BloodDoners_BloodDonerId",
                table: "Donations",
                column: "BloodDonerId",
                principalTable: "BloodDoners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Campaigns_CampaignId",
                table: "Donations",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_BloodDoners_BloodDonerId",
                table: "Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Campaigns_CampaignId",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_BloodDonerId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "CampaignId",
                table: "Donations",
                newName: "BloodDonerEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Donations_CampaignId",
                table: "Donations",
                newName: "IX_Donations_BloodDonerEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_BloodDoners_BloodDonerEntityId",
                table: "Donations",
                column: "BloodDonerEntityId",
                principalTable: "BloodDoners",
                principalColumn: "Id");
        }
    }
}
