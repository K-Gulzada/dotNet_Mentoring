using AdoNetFundamentals.Entities;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetFundamentals.Repositories
{
    public class ProductRepository:IProductRepository
    {
        public List<Product> GetAllProducts()
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();

                string commandText = "select p.Name, p.Description, p.Weight, p.Height, p.Width, p.Length from Products p";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("AllProducts: ");
                SqlDataReader data = command.ExecuteReader();

                var products = new List<Product>();

                if (data.HasRows)
                {
                    Console.WriteLine($"{data.GetName(0)} \t | \t {data.GetName(1)} \t | \t {data.GetName(2)} \t | \t {data.GetName(3)}  \t | \t {data.GetName(4)} \t | \t {data.GetName(5)}");

                    while (data.Read())
                    {
                        Console.WriteLine($"{data.GetValue(0)} \t | \t {data.GetValue(1)}  \t | \t {data.GetValue(2)}  \t | \t {data.GetValue(3)}  \t | \t {data.GetValue(4)}  \t | \t {data.GetValue(5)}");
                        var product = new Product(data.GetValue(0).ToString(), data.GetValue(1).ToString(), Convert.ToSingle(data.GetValue(2)), Convert.ToSingle(data.GetValue(3)), Convert.ToSingle(data.GetValue(4)), Convert.ToSingle(data.GetValue(5)));
                        products.Add(product);
                    }
                }

                return products;
            }
        }

        public void AddProduct(string name, string description, float weight, float height, float width, float length)
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();
                string commandText = $"insert into Products(Name, Description, Weight, Height, Width, Length) " +
                                        $"values('{name}', '{description}', {weight}, {height}, {width}, {length})";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.ExecuteNonQuery();
                Console.WriteLine("successfully inserted data to Products table: ");
            }
        }

        public void UpdateProduct(string columnName, string value, int id)
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();
                string commandText = $"update Products set {columnName} = '{value}' where ID = {id}";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.ExecuteNonQuery();
                Console.WriteLine("Products table successfully updated");
            }
        }

        public void DeleteProductById(int id)
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();
                string commandText = $"delete Products where ID = {id}";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Product successfully deleted");
            }
        }

        public Product GetProductByName(string productName)
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();
                string procedure = "SP_GetProductByName";
                SqlCommand command = new SqlCommand(procedure, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = command.Parameters.Add("@Name", SqlDbType.NVarChar);
                param.Value = productName;
                command.ExecuteNonQuery();

                SqlDataReader data = command.ExecuteReader();
                Product product = null;

                if (data.HasRows)
                {
                    Console.WriteLine($"{data.GetName(0)} \t | \t {data.GetName(1)} \t | \t {data.GetName(2)} \t | \t {data.GetName(3)}  \t | \t {data.GetName(4)} \t | \t {data.GetName(5)}");

                    while (data.Read())
                    {
                        Console.WriteLine($"{data.GetValue(0)} \t | \t {data.GetValue(1)}  \t | \t {data.GetValue(2)}  \t | \t {data.GetValue(3)}  \t | \t {data.GetValue(4)}  \t | \t {data.GetValue(5)}");
                        product = new Product(data.GetValue(0).ToString(), data.GetValue(1).ToString(), Convert.ToSingle(data.GetValue(2)), Convert.ToSingle(data.GetValue(3)), Convert.ToSingle(data.GetValue(4)), Convert.ToSingle(data.GetValue(5)));
                    }
                }

                return product;
            }
        }

    }
}
