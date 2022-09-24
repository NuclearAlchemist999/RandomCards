using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandomCards.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStamp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards_Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Games_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_Games_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hands_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards_Hands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards_Hands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Hands_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_Hands_Hands_HandId",
                        column: x => x.HandId,
                        principalTable: "Hands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("007f7c60-4646-4ffc-8683-42c04a554d81"), "ten spades" },
                    { new Guid("04502fbe-faa0-4b2a-ac51-bf659fc9f208"), "five hearts" },
                    { new Guid("0493c1c2-189c-47fd-b597-ae3f4c5af752"), "four clubs" },
                    { new Guid("06a61a93-882e-4dd1-92b6-3a034af8b03c"), "eight hearts" },
                    { new Guid("072bf392-cb7e-41e6-8000-1d01780df5c3"), "jack clubs" },
                    { new Guid("1b97392a-c25b-4ec3-957c-09dad7cac4fd"), "six clubs" },
                    { new Guid("1c0bc9a9-9d51-4d8b-b79b-a898a958663f"), "seven diamonds" },
                    { new Guid("1e8dc7b2-8dc7-41b2-b8a5-eff6a4748adc"), "ten clubs" },
                    { new Guid("208b7e46-9e24-4595-b8e2-53ff62b83466"), "eight spades" },
                    { new Guid("24d276d8-0bed-4231-b075-ff349afff152"), "two clubs" },
                    { new Guid("3858f116-2552-416a-8263-b0ec6f76859b"), "five diamonds" },
                    { new Guid("3d91aa6f-4325-4afc-a99d-38b113e52f2b"), "four diamonds" },
                    { new Guid("4fb56ecf-df1e-4cd2-b72c-1e4bf0fdd511"), "queen spades" },
                    { new Guid("5b0d7fbb-d085-4008-9955-b8e863e2fbdb"), "seven clubs" },
                    { new Guid("5d6cc6de-72c9-45bc-ae26-de2237ca3dac"), "jack hearts" },
                    { new Guid("606284cd-52af-414f-98d7-364cf6ccc5a3"), "three hearts" },
                    { new Guid("635e48f4-e1fb-4eac-ae2b-c658e813843d"), "six diamonds" },
                    { new Guid("660e2b0d-ff7e-4a61-b357-1f8d63bcda1f"), "ace clubs" },
                    { new Guid("66915fbd-892c-4cc5-8f4c-9236c143dd0b"), "seven hearts" },
                    { new Guid("6cfbed3a-ab70-4a4f-94e7-3d12e1089c56"), "four hearts" },
                    { new Guid("720d9b0c-d182-4c4d-aab0-c697f2eccef8"), "three clubs" },
                    { new Guid("786f5c46-767e-4148-ba59-a4d77fff417e"), "two spades" },
                    { new Guid("788b08bc-60a7-4076-8a5b-d2d7d343c0fd"), "six hearts" },
                    { new Guid("8e16adba-7bfd-4698-9025-8f793af3a67a"), "seven spades" },
                    { new Guid("8f07c4c5-08d1-4386-b0d6-13f3a4df3c02"), "four spades" },
                    { new Guid("8ffd4219-30d5-40e6-b577-d29e43a4085b"), "nine hearts" },
                    { new Guid("93b8dc5a-239f-4792-8804-9f6ba304d377"), "two diamonds" },
                    { new Guid("99c9b894-ba6d-4ee8-bd0c-a527d2f83036"), "king spades" },
                    { new Guid("9a681dd0-29b9-4ef5-b363-efbcf4e0c56e"), "two hearts" },
                    { new Guid("9a7fa761-9651-4711-a45b-3085d5dfcc54"), "king hearts" },
                    { new Guid("a10c43f9-503c-40a0-aa04-e361d25c52bb"), "jack spades" },
                    { new Guid("a3f95ac1-d02b-440f-b170-76d2e0b98208"), "nine spades" },
                    { new Guid("a51469a6-144c-4e64-a73e-7a5f21eac651"), "queen clubs" },
                    { new Guid("ad560d04-aef3-4613-9969-9e5c6e4d6759"), "three diamonds" },
                    { new Guid("b00e992a-07c0-4498-8201-00204554d4e6"), "three spades" },
                    { new Guid("b4266bf2-c05b-404b-af6b-0b626ec4d08c"), "king diamonds" },
                    { new Guid("b922714e-1573-49f3-9625-a77325673527"), "ten diamonds" },
                    { new Guid("bf0ddee0-789d-4a18-89eb-e9716f202fb4"), "five spades" },
                    { new Guid("c1ce5893-7fa8-45e9-834b-bea81cd47944"), "six spades" },
                    { new Guid("c4549873-0003-4a38-9dbe-a7bc96e04a06"), "ace hearts" },
                    { new Guid("c6141a7d-0af1-4f37-9b05-3b3f58d6107a"), "nine clubs" },
                    { new Guid("c7a6c000-a283-43bc-9d44-c276e424900c"), "five clubs" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d4c97442-f9c4-4971-a57b-718c5fbc602f"), "eight clubs" },
                    { new Guid("d958da25-4344-457d-bcc2-916610414ed0"), "ace diamonds" },
                    { new Guid("e9e5bbb7-6a39-4665-9704-e5c3c9f5c7f7"), "eight diamonds" },
                    { new Guid("ed2d048f-1912-46ba-a57b-e28f3c292fab"), "ace spades" },
                    { new Guid("f1152d96-ed83-4607-ac1e-603c410eb0a3"), "queen hearts" },
                    { new Guid("f36b817b-1d2f-4764-bbd4-5134cb22c058"), "jack diamonds" },
                    { new Guid("f8d855c5-3b35-4d53-8d74-64356fb2f6f3"), "queen diamonds" },
                    { new Guid("f91cbf1d-5011-4ce5-89e2-154f8242f8d1"), "nine diamonds" },
                    { new Guid("fb39002e-8452-40e2-83de-a041cf2e2de0"), "ten hearts" },
                    { new Guid("fc47fd32-3396-4873-8aed-f3151d011ef8"), "king clubs" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Games_CardId",
                table: "Cards_Games",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Games_GameId",
                table: "Cards_Games",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Hands_CardId",
                table: "Cards_Hands",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Hands_HandId",
                table: "Cards_Hands",
                column: "HandId");

            migrationBuilder.CreateIndex(
                name: "IX_Hands_GameId",
                table: "Hands",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards_Games");

            migrationBuilder.DropTable(
                name: "Cards_Hands");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Hands");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
