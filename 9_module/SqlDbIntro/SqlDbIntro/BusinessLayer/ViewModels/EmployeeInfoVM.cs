namespace SqlDbIntro.BusinessLayer.ViewModels
{
    public class EmployeeInfoVM
    {
        public int EmployeeId { get; set; }
        public string? EmployeeFullName { get; set; }
        public string EmployeeFullAddress { get; set; }
        public string EmployeeCompanyInfo { get; set; }
    }
}