using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Web.Datas.Migrations
{
    public partial class migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnterpriseEntities",
                columns: table => new
                {
                    Key = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    AdultStatus = table.Column<int>(nullable: false),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    EnterpriseIntroduce = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseEntities", x => x.Key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnterpriseEntities");
        }
    }
}
