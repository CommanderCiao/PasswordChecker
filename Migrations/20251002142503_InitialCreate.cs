using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PasswordChecker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompromisedAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompromisedAccounts", x => x.Id);
                });
            migrationBuilder.InsertData(
        table: "CompromisedAccounts",
        columns: new[] { "Username", "PasswordHash" },
        values: new object[,]
        {
            { "john.smith@example.com", "9e5a91234567890abcdef1234567890abcdef1234567890" },
            { "alex.jones@mail.com", "a1b2c3d4e5f6789012345678901234567890123456789012" },
            { "sarah.wilson@company.org", "920e08a62fff991b3c841eb98d7f689136c2392b49200bc1e8bc7d00bafa8221" },
            { "mike.brown@test.net", "76792f9565458ad3483f5b6bbc2d0d9a8dcbffca21eaad71f2aebb3dee38ea2b" },
            { "lisa.davis@web.app", "c9dc85a079a9d260d556382dc9d14174a244313b7aad4cb1aeab9e91895874e4" },
            { "david.wilson@service.com", "826fd96934e77561d09af36b25044748d5bb7c47581bf29dcacb2848ed4114a5" },
            { "emma.taylor@cloud.io", "5ae6400e852f7a6ad3c4f7c91045b24c87c1344a0545fdca8727426fc4088214"},
            { "kevin.miller@data.co", "f364a6ae5c55212325649fdd3e9aae0e528a43ff5a9bb5a8e3705c4600324ae2" },
            { "olivia.moore@secure.me", "0774f82cd49cd6218cdf081fa48f5c29a444ab6490de349cde07ab2073143b7c"},
            {  "ryan.anderson@safe.dev", "c049b8dae28be4c057116b3e69a9df18b135cc34f28883321968d2fedf6ae4"}
            });
        }
        

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompromisedAccounts");
        }
    }
}
