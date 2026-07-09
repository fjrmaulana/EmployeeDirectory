using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectory.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Inisialisasi generator data acak yang konsisten (Seed: 42)
            var rand = new Random(42);
            var employees = new List<Employee>();

            // Bank data untuk merangkai nama dan jabatan yang realistis
            string[] firstNames = { "Budi", "Siti", "Andi", "Dewi", "Bambang", "Rini", "Eko", "Mega", "Joko", "Rina", "Aditya", "Fitri", "Hendra", "Sri", "Agus" };
            string[] lastNames = { "Santoso", "Wijaya", "Pratama", "Lestari", "Hidayat", "Kusuma", "Sari", "Utomo", "Setiawan", "Putri", "Gunawan", "Rahayu", "Nugroho" };

            var departments = new[]
            {
                new { Name = "Technology", Titles = new[] { "Software Engineer", "QA Engineer", "DevOps Specialist", "UI/UX Designer" } },
                new { Name = "Human Resources", Titles = new[] { "HR Specialist", "Recruiter", "HR Manager" } },
                new { Name = "Finance", Titles = new[] { "Accountant", "Financial Analyst", "Tax Specialist" } },
                new { Name = "Marketing", Titles = new[] { "Marketing Executive", "Content Writer", "SEO Specialist" } },
                new { Name = "Operations", Titles = new[] { "Operations Staff", "Project Manager" } }
            };

            // Loop untuk menghasilkan tepat 100 data karyawan ke database
            for (int i = 1; i <= 100; i++)
            {
                var fName = firstNames[rand.Next(firstNames.Length)];
                var lName = lastNames[rand.Next(lastNames.Length)];
                var deptObj = departments[rand.Next(departments.Length)];
                var jobTitle = deptObj.Titles[rand.Next(deptObj.Titles.Length)];

                // Membuat variasi gaji antara 5.000.000 sampai 25.000.000
                decimal salary = rand.Next(50, 251) * 100000;

                // Membuat variasi tanggal masuk dalam rentang 5 tahun ke belakang
                DateTime hireDate = DateTime.Today.AddDays(-rand.Next(30, 1800));

                employees.Add(new Employee
                {
                    Id = i,
                    FirstName = fName,
                    LastName = lName,
                    Department = deptObj.Name,
                    JobTitle = jobTitle,
                    HireDate = hireDate,
                    Salary = salary,
                    Email = $"{fName.ToLower()}.{lName.ToLower()}{i}@company.com"
                });
            }

            // Menyuntikkan 100 data ke konfigurasi Entity Framework (Data Seeding)
            modelBuilder.Entity<Employee>().HasData(employees);
        }
    }
}
