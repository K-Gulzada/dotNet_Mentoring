using Microsoft.Extensions.DependencyInjection;
using SqlDbIntro.BusinessLayer.Services;

namespace SqlDbIntro
{
    public class CommonController
    {
        private static ConfigurationService configurationService = new ConfigurationService();
        private static IServiceProvider _serviceProvider = configurationService.Register();
        public void GetEmployeeInfoList()
        {
            IEmployeeService employeeService = _serviceProvider.GetService<IEmployeeService>();
            var emplyeeInfos = employeeService.GetEmployeeInfo();
            foreach (var emplyeeInfo in emplyeeInfos)
            {
                Console.WriteLine(emplyeeInfo.EmployeeId + "\n" + emplyeeInfo.EmployeeFullName + "\n" + emplyeeInfo.EmployeeFullAddress + "\n" + emplyeeInfo.EmployeeCompanyInfo);
                Console.WriteLine("=====================================================================================================");
            }
        }

        public void InsertEmployeeInfo(string? employeeName, string firstName, string lastName, string companyName, string? position,
                                        string street, string? city, string? state, string? zipCode)
        {
            IEmployeeService employeeService = _serviceProvider.GetService<IEmployeeService>();
            employeeService.InsertEmployeeInfoUsingSP(employeeName, firstName, lastName, companyName, position, street, city, state, zipCode);
        }
    }
}
