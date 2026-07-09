namespace EmployeeDirectory.ViewModels
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string HireDate { get; set; } = string.Empty;
        public string Salary { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
