using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SqlDbIntro.BusinessLayer.ViewModels;
using SqlDbIntro.DataLayer.DataAccess;
using SqlDbIntro.DataLayer.Repositories.Interfaces;

namespace SqlDbIntro.BusinessLayer.Services
{
    public class EmployeeServiceImpl : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        private IMapper _mapper;
        private const string SP_INSERTEMPLOYEEINFO_NAME = "SP_InsertEmployeeInfo";

        public EmployeeServiceImpl(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public List<EmployeeInfoVM> GetEmployeeInfo()
        {
            var employees = _employeeRepository.GetAll();
            var employeeInfos = new List<EmployeeInfoVM>();

            foreach (var employee in employees)
            {
                var employeeInfo = new EmployeeInfoVM();
                employeeInfo.EmployeeId = employee.Id;

                if (employee.EmployeeName == null)
                {
                    employeeInfo.EmployeeFullName = employee.Person.FirstName + "  " + employee.Person.LastName;
                }
                else
                {
                    employeeInfo.EmployeeFullName = employee.EmployeeName;
                }

                employeeInfo.EmployeeFullAddress = employee.Address.Street + " " + employee.Address.City + " " + employee.Address.State + " " + employee.Address.ZipCode;
                employeeInfo.EmployeeCompanyInfo = employee.CompanyName + " " + employee.Position;
                employeeInfos.Add(employeeInfo);
                employeeInfo = null;
            }

            return employeeInfos;
        }

        public void InsertEmployeeInfoUsingSP(string? employeeName, string firstName, string lastName, string companyName, string? position,
                                        string street, string? city, string? state, string? zipCode)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqlDbContext>();
            var options = optionsBuilder.Options;

            using (var context = new SqlDbContext(options))
            {
                var eName = new SqlParameter("@EmployeeName", employeeName);
                var fName = new SqlParameter("@FirstName", firstName);
                var lName = new SqlParameter("@LastName", lastName);
                var cName = new SqlParameter("@CompanyName", companyName);
                var pos = new SqlParameter("@Position", position);
                var st = new SqlParameter("@Street", street);
                var ct = new SqlParameter("@City", city);
                var stateName = new SqlParameter("@State", state);
                var zCode = new SqlParameter("@ZipCode", zipCode);

                context.Database.ExecuteSqlRaw($"exec {SP_INSERTEMPLOYEEINFO_NAME} @EmployeeName , @FirstName , @LastName , @CompanyName, @Position, @Street, @City, @State, @ZipCode",
                                                    eName, fName, lName, cName, pos, st, ct, stateName, zCode);
            }
        }
    }
}
