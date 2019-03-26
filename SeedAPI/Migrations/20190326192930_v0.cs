using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeedAPI.Migrations
{
    public partial class v0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanoDeAula",
                columns: table => new
                {
                    PlanoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoDeAula", x => x.PlanoId);
                });

            migrationBuilder.CreateTable(
                name: "PlanoDeEnsino",
                columns: table => new
                {
                    PlanoDeEnsinoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoDeEnsino", x => x.PlanoDeEnsinoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Privilegio = table.Column<int>(nullable: false),
                    Titulacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    CursoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CoordenadorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.CursoId);
                    table.ForeignKey(
                        name: "FK_Curso_Usuario_CoordenadorId",
                        column: x => x.CoordenadorId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    DisciplinaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CursoId = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    PlanoDeEnsinoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.DisciplinaId);
                    table.ForeignKey(
                        name: "FK_Disciplina_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplina_PlanoDeEnsino_PlanoDeEnsinoId",
                        column: x => x.PlanoDeEnsinoId,
                        principalTable: "PlanoDeEnsino",
                        principalColumn: "PlanoDeEnsinoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplina_Usuario_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursoDisciplina",
                columns: table => new
                {
                    CursoDisciplinaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CursoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoDisciplina", x => x.CursoDisciplinaId);
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "DisciplinaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    TurmaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProfessorUsuarioId = table.Column<int>(nullable: true),
                    CursoDisciplinaId = table.Column<int>(nullable: false),
                    PlanoDeAulaPlanoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.TurmaId);
                    table.ForeignKey(
                        name: "FK_Turma_CursoDisciplina_CursoDisciplinaId",
                        column: x => x.CursoDisciplinaId,
                        principalTable: "CursoDisciplina",
                        principalColumn: "CursoDisciplinaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turma_PlanoDeAula_PlanoDeAulaPlanoId",
                        column: x => x.PlanoDeAulaPlanoId,
                        principalTable: "PlanoDeAula",
                        principalColumn: "PlanoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turma_Usuario_ProfessorUsuarioId",
                        column: x => x.ProfessorUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curso_CoordenadorId",
                table: "Curso",
                column: "CoordenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoDisciplina_CursoId",
                table: "CursoDisciplina",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoDisciplina_DisciplinaId",
                table: "CursoDisciplina",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_CursoId",
                table: "Disciplina",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_PlanoDeEnsinoId",
                table: "Disciplina",
                column: "PlanoDeEnsinoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_CursoDisciplinaId",
                table: "Turma",
                column: "CursoDisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_PlanoDeAulaPlanoId",
                table: "Turma",
                column: "PlanoDeAulaPlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_ProfessorUsuarioId",
                table: "Turma",
                column: "ProfessorUsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "CursoDisciplina");

            migrationBuilder.DropTable(
                name: "PlanoDeAula");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "PlanoDeEnsino");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
