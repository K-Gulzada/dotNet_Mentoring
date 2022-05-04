using SqlDbIntro.BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDbIntro.BusinessLayer.Services
{
    public interface IEmployeeService
    {
        List<EmployeeInfoVM> GetEmployeeInfo();
        void InsertEmployeeInfoUsingSP(string? employeeName, string firstName, string lastName, string companyName, string? position,
                                        string street, string? city, string? state, string? zipCode);
    }
}
