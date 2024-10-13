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
    internal class CategoriesRepository : BaseRepository, ICategoriesRepository
    {

        public CategoriesRepository(string connectionstring) {
            this.connectionString = connectionstring;
        }

        public void Add(Categories categoriesModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    // Ajustamos los nombres de las columnas según la estructura de la tabla Categories
                    command.CommandText = "INSERT INTO Categories (Name, Description) VALUES (@name, @description)";
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = categoriesModel.Name;
                    command.Parameters.Add("@description", SqlDbType.NVarChar).Value = categoriesModel.Description;
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
                    command.CommandText = "DELETE FROM Categories where CategoryId = @id";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.ExecuteNonQuery();

                }
            }
        }

        public void Edit(Categories categoriesModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    // Ajustamos los nombres de las columnas según la estructura de la tabla Categories
                    command.CommandText = @"UPDATE Categories
                                       SET Name =@Name,
                                       Description = @Description
                                       WHERE CategoryId =@id";
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = categoriesModel.Name;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = categoriesModel.Description;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = categoriesModel.CategoryId;
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Categories> GetAll()
        {
            var categoriesList = new List<Categories>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    // Ajustamos los nombres de las columnas según la estructura de la tabla Categories
                    command.CommandText = "SELECT * FROM Categories ORDER BY CategoryId DESC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var categories = new Categories();
                            categories.CategoryId = (int)reader["CategoryId"];
                            categories.Name = reader["Name"].ToString();
                            categories.Description = reader["Description"].ToString();
                            categoriesList.Add(categories);
                        }
                    }
                }
            }
            return categoriesList;
        }

        public IEnumerable<Categories> GetByValue(string value)
        {
            var categoriesList = new List<Categories>();
            int categoryId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string Name = value;
            string Description = value;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * FROM Categories
                                        WHERE CategoryId = @id or Name LIKE @name+ '%'
                                        ORDER BY CategoryId DESC";
                command.Parameters.Add("@id", SqlDbType.Int).Value = categoryId;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                command.Parameters.Add("@Description", SqlDbType.NVarChar).Value= Description;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var categories = new Categories();
                        categories.CategoryId = (int)reader["CategoryId"];
                        categories.Name = reader["Name"].ToString();
                        categories.Description = reader["Description"].ToString();
                        categoriesList.Add(categories);
                    }
                }
            }
            return categoriesList;
        }
    }
}
