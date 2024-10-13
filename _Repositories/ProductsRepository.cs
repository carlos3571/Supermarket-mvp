using Supermarket_mvp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_mvp._Repositories
{
    internal class ProductsRepository: BaseRepository, IProductRepository
    {
        public ProductsRepository(string connectionstring) 
        {
            this.connectionString = connectionstring;
        }

        public void Add(Product producModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    // Ajustamos los nombres de las columnas según la estructura de la tabla Categories
                    command.CommandText = "INSERT INTO Products (,Name,Description ,Price,CategoryId) VALUES (@Name, @Description, @Price, @CategoryId)";
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = producModel.Name;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = producModel.Description;
                    command.Parameters.Add("@Price", SqlDbType.NVarChar).Value = producModel.Price;
                    command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = producModel.CategoryId;
                    command.ExecuteNonQuery();

                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    // Ajustamos los nombres de las columnas según la estructura de la tabla Categories
                    command.CommandText = "DELETE FROM Products where ProductId = @id";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.ExecuteNonQuery();

                }
            }
        }

        public void Edit(Product producModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    // Ajustamos los nombres de las columnas según la estructura de la tabla Categories
                    command.CommandText = @"UPDATE Products
                                       SET Name =@Name,
                                       Description = @Description
                                       Price = @Price
                                       CategoryId = @CategoryId
                                       WHERE ProviderId =@id";
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = producModel.Name;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = producModel.Description;
                    command.Parameters.Add("@Price", SqlDbType.NVarChar).Value = producModel.Price;
                    command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = producModel.CategoryId;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = producModel.ProductId;
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Product> GetAll()
        {
            var productsList = new List<Product>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    // Ajustamos los nombres de las columnas según la estructura de la tabla Categories
                    command.CommandText = "SELECT * FROM Providers ORDER BY ProviderId DESC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Product();
                            product.ProductId = (int)reader["ProductId"];
                            product.Description = reader["Description"].ToString();
                            product.Name = reader["Name"].ToString();
                            product.Price = (int)reader["Price"];
                            product.CategoryId = (int)reader["CategoryId"];
                            productsList.Add(product);
                        }
                    }
                }
            }
            return productsList;
        }

        public IEnumerable<Product> GetByValue(string value)
        {

            var productsList = new List<Product>();
            int ProductId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            int CategoryId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            decimal Price = decimal.TryParse(value, out var parsedPrice) ? parsedPrice : 0.0m;
            string Name = value;
            string Description = value;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * FROM Products
                                        WHERE ProductId = @id or Name LIKE @name+ '%'
                                        ORDER BY ProductId DESC";
                command.Parameters.Add("@ProductId", SqlDbType.Int).Value = ProductId;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
                command.Parameters.Add("@Price",SqlDbType.Decimal).Value= Price;
                command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = CategoryId;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product();
                        product.ProductId = (int)reader["ProductId"];
                        product.Name = reader["Name"].ToString();
                        product.Description = reader["Description"].ToString();
                        product.Price = (decimal)reader["Price"];
                        product.CategoryId = (int)reader["CategoryId"];
                        productsList.Add(product);
                    }
                }
            }
            return productsList;
        }
    }
}
