using AdoNetFundamentals.Entities;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetFundamentals.Repositories
{
    public class ProductRepository : IProductRepository
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
                    while (data.Read())
                    {
                        var product = new Product(data["Name"].ToString(), data["Description"].ToString(), Convert.ToSingle(data["Weight"]), Convert.ToSingle(data["Height"]), Convert.ToSingle(data["Width"]), Convert.ToSingle(data["Length"]));
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
                    while (data.Read())
                    {
                        product = new Product(data["Name"].ToString(), data["Description"].ToString(), Convert.ToSingle(data["Weight"]), Convert.ToSingle(data["Height"]), Convert.ToSingle(data["Width"]), Convert.ToSingle(data["Length"]));
                    }
                }

                return product;
            }
        }

    }
}
