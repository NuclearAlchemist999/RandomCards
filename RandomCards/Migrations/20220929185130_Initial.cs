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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    TimeStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    { new Guid("002e8179-dae8-48e0-90d0-98616ac415ad"), "ten diamonds" },
                    { new Guid("0c9eafe8-796c-47f8-a2c4-98b1ed6b8594"), "eight clubs" },
                    { new Guid("131531af-4780-4353-89f9-4bd912acaea2"), "king clubs" },
                    { new Guid("17260e2c-29e1-40d5-8644-9fb90550c846"), "king hearts" },
                    { new Guid("1affa909-0d49-4416-bd36-1755174b4d44"), "ten spades" },
                    { new Guid("1dcbcf94-11a0-45b8-b8fa-301303bb8597"), "three clubs" },
                    { new Guid("1f5873d4-d3cf-45c5-8eb0-9c5522bcce7b"), "jack clubs" },
                    { new Guid("236ba3d4-2d1d-4a9d-a4d5-01f94b6364bd"), "two clubs" },
                    { new Guid("238e4681-01fc-401b-8aa1-22a0ba33c0ed"), "ace spades" },
                    { new Guid("28c51d75-82f4-4074-9895-21e38f4893dd"), "nine hearts" },
                    { new Guid("300753dc-b007-4db4-9f70-33c152dbf0f2"), "three hearts" },
                    { new Guid("3696a4f0-f341-40fa-834b-392f32ac7ca0"), "seven hearts" },
                    { new Guid("38c94d1c-77a4-4905-a6be-3cbab449dc8e"), "seven clubs" },
                    { new Guid("3aeea3db-ca81-4e8b-9861-960801e96c9c"), "eight hearts" },
                    { new Guid("3b5c34e5-b065-43f2-9443-a08785796121"), "queen hearts" },
                    { new Guid("498705b5-91f2-42c0-9671-cb94d52166a8"), "three diamonds" },
                    { new Guid("52e8e7de-7324-4f74-9fb4-bc948835ea8d"), "eight diamonds" },
                    { new Guid("53166a74-02a2-453d-9008-e663878646c1"), "nine clubs" },
                    { new Guid("5379d24a-26cb-4ea7-bdb6-cf5c6a894247"), "five hearts" },
                    { new Guid("5b69ac5c-c90c-4c45-9916-754614639262"), "six diamonds" },
                    { new Guid("668a3a70-3017-486c-9f69-81f9bd63f4a0"), "ten clubs" },
                    { new Guid("73f0cea1-0cb0-4983-85ac-60b89b3d47ed"), "four hearts" },
                    { new Guid("74ca0cd9-c72a-43d8-8747-ed0d22cdce42"), "jack diamonds" },
                    { new Guid("7ac11b15-ae16-476c-aa7d-a65c944b7575"), "queen diamonds" },
                    { new Guid("7ba88865-7260-465f-9ce5-cb6ee99c9935"), "six hearts" },
                    { new Guid("7c418ace-366f-477d-bc2f-d570f7c5f9b2"), "king diamonds" },
                    { new Guid("80440e50-c45a-4a41-abf8-af463fa81e7e"), "three spades" },
                    { new Guid("80fd5156-2b21-44ee-826a-24d40e06d0ca"), "two hearts" },
                    { new Guid("8737dfb1-90cd-4012-8bbb-e778380f4d97"), "queen spades" },
                    { new Guid("8a73578a-446a-4aab-9b52-fee34ffc3719"), "six spades" },
                    { new Guid("8ed83420-09cb-461f-b5b4-08743abb945b"), "seven diamonds" },
                    { new Guid("8f18fd94-6b52-4153-b428-3954e67d13b7"), "jack spades" },
                    { new Guid("90560d2a-7801-44c4-96db-216e355dfaec"), "eight spades" },
                    { new Guid("958bdeea-5f12-4525-a052-de461995188e"), "four diamonds" },
                    { new Guid("993e4ccd-d2a9-4885-b9dc-c67e4a5e44c7"), "two diamonds" },
                    { new Guid("aa29854a-1e9f-4174-854e-dd9aa9be1265"), "ace hearts" },
                    { new Guid("aef6f91c-c971-4b95-b78c-1f332315b450"), "two spades" },
                    { new Guid("afe3f754-66cb-4f3e-b547-404d10f1b348"), "king spades" },
                    { new Guid("b532c608-e6d4-466e-8be3-027c0fb2e7d7"), "seven spades" },
                    { new Guid("be2f34a5-19a2-40e3-a3d8-4a33e5358b9b"), "ten hearts" },
                    { new Guid("bfea8731-5e20-4f31-8924-28cbcff67f09"), "four spades" },
                    { new Guid("c01a3f29-04fe-4c62-8b7e-9331bafc304f"), "nine spades" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("c08abff6-e64a-47aa-8c2d-fa6e8284a0f9"), "ace diamonds" },
                    { new Guid("c856f539-4e1e-42e4-b6e2-dd88b0df8f04"), "queen clubs" },
                    { new Guid("cc134b31-7b79-4e43-89e8-bdce747bbbed"), "jack hearts" },
                    { new Guid("d0b27ce1-5b43-4a2a-b2fb-7288824a4d85"), "five clubs" },
                    { new Guid("d936ec3a-6e43-4558-88d9-775d934667c7"), "ace clubs" },
                    { new Guid("dae89307-40fc-4aee-beb3-da3abf844f24"), "five spades" },
                    { new Guid("e4d504be-95ff-40cc-9429-9f04ad1d1906"), "nine diamonds" },
                    { new Guid("e5445d3d-5152-4163-a18b-16f6576e3ecd"), "six clubs" },
                    { new Guid("f1883297-e207-4818-a2ed-70b6ea208323"), "four clubs" },
                    { new Guid("fc62d3f2-09a4-4361-9ac6-50aa5379533f"), "five diamonds" }
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
