using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Supermarket_mvp.Models;
using System.Data;
using System.Data.SqlClient;


namespace Supermarket_mvp._Repositories
{
    internal class PayModeRepository : BaseRepository, IPayModeRepository
    {
        public PayModeRepository(string connectionstring) 
        {
            this.connectionString = connectionstring;
        }
        //public void Add(PayModeModel payModeModel)
        //{
        //    using(var connection = new SqlConnection(connectionString)) 
        //    using(var command = new SqlConnection())
        //    {
        //        connection.Open();
        //        command.Connection = connection;
        //        command.commandText = "insertar en los valores del modo de pago (@nombre, @observación)";
        //        command.Parameters.Add("@name", sqlDbType.NVarChar).Value = payModeModel.Name;
        //        command.Parameters.Add("@observation", SqlDbType.NVarChar).value = payModeModel.Observation;
        //        command.ExecuteNonQuery();

        //    }

        //}

        public void Add(PayModeModel payModeModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO PayMode (Name, Observation) VALUES (@name, @observation)";
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = payModeModel.Name;
                    command.Parameters.Add("@observation", SqlDbType.NVarChar).Value = payModeModel.Observation;
                    command.ExecuteNonQuery();
                }
            }
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(PayModeModel payModeModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PayModeModel> GetAll()
        {
            var payModeList = new List<PayModeModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM PayMode ORDER BY Pay_Mode_Id DESC";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var payModeModel = new PayModeModel();
                        payModeModel.Id = (int)reader["Pay_Mode_Id"];
                        payModeModel.Name = reader["Pay_Mode_Name"].ToString();
                        payModeModel.Observation = reader["Pay_Mode_Observation"].ToString();
                        payModeList.Add(payModeModel);
                    }
                }
            }

            return payModeList;


        }

        public IEnumerable<PayModeModel> GetByValue(string value)
        {
            var payModeList = new List<PayModeModel>();
            int payModeId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string payModeName = value;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * FROM PayMode
                                        WHERE Pay_Mode_Id = @id or Pay_Mode_Name LIKE @name+ '%'
                                        ORDER BY Pay_Mode_Id DESC";
                command.Parameters.Add("@id", SqlDbType.Int).Value = payModeId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = payModeName;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var payModeModel = new PayModeModel();
                        payModeModel.Id = (int)reader["Pay_Mode_Id"];
                        payModeModel.Name = reader["Pay_Mode_Name"].ToString();
                        payModeModel.Observation = reader["Pay_Mode_Observation"].ToString();
                        payModeList.Add(payModeModel);
                    }
                }
            }
            return payModeList;
        }
    }
}
