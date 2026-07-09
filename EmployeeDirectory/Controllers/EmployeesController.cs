using EmployeeDirectory.Models;
using EmployeeDirectory.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectory.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;

        // Dependency Injection untuk memanggil database melalui AppDbContext
        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // 1. GET: /Employees atau /api/employees
        [HttpGet]
        [Route("Employees")]
        [Route("api/employees")]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string? searchTerm = null)
        {
            if (page < 1) page = 1;

            // Membuka koneksi query (Data belum ditarik ke RAM server)
            IQueryable<Employee> query = _context.Employees;

            // Server-side Case-Insensitive Search (SQL Server target WHERE clause)
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string search = searchTerm.Trim().ToLower();
                query = query.Where(e => e.FirstName.ToLower().Contains(search) ||
                                        e.LastName.ToLower().Contains(search) ||
                                        e.Email.ToLower().Contains(search) ||
                                        // TRIK ENTERPRISE: Menggabungkan FirstName + Nama Belakang untuk pencarian nama lengkap secara utuh
                                        (e.FirstName.ToLower() + " " + e.LastName.ToLower()).Contains(search));
            }

            int totalRecords = await query.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (totalPages == 0) totalPages = 1;

            // Antisipasi jika halaman yang diminta melebihi total halaman pasca penghapusan data
            if (page > totalPages) page = totalPages;

            // Server-side Pagination menggunakan Skip dan Take (Efisien & Cepat!)
            var employeesData = await query
                .OrderBy(e => e.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    FullName = $"{e.FirstName} {e.LastName}",
                    Department = e.Department,
                    JobTitle = e.JobTitle,
                    HireDate = e.HireDate.ToString("yyyy-MM-dd"),
                    // Format mata uang rupiah (IDR) otomatis untuk kenyamanan user lokal
                    Salary = e.Salary.ToString("C", new System.Globalization.CultureInfo("id-ID")),
                    Email = e.Email ?? "-"
                })
                .ToListAsync();

            var viewModel = new EmployeeIndexViewModel
            {
                Employees = employeesData,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalRecords = totalRecords,
                SearchTerm = searchTerm ?? string.Empty
            };

            // Jika dipanggil via AJAX Fetch API (Request dari Javascript), kembalikan data dalam bentuk mentah JSON
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest" || Request.Path.Value.StartsWith("/api/"))
            {
                return Json(viewModel);
            }

            // Jika dibuka biasa lewat browser, render halaman HTML penuh beserta datanya
            return View(viewModel);
        }

        // 2. DELETE: /api/employees/{id}
        [HttpDelete]
        [Route("api/employees/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { message = "ID karyawan tidak valid." });
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound(new { message = "Data karyawan sudah tidak ada atau telah dihapus." });
            }

            try
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Karyawan berhasil dihapus secara permanen." });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Gagal menghapus data karena masalah internal server." });
            }
        }
    }
}
