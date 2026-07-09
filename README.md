# 👥 Enterprise Employee Directory - ASP.NET Core MVC Full-Stack

A high-performance, single-page experience Employee Directory built using **ASP.NET Core MVC**, **Entity Framework Core (Code-First)**, and **SQL Server Express**. This project showcases efficient server-side processing combined with asynchronous frontend manipulation using **Vanilla JavaScript** (No Frameworks).

---

## 🚀 Key Features & Architectural Highlights

### ⚡ 1. High-Efficiency Server-Side Processing
- **Database-Level Pagination:** Leverages `.Skip()` and `.Take()` operations on `IQueryable` to fetch exactly 10 records per page. This eliminates memory bloating by preventing large datasets from loading into the server's RAM.
- **Advanced Multi-Property Search:** Features a backend-driven, case-insensitive search engine. It dynamically evaluates query expressions to look up employees by `FirstName`, `LastName`, `Email`, or a combined full name string directly inside the SQL `WHERE` clause.
- **State Optimization:** Automatically resets the navigation state back to Page 1 upon every new search execution to preserve a high-quality User Experience (UX).

### 🎨 2. Modern Single-Page Experience (SPA-Feel)
- **Pure Vanilla JavaScript:** Built natively without relying on jQuery or heavy frameworks. The client-side logic is beautifully decoupled into a dedicated file (`wwwroot/js/employee.js`).
- **Asynchronous Deletion (Fetch API):** Employee removal triggers a secure `HTTP DELETE` request. Upon success (200 OK), the specific table row is instantly dropped from the DOM without a full page postback.
- **Custom Bootstrap 5 Confirmation Modal:** Replaced rigid native browser alerts with a polished, animated Bootstrap modal dialog triggered via JavaScript API, ensuring a seamless visual flow.
- **Smart Debouncing:** Keyup search input listener is debounced by `300ms` to protect the remote database from unnecessary query flooding during typing.

### 🛡️ 3. Enterprise & Security Practices
- **Strict Data Decoupling:** Relies fully on strongly-typed ViewModels and DTOs to stream data between layers. Zero usage of fragile structures like `ViewBag`, `ViewData`, or `TempData`.
- **Thread Optimization:** Fully implements the `async/await` asynchronous pattern across all database I/O transactions to eliminate thread starvation.
- **Data Seeding:** Automatically seeds 100 mock employee records with realistic Indonesian names and logical job-to-department alignment via EF Core `OnModelCreating`.

---

## 🛠️ Tech Stack & Architecture

- **Backend:** .NET 8.0 / 9.0 (ASP.NET Core MVC)
- **ORM:** Entity Framework Core
- **Database:** Remote SQL Server Express Instance
- **Frontend UI:** Vanilla JavaScript, HTML5, Bootstrap 5

---

## 🔧 Installation & Connection Configuration

Follow these simple steps to host and run this project locally:

1. **Clone the repository:**
   ```bash
   git clone https://github.com
   cd Enterprise-Employee-Directory-EFCore
   ```

2. **Configure Connection String:**
   Open `appsettings.json` and replace the placeholder credentials with your SQL Server parameters:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER_IP,1433;Database=EmployeeDirectoryDb;User ID=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;MultipleActiveResultSets=true"
   }
   ```

3. **Run Migrations & Seed Data:**
   Open your Package Manager Console in Visual Studio and execute:
   ```powershell
   Update-Database
   ```
   *(Or run `dotnet ef database update` via your command line interface).*

4. **Launch the Application:**
   Press `F5` in Visual Studio or execute `dotnet run` in your terminal.

---

## 🔗 API Endpoint Specifications

| Action | HTTP Verb | Route | Query Parameters | Response Format |
| :--- | :--- | :--- | :--- | :--- |
| **Get Employees** | `GET` | `/api/employees` | `page` (int), `searchTerm` (string) | JSON (Paginated List & Metadata) |
| **Delete Employee** | `DELETE` | `/api/employees/{id}` | `id` (int) | JSON (Success/Error Message) |
