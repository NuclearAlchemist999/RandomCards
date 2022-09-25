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
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStamp = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    { new Guid("0469eb70-5b2a-4c6b-b32c-56e96b8a29f9"), "seven clubs" },
                    { new Guid("19349b74-e865-487c-9c20-a4d7f863626e"), "jack hearts" },
                    { new Guid("19731224-4d0d-418c-87eb-152815c5ceb7"), "five diamonds" },
                    { new Guid("1cf39836-be86-45f9-8ee1-8e1d8937cdde"), "five hearts" },
                    { new Guid("1e982343-74b0-49c7-a32d-76ca4aa031d6"), "ace clubs" },
                    { new Guid("1edb0043-55d4-4968-84c6-2c33d7cb4460"), "queen clubs" },
                    { new Guid("1fbf3919-8759-4f48-9bb0-3d24c2b158e3"), "jack clubs" },
                    { new Guid("2389b1b1-60e8-4b07-a6f1-f6f2f82adb4f"), "ten clubs" },
                    { new Guid("271d9f70-6cdb-4774-a77a-4d5d23c181af"), "three clubs" },
                    { new Guid("32e104a6-befc-4432-81a0-70e84ff298f8"), "two diamonds" },
                    { new Guid("37e117ad-ad6a-4efc-b169-33b4d64a1538"), "four clubs" },
                    { new Guid("4408917d-a2d1-44e0-b4f6-2a02e0d50f60"), "eight spades" },
                    { new Guid("4ca2dcb8-26df-44c8-9876-255117009282"), "six clubs" },
                    { new Guid("62c54a96-a720-450c-a2eb-572c02fd3e70"), "five spades" },
                    { new Guid("6b19b8ca-a9df-4922-bc62-45caf8abd751"), "ten spades" },
                    { new Guid("6be41e35-9e98-4885-9c66-c5bdb7ac4c7c"), "nine clubs" },
                    { new Guid("6e65fb09-8724-4e56-a872-661a67b618ed"), "four spades" },
                    { new Guid("6f0b28e9-27cb-4429-b163-81ceea403c4b"), "six hearts" },
                    { new Guid("6f5a54d4-e078-46ed-837b-0f607ad453d9"), "seven hearts" },
                    { new Guid("71590413-64da-435b-a1c2-5900be671423"), "jack diamonds" },
                    { new Guid("7365766e-9647-46dd-b8c6-da9a035574fa"), "seven diamonds" },
                    { new Guid("73db7e58-d6b5-45a9-bce9-015bcda10c77"), "three diamonds" },
                    { new Guid("7fe4b0f1-47c6-453e-b505-f8b34eb34e72"), "king clubs" },
                    { new Guid("8728bd70-e221-4f07-a4c8-ee0cc27b5db8"), "eight clubs" },
                    { new Guid("89c9e14e-43e0-4370-8ab6-399e3349e54f"), "three hearts" },
                    { new Guid("8a4e0aca-11a9-47db-b237-e459b727ba9a"), "queen hearts" },
                    { new Guid("8bc8ba28-46b6-4be5-b03a-d30bc518e8ab"), "ace diamonds" },
                    { new Guid("983e67da-26a5-414e-8fe2-a421affb711c"), "seven spades" },
                    { new Guid("98e7cce4-94b6-4cd0-8df6-41dcb603e307"), "ace spades" },
                    { new Guid("995a67f9-cbde-4d58-b3c9-83d6e4f98663"), "ten hearts" },
                    { new Guid("9d3948e4-7de3-4b9b-a5a9-5430bd6dc380"), "ten diamonds" },
                    { new Guid("9f5eedef-e175-45cb-bf5b-1bb8a381d029"), "king hearts" },
                    { new Guid("a1f34cd1-4886-4bab-a841-2bf0d42eae67"), "nine diamonds" },
                    { new Guid("acaa772f-ce0b-4e87-920c-559658f5f55e"), "ace hearts" },
                    { new Guid("ad34c0c4-f4a5-42d6-a99e-6cf24702b15a"), "nine spades" },
                    { new Guid("b2826b86-3a89-42db-b4d0-9537df2856af"), "two clubs" },
                    { new Guid("c0e3ccfb-a42f-46c3-af33-2e4ba5a4b75b"), "five clubs" },
                    { new Guid("c4463788-e536-4ab3-9f3d-41634794b23a"), "two hearts" },
                    { new Guid("c5980d42-e872-4c3f-897b-12960e757ee9"), "four hearts" },
                    { new Guid("c6824e2e-1e5a-468c-bc36-7f66168d526a"), "four diamonds" },
                    { new Guid("c9e39fc0-99f0-49d0-ae1d-ade982eb5f01"), "king spades" },
                    { new Guid("cd68faa7-5051-4383-8826-c32eda7b7e2c"), "nine hearts" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("cf682d09-92bb-4709-9106-0b640595f1a2"), "six spades" },
                    { new Guid("dc4bb902-9a00-443a-8631-11a0d01d5d87"), "three spades" },
                    { new Guid("e5924894-1581-4800-ac0d-76d71019fa64"), "king diamonds" },
                    { new Guid("e8d2839b-cc4d-46ca-8720-211ea4f5d44d"), "eight hearts" },
                    { new Guid("ec2a8f90-6bb1-4400-8b86-f4171eb7a59f"), "jack spades" },
                    { new Guid("ee8bf6b8-23cd-44c8-8a6d-b1323e8c249d"), "eight diamonds" },
                    { new Guid("f5af3e55-f689-475d-bc2b-734cef2b7dbb"), "two spades" },
                    { new Guid("f736ceaf-9c5f-4bbe-aaa0-cdd57e1af9b9"), "six diamonds" },
                    { new Guid("f7d937ea-18fa-45bb-a1be-fd41833404d2"), "queen diamonds" },
                    { new Guid("f920a120-e313-408d-8a29-cc28a8ab33d3"), "queen spades" }
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
