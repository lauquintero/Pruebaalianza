using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using WebServiceSoap.Aplication;

namespace WebServiceSoap.DataAccess
{
    public class PostgreDataAccess
    {
        public string GetConnection() {

            return ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();
        }

        public int CreateCliente(DAOClients Cliente)
        {
            int result = 0;
            try
            {               
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = GetConnection();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into clients (BusinessID,Email,Phone,DataAdded,StartDate,EndDate,State)" +
                                      "values(@BusinessID,@Email,@Phone,@DataAdded,@StartDate,@EndDate,@State)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@BusinessID", Cliente.BusinessID));
                    cmd.Parameters.Add(new NpgsqlParameter("@Email", Cliente.Email));
                    cmd.Parameters.Add(new NpgsqlParameter("@Phone", Cliente.Phone));
                    cmd.Parameters.Add(new NpgsqlParameter("@DataAdded", Cliente.DataAdded));
                    cmd.Parameters.Add(new NpgsqlParameter("@StartDate", Cliente.StartDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@EndDate", Cliente.EndDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@State", Cliente.State));
                    result = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();                 
                }
            }
            catch (Exception ex)
            {
                Logger.LogWrite("CreateCliente", ex.Message + "---" + ex.StackTrace);
            }

            return result;
        }

        
        public List<DAOClients> ListarClientes()
        {
            DataTable dt = new DataTable();
            try 
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = GetConnection();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from clients";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    
                    da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();                    
                }
            }
            catch (Exception ex)
            {
                Logger.LogWrite("ListarClientes", ex.Message + "---" + ex.StackTrace);
            }

            return MappingInDao(dt);
        }

        private List<DAOClients> MappingInDao(DataTable table) {

            List<DAOClients> Listcliente = new List<DAOClients>();

            foreach (DataRow item in table.Rows)
            {
                DAOClients nuevoCliente = new DAOClients()
                {
                    SharedKey = Convert.ToInt32(item["SharedKey"].ToString()),
                    BusinessID = item["BusinessID"].ToString(),
                    Email = item["Email"].ToString(),
                    Phone = item["Phone"].ToString(),
                    DataAdded = Convert.ToDateTime(item["DataAdded"].ToString()),
                    StartDate = Convert.ToDateTime(item["StartDate"].ToString()),
                    EndDate = Convert.ToDateTime(item["EndDate"].ToString()),
                    State = item["State"].ToString().ToLower().Trim() == "Activo" ? true : false
                };

                Listcliente.Add(nuevoCliente);
            }

            return Listcliente;
        }

        public bool ActualizarCliente(DAOClients Cliente)
        {
            int result = 0;
            try 
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = GetConnection();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "update clients set BusinessID=@BusinessID, Email=@Email,"+
                                      "Phone = @Phone, DataAdded = @DataAdded,StartDate = @StartDate, " +
                                      "EndDate = @EndDate,State = @State " +
                                       " where SharedKey = @SharedKey";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@SharedKey", Cliente.SharedKey));
                    cmd.Parameters.Add(new NpgsqlParameter("@BusinessID", Cliente.BusinessID));
                    cmd.Parameters.Add(new NpgsqlParameter("@Email", Cliente.Email));
                    cmd.Parameters.Add(new NpgsqlParameter("@Phone", Cliente.Phone));
                    cmd.Parameters.Add(new NpgsqlParameter("@DataAdded", Cliente.DataAdded));
                    cmd.Parameters.Add(new NpgsqlParameter("@StartDate", Cliente.StartDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@EndDate", Cliente.EndDate));
                    cmd.Parameters.Add(new NpgsqlParameter("@State", Cliente.State));
                    result = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();                    
                }
            }
            catch (Exception ex) {
                Logger.LogWrite("ActualizarCliente", ex.Message + "---" + ex.StackTrace);
            }

            if (result == 1) { return true; }
            else { return false; }
        }

        public bool BorrarCliente (int SharedKey)
        {
            int result = 0;
            try 
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = GetConnection();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "Delete from clients where SharedKey=@SharedKey";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@SharedKey", Convert.ToInt32(SharedKey)));
                    result =cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();                 
                }
            }
            catch (Exception ex)
            {
                Logger.LogWrite("BorrarCliente", ex.Message + "---" + ex.StackTrace);
            }

            if (result == 1) { return true; }
            else { return false; }
        }
    }
}