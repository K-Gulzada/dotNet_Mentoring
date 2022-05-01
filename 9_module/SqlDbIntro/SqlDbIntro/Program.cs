
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SqlDbIntro.DataAccess;
using SqlDbIntro.Entities;
using System.Data;

namespace SqlDbIntro
{
    class Program
    {
        private const string SP_INSERTEMPLOYEEINFO_NAME = "SP_InsertEmployeeInfo";
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(ContextOptionsProvider.ConnectionString);

            try
            {
                connection.Open();
                //  CreateEmployeeInfoView(connection);
                var employeeName = "empName_1";
                var firstName = "firstName_1";
                var lastName = "lastName_1";
                var companyName = "companyName_1_length_More_Than_20_should_be_trancated";
                var position = "position_1";
                var street = "street_1";
                var city = "city_1";
                string? state = null;
                string? zipCode = null;

                if (firstName == null || lastName == null || companyName == null || street == null || firstName.Trim().Length < 1 || lastName.Trim().Length < 1)
                {
                    Console.WriteLine("Проверьте данные на правильность");
                }
                else
                {
                    InsertEmployeeInfo(employeeName, firstName, lastName, companyName, position, street, city, state, zipCode, connection);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            Console.ReadKey();
        }

        static void CreateEmployeeInfoView(SqlConnection connection)
        {
            var viewName = "EmployeeInfo_3";
            var fullNameColumnName = "EmployeeFullName";
            var addressColumnName = "EmployeeFullAddress";
            var companyInfoColumnName = "EmployeeCompanyInfo";

            var commandString = string.Format(@"create view {0} as select top 5 e.Id, " +
                "isnull(e.EmployeeName, CONCAT(p.FirstName, ' ', p.LastName)) as '{1}'," +
                "CONCAT(a.ZipCode, '_', a.State, ', ', a.City, '-', a.Street) as '{2}', " +
                "CONCAT(e.CompanyName, ' ', e.Position) as '{3}' " +
                "from Employees e " +
                "join People p on p.Id = e.PersonId " +
                "join Addresses a on a.Id = e.AddressId" +
                "order by a.City", viewName, fullNameColumnName, addressColumnName, companyInfoColumnName);
            SqlCommand command = new SqlCommand(commandString, connection);
            command.ExecuteNonQuery();
        }

        static void InsertEmployeeInfo(string? employeeName, string firstName, string lastName, string companyName, string? position,
                                        string street, string? city, string? state, string? zipCode, SqlConnection connection)
        {
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand(SP_INSERTEMPLOYEEINFO_NAME, connection);
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeName", employeeName);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@CompanyName", companyName);
                command.Parameters.AddWithValue("@Position", position);
                command.Parameters.AddWithValue("@Street", street);
                command.Parameters.AddWithValue("@CIty", city);
                command.Parameters.AddWithValue("@State", state);
                command.Parameters.AddWithValue("@ZipCode", zipCode);
                command.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("Employee Info was inserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
        }
    }
}