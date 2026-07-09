using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeDirectory.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "FirstName", "HireDate", "JobTitle", "LastName", "Salary" },
                values: new object[,]
                {
                    { 1, "Technology", "aditya.wijaya1@company.com", "Aditya", new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Local), "DevOps Specialist", "Wijaya", 8300000m },
                    { 2, "Technology", "aditya.sari2@company.com", "Aditya", new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Local), "UI/UX Designer", "Sari", 9700000m },
                    { 3, "Human Resources", "mega.hidayat3@company.com", "Mega", new DateTime(2026, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), "HR Specialist", "Hidayat", 15400000m },
                    { 4, "Human Resources", "hendra.utomo4@company.com", "Hendra", new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Local), "HR Specialist", "Utomo", 6800000m },
                    { 5, "Technology", "hendra.utomo5@company.com", "Hendra", new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Local), "DevOps Specialist", "Utomo", 7900000m },
                    { 6, "Technology", "aditya.sari6@company.com", "Aditya", new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Local), "Software Engineer", "Sari", 11100000m },
                    { 7, "Finance", "hendra.santoso7@company.com", "Hendra", new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Local), "Tax Specialist", "Santoso", 20000000m },
                    { 8, "Technology", "andi.santoso8@company.com", "Andi", new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Local), "UI/UX Designer", "Santoso", 17500000m },
                    { 9, "Human Resources", "dewi.gunawan9@company.com", "Dewi", new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), "Recruiter", "Gunawan", 7800000m },
                    { 10, "Technology", "rina.sari10@company.com", "Rina", new DateTime(2023, 5, 24, 0, 0, 0, 0, DateTimeKind.Local), "QA Engineer", "Sari", 19200000m },
                    { 11, "Human Resources", "dewi.santoso11@company.com", "Dewi", new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "HR Specialist", "Santoso", 6300000m },
                    { 12, "Technology", "siti.sari12@company.com", "Siti", new DateTime(2023, 12, 14, 0, 0, 0, 0, DateTimeKind.Local), "UI/UX Designer", "Sari", 13800000m },
                    { 13, "Operations", "mega.santoso13@company.com", "Mega", new DateTime(2026, 2, 17, 0, 0, 0, 0, DateTimeKind.Local), "Operations Staff", "Santoso", 5000000m },
                    { 14, "Operations", "rina.santoso14@company.com", "Rina", new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Local), "Project Manager", "Santoso", 14200000m },
                    { 15, "Human Resources", "rina.santoso15@company.com", "Rina", new DateTime(2022, 8, 7, 0, 0, 0, 0, DateTimeKind.Local), "HR Specialist", "Santoso", 13700000m },
                    { 16, "Human Resources", "mega.kusuma16@company.com", "Mega", new DateTime(2022, 11, 16, 0, 0, 0, 0, DateTimeKind.Local), "HR Manager", "Kusuma", 16700000m },
                    { 17, "Operations", "budi.rahayu17@company.com", "Budi", new DateTime(2025, 8, 26, 0, 0, 0, 0, DateTimeKind.Local), "Operations Staff", "Rahayu", 19200000m },
                    { 18, "Human Resources", "siti.kusuma18@company.com", "Siti", new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), "HR Manager", "Kusuma", 7900000m },
                    { 19, "Finance", "dewi.utomo19@company.com", "Dewi", new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Local), "Tax Specialist", "Utomo", 20400000m },
                    { 20, "Finance", "aditya.lestari20@company.com", "Aditya", new DateTime(2026, 4, 28, 0, 0, 0, 0, DateTimeKind.Local), "Tax Specialist", "Lestari", 18000000m },
                    { 21, "Technology", "rini.nugroho21@company.com", "Rini", new DateTime(2026, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "Software Engineer", "Nugroho", 10300000m },
                    { 22, "Finance", "dewi.utomo22@company.com", "Dewi", new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Local), "Accountant", "Utomo", 24900000m },
                    { 23, "Human Resources", "siti.hidayat23@company.com", "Siti", new DateTime(2026, 5, 24, 0, 0, 0, 0, DateTimeKind.Local), "HR Manager", "Hidayat", 21500000m },
                    { 24, "Operations", "budi.gunawan24@company.com", "Budi", new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Local), "Operations Staff", "Gunawan", 23600000m },
                    { 25, "Marketing", "bambang.utomo25@company.com", "Bambang", new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Local), "Content Writer", "Utomo", 8800000m },
                    { 26, "Human Resources", "andi.santoso26@company.com", "Andi", new DateTime(2022, 8, 26, 0, 0, 0, 0, DateTimeKind.Local), "HR Manager", "Santoso", 24800000m },
                    { 27, "Technology", "andi.rahayu27@company.com", "Andi", new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), "QA Engineer", "Rahayu", 16200000m },
                    { 28, "Finance", "aditya.wijaya28@company.com", "Aditya", new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Local), "Financial Analyst", "Wijaya", 22700000m },
                    { 29, "Finance", "rini.nugroho29@company.com", "Rini", new DateTime(2022, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), "Financial Analyst", "Nugroho", 24000000m },
                    { 30, "Technology", "siti.wijaya30@company.com", "Siti", new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Local), "Software Engineer", "Wijaya", 23900000m },
                    { 31, "Finance", "eko.utomo31@company.com", "Eko", new DateTime(2021, 10, 7, 0, 0, 0, 0, DateTimeKind.Local), "Accountant", "Utomo", 23300000m },
                    { 32, "Human Resources", "sri.pratama32@company.com", "Sri", new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Local), "Recruiter", "Pratama", 17300000m },
                    { 33, "Human Resources", "hendra.putri33@company.com", "Hendra", new DateTime(2022, 7, 17, 0, 0, 0, 0, DateTimeKind.Local), "Recruiter", "Putri", 15500000m },
                    { 34, "Marketing", "dewi.rahayu34@company.com", "Dewi", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Local), "Marketing Executive", "Rahayu", 10500000m },
                    { 35, "Technology", "hendra.setiawan35@company.com", "Hendra", new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Local), "QA Engineer", "Setiawan", 21100000m },
                    { 36, "Operations", "fitri.nugroho36@company.com", "Fitri", new DateTime(2021, 9, 28, 0, 0, 0, 0, DateTimeKind.Local), "Operations Staff", "Nugroho", 22900000m },
                    { 37, "Human Resources", "andi.utomo37@company.com", "Andi", new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Local), "Recruiter", "Utomo", 15000000m },
                    { 38, "Human Resources", "siti.gunawan38@company.com", "Siti", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Local), "Recruiter", "Gunawan", 19400000m },
                    { 39, "Finance", "mega.gunawan39@company.com", "Mega", new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Local), "Accountant", "Gunawan", 23700000m },
                    { 40, "Human Resources", "budi.pratama40@company.com", "Budi", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Local), "HR Specialist", "Pratama", 10800000m },
                    { 41, "Human Resources", "sri.sari41@company.com", "Sri", new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), "Recruiter", "Sari", 20300000m },
                    { 42, "Operations", "agus.hidayat42@company.com", "Agus", new DateTime(2021, 11, 22, 0, 0, 0, 0, DateTimeKind.Local), "Operations Staff", "Hidayat", 8600000m },
                    { 43, "Human Resources", "joko.utomo43@company.com", "Joko", new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Local), "HR Manager", "Utomo", 6500000m },
                    { 44, "Operations", "sri.hidayat44@company.com", "Sri", new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), "Project Manager", "Hidayat", 22900000m },
                    { 45, "Technology", "bambang.utomo45@company.com", "Bambang", new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Local), "UI/UX Designer", "Utomo", 13200000m },
                    { 46, "Human Resources", "rina.nugroho46@company.com", "Rina", new DateTime(2026, 4, 16, 0, 0, 0, 0, DateTimeKind.Local), "HR Manager", "Nugroho", 20100000m },
                    { 47, "Technology", "rini.setiawan47@company.com", "Rini", new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Local), "DevOps Specialist", "Setiawan", 15400000m },
                    { 48, "Marketing", "rini.pratama48@company.com", "Rini", new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Local), "Content Writer", "Pratama", 17100000m },
                    { 49, "Technology", "rina.wijaya49@company.com", "Rina", new DateTime(2021, 9, 11, 0, 0, 0, 0, DateTimeKind.Local), "UI/UX Designer", "Wijaya", 10800000m },
                    { 50, "Finance", "rini.santoso50@company.com", "Rini", new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Local), "Financial Analyst", "Santoso", 8100000m },
                    { 51, "Operations", "rina.wijaya51@company.com", "Rina", new DateTime(2025, 6, 23, 0, 0, 0, 0, DateTimeKind.Local), "Operations Staff", "Wijaya", 18100000m },
                    { 52, "Operations", "rina.setiawan52@company.com", "Rina", new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Local), "Operations Staff", "Setiawan", 17300000m },
                    { 53, "Marketing", "eko.pratama53@company.com", "Eko", new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Local), "Content Writer", "Pratama", 15800000m },
                    { 54, "Operations", "eko.setiawan54@company.com", "Eko", new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Local), "Project Manager", "Setiawan", 9500000m },
                    { 55, "Marketing", "joko.gunawan55@company.com", "Joko", new DateTime(2022, 10, 18, 0, 0, 0, 0, DateTimeKind.Local), "Marketing Executive", "Gunawan", 16800000m },
                    { 56, "Finance", "eko.nugroho56@company.com", "Eko", new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Local), "Tax Specialist", "Nugroho", 5800000m },
                    { 57, "Finance", "eko.pratama57@company.com", "Eko", new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), "Financial Analyst", "Pratama", 5000000m },
                    { 58, "Finance", "eko.hidayat58@company.com", "Eko", new DateTime(2025, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), "Tax Specialist", "Hidayat", 13300000m },
                    { 59, "Finance", "andi.gunawan59@company.com", "Andi", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Local), "Tax Specialist", "Gunawan", 23800000m },
                    { 60, "Operations", "dewi.nugroho60@company.com", "Dewi", new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), "Project Manager", "Nugroho", 17800000m },
                    { 61, "Technology", "mega.hidayat61@company.com", "Mega", new DateTime(2023, 5, 29, 0, 0, 0, 0, DateTimeKind.Local), "Software Engineer", "Hidayat", 23100000m },
                    { 62, "Technology", "sri.utomo62@company.com", "Sri", new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Local), "QA Engineer", "Utomo", 7600000m },
                    { 63, "Marketing", "siti.santoso63@company.com", "Siti", new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Local), "Marketing Executive", "Santoso", 9700000m },
                    { 64, "Human Resources", "hendra.gunawan64@company.com", "Hendra", new DateTime(2022, 8, 7, 0, 0, 0, 0, DateTimeKind.Local), "Recruiter", "Gunawan", 7500000m },
                    { 65, "Technology", "bambang.utomo65@company.com", "Bambang", new DateTime(2025, 12, 25, 0, 0, 0, 0, DateTimeKind.Local), "Software Engineer", "Utomo", 18000000m },
                    { 66, "Finance", "mega.gunawan66@company.com", "Mega", new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Local), "Tax Specialist", "Gunawan", 23100000m },
                    { 67, "Finance", "sri.hidayat67@company.com", "Sri", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Local), "Tax Specialist", "Hidayat", 20900000m },
                    { 68, "Marketing", "agus.gunawan68@company.com", "Agus", new DateTime(2021, 11, 28, 0, 0, 0, 0, DateTimeKind.Local), "Marketing Executive", "Gunawan", 21000000m },
                    { 69, "Marketing", "hendra.pratama69@company.com", "Hendra", new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), "SEO Specialist", "Pratama", 21200000m },
                    { 70, "Technology", "eko.rahayu70@company.com", "Eko", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Local), "QA Engineer", "Rahayu", 21400000m },
                    { 71, "Operations", "joko.rahayu71@company.com", "Joko", new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), "Operations Staff", "Rahayu", 22000000m },
                    { 72, "Technology", "hendra.kusuma72@company.com", "Hendra", new DateTime(2022, 2, 27, 0, 0, 0, 0, DateTimeKind.Local), "UI/UX Designer", "Kusuma", 7600000m },
                    { 73, "Technology", "mega.nugroho73@company.com", "Mega", new DateTime(2024, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "DevOps Specialist", "Nugroho", 18200000m },
                    { 74, "Marketing", "siti.pratama74@company.com", "Siti", new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Local), "Marketing Executive", "Pratama", 8000000m },
                    { 75, "Operations", "rini.utomo75@company.com", "Rini", new DateTime(2021, 8, 14, 0, 0, 0, 0, DateTimeKind.Local), "Project Manager", "Utomo", 10500000m },
                    { 76, "Finance", "mega.setiawan76@company.com", "Mega", new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Local), "Accountant", "Setiawan", 10600000m },
                    { 77, "Operations", "sri.rahayu77@company.com", "Sri", new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), "Operations Staff", "Rahayu", 9800000m },
                    { 78, "Technology", "hendra.rahayu78@company.com", "Hendra", new DateTime(2022, 5, 18, 0, 0, 0, 0, DateTimeKind.Local), "UI/UX Designer", "Rahayu", 14100000m },
                    { 79, "Human Resources", "fitri.rahayu79@company.com", "Fitri", new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Local), "HR Manager", "Rahayu", 7800000m },
                    { 80, "Marketing", "rina.kusuma80@company.com", "Rina", new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Local), "Content Writer", "Kusuma", 18600000m },
                    { 81, "Technology", "rini.wijaya81@company.com", "Rini", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Local), "Software Engineer", "Wijaya", 14900000m },
                    { 82, "Marketing", "rini.sari82@company.com", "Rini", new DateTime(2022, 9, 7, 0, 0, 0, 0, DateTimeKind.Local), "Marketing Executive", "Sari", 17600000m },
                    { 83, "Operations", "rini.gunawan83@company.com", "Rini", new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Local), "Operations Staff", "Gunawan", 10700000m },
                    { 84, "Technology", "eko.utomo84@company.com", "Eko", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Local), "Software Engineer", "Utomo", 23600000m },
                    { 85, "Finance", "fitri.utomo85@company.com", "Fitri", new DateTime(2022, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), "Tax Specialist", "Utomo", 13600000m },
                    { 86, "Human Resources", "siti.sari86@company.com", "Siti", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "HR Manager", "Sari", 24000000m },
                    { 87, "Human Resources", "bambang.putri87@company.com", "Bambang", new DateTime(2021, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), "Recruiter", "Putri", 14500000m },
                    { 88, "Human Resources", "andi.setiawan88@company.com", "Andi", new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), "Recruiter", "Setiawan", 15500000m },
                    { 89, "Technology", "rina.lestari89@company.com", "Rina", new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "QA Engineer", "Lestari", 5800000m },
                    { 90, "Human Resources", "andi.pratama90@company.com", "Andi", new DateTime(2022, 2, 14, 0, 0, 0, 0, DateTimeKind.Local), "HR Manager", "Pratama", 12300000m },
                    { 91, "Technology", "budi.kusuma91@company.com", "Budi", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Local), "UI/UX Designer", "Kusuma", 5800000m },
                    { 92, "Operations", "joko.setiawan92@company.com", "Joko", new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), "Project Manager", "Setiawan", 5800000m },
                    { 93, "Technology", "sri.rahayu93@company.com", "Sri", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Local), "Software Engineer", "Rahayu", 24800000m },
                    { 94, "Technology", "siti.lestari94@company.com", "Siti", new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Local), "Software Engineer", "Lestari", 10000000m },
                    { 95, "Finance", "rina.setiawan95@company.com", "Rina", new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), "Accountant", "Setiawan", 15200000m },
                    { 96, "Human Resources", "sri.utomo96@company.com", "Sri", new DateTime(2026, 4, 7, 0, 0, 0, 0, DateTimeKind.Local), "Recruiter", "Utomo", 15100000m },
                    { 97, "Finance", "agus.lestari97@company.com", "Agus", new DateTime(2022, 4, 21, 0, 0, 0, 0, DateTimeKind.Local), "Accountant", "Lestari", 23100000m },
                    { 98, "Human Resources", "eko.gunawan98@company.com", "Eko", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Local), "Recruiter", "Gunawan", 16600000m },
                    { 99, "Human Resources", "budi.santoso99@company.com", "Budi", new DateTime(2025, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), "HR Manager", "Santoso", 17100000m },
                    { 100, "Technology", "hendra.rahayu100@company.com", "Hendra", new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), "UI/UX Designer", "Rahayu", 9200000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
