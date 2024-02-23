using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patient_Models.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAllergies",
                columns: table => new
                {
                    AllergyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAllergies", x => x.AllergyId);
                });

            migrationBuilder.CreateTable(
                name: "tblDisease_Information",
                columns: table => new
                {
                    DiseaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDisease_Information", x => x.DiseaseId);
                });

            migrationBuilder.CreateTable(
                name: "tblNCD",
                columns: table => new
                {
                    NCD_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCD_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNCD", x => x.NCD_Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPatients_Information",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Epilepsy = table.Column<int>(type: "int", nullable: false),
                    DiseaseId = table.Column<int>(type: "int", nullable: false),
                    Disease_InformationDiseaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPatients_Information", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_tblPatients_Information_tblDisease_Information_Disease_InformationDiseaseId",
                        column: x => x.Disease_InformationDiseaseId,
                        principalTable: "tblDisease_Information",
                        principalColumn: "DiseaseId");
                });

            migrationBuilder.CreateTable(
                name: "tblAllergies_Details",
                columns: table => new
                {
                    Allergies_Details_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    AllergyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAllergies_Details", x => x.Allergies_Details_Id);
                    table.ForeignKey(
                        name: "FK_tblAllergies_Details_tblAllergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "tblAllergies",
                        principalColumn: "AllergyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAllergies_Details_tblPatients_Information_PatientId",
                        column: x => x.PatientId,
                        principalTable: "tblPatients_Information",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblNCD_Details",
                columns: table => new
                {
                    NCD_Details_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCD_Id = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNCD_Details", x => x.NCD_Details_Id);
                    table.ForeignKey(
                        name: "FK_tblNCD_Details_tblNCD_NCD_Id",
                        column: x => x.NCD_Id,
                        principalTable: "tblNCD",
                        principalColumn: "NCD_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblNCD_Details_tblPatients_Information_PatientId",
                        column: x => x.PatientId,
                        principalTable: "tblPatients_Information",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblAllergies",
                columns: new[] { "AllergyId", "AllergyName" },
                values: new object[,]
                {
                    { 1, "Drugs - Penicillin" },
                    { 2, "Drugs - Others" },
                    { 3, "Animals" },
                    { 4, "Food" },
                    { 5, "Ointments" },
                    { 6, "Plant" },
                    { 7, "Sprays" },
                    { 8, "Others" },
                    { 9, "No Allergies" }
                });

            migrationBuilder.InsertData(
                table: "tblDisease_Information",
                columns: new[] { "DiseaseId", "DiseaseName" },
                values: new object[,]
                {
                    { 1, "Diabetes" },
                    { 2, "Hypertension" },
                    { 3, "Arthritis" },
                    { 4, "Heart Disease" },
                    { 5, "Respiratory Infections" }
                });

            migrationBuilder.InsertData(
                table: "tblNCD",
                columns: new[] { "NCD_Id", "NCD_Name" },
                values: new object[,]
                {
                    { 1, "Asthma" },
                    { 2, "Cancer" },
                    { 3, "Disorders of ear" },
                    { 4, "Disorder of eye" },
                    { 5, "Mental illness" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAllergies_Details_AllergyId",
                table: "tblAllergies_Details",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAllergies_Details_PatientId",
                table: "tblAllergies_Details",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNCD_Details_NCD_Id",
                table: "tblNCD_Details",
                column: "NCD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblNCD_Details_PatientId",
                table: "tblNCD_Details",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPatients_Information_Disease_InformationDiseaseId",
                table: "tblPatients_Information",
                column: "Disease_InformationDiseaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAllergies_Details");

            migrationBuilder.DropTable(
                name: "tblNCD_Details");

            migrationBuilder.DropTable(
                name: "tblAllergies");

            migrationBuilder.DropTable(
                name: "tblNCD");

            migrationBuilder.DropTable(
                name: "tblPatients_Information");

            migrationBuilder.DropTable(
                name: "tblDisease_Information");
        }
    }
}
