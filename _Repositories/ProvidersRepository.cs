using Supermarket_mvp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Supermarket_mvp._Repositories
{
    internal class ProvidersRepository : BaseRepository, IProvidersRepository
    {
        public ProvidersRepository(string connectionstring)
        {
            this.connectionString = connectionstring;
        }

        public void Add(Providers provider)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Providers (Name, Address, PhoneNumber, Email) 
                                    VALUES (@Name, @Address, @PhoneNumber, @Email)";
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = provider.Name;
                    command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = provider.Address;
                    command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = provider.PhoneNumber;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = provider.Email;

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
                    command.CommandText = "DELETE FROM providers where ProviderId = @id";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.ExecuteNonQuery();

                }
            }
        }

        public void Edit(Providers provider)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Providers
                                    SET Name = @Name,
                                        Address = @Address,
                                        PhoneNumber = @PhoneNumber,
                                        Email = @Email
                                    WHERE ProviderId = @ProviderId";

                    // Asegurarse de agregar los parámetros necesarios
                    command.Parameters.Add("@ProviderId", SqlDbType.Int).Value = provider.ProviderId;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = provider.Name;
                    command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = provider.Address;
                    command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = provider.PhoneNumber;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = provider.Email;

                    command.ExecuteNonQuery();
                }
            }
        }


        public IEnumerable<Providers> GetAll()
        {
            var providersList = new List<Providers>();
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
                            var providers = new Providers();
                            providers.ProviderId = (int)reader["ProviderId"];
                            providers.Address = reader["Address"].ToString();
                            providers.Name = reader["Name"].ToString();
                            providers.Email = reader["Email"].ToString();
                            providers.PhoneNumber = reader["PhoneNumber"].ToString();
                            providersList.Add(providers);
                        }
                    }
                }
            }
            return providersList;
        }

        public IEnumerable<Providers> GetByValue(string value)
        {
            var providersList = new List<Providers>();
            int ProviderId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string Name = value;
            string Email = value;
            string PhoneNumber = value; 
            string Address = value;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * FROM Providers
                                        WHERE ProviderId = @id or Name LIKE @Name+ '%'
                                        ORDER BY ProviderId DESC";
                command.Parameters.Add("@id", SqlDbType.Int).Value = ProviderId;
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
                command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = PhoneNumber;
                command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Address;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var providers = new Providers();
                        providers.ProviderId = (int)reader["ProviderId"];
                        providers.Name = reader["Name"].ToString();
                        providers.Address = reader["Address"].ToString();
                        providers.PhoneNumber = reader["PhoneNumber"].ToString();
                        providers.Email = reader["Email"].ToString();
                        providersList.Add(providers);
                    }
                }
            }
            return providersList;
        }
    }
}
