using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.ServiceDesk.Data.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtendimentosDeltaLog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    motorista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shift = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imei = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    analista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    problema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    acao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentosDeltaLog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AtendimentosGerais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    analista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nomeDoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    filial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ticket = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentosGerais", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Filiais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estabelecimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiais", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtendimentosDeltaLog");

            migrationBuilder.DropTable(
                name: "AtendimentosGerais");

            migrationBuilder.DropTable(
                name: "Filiais");
        }
    }
}
