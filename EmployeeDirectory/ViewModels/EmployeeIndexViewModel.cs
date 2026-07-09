namespace EmployeeDirectory.ViewModels
{
    public class EmployeeIndexViewModel
    {
        public List<EmployeeDto> Employees { get; set; } = new();
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public string SearchTerm { get; set; } = string.Empty;
    }
}
