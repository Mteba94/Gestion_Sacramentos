using Api_SCI.Dtos;
using Api_SCI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api_SCI.Imp
{
    public class SacramentoService
    {
        
        public Boolean GrabaSacramento(Sacramento grabarSacramento)
        {

            Boolean result = false;

            SqlConnection con = new SqlConnection();
            SqlCommand cmd;
            SqlParameter param = new SqlParameter();
            DataSet ds = new DataSet();
            SqlDataReader reader;

            try
            {
                var appSettings = AppSettingsJson.GetAppSettings();
                var connectionString = appSettings["ConnectionStrings:SQLConnection"];

                con.ConnectionString = connectionString;
                cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_agrega_sacramento";

                param = cmd.Parameters.Add("@i_nombre", SqlDbType.VarChar, 64);
                param.Value = grabarSacramento.nombre;
                param = cmd.Parameters.Add("@i_descripcion", SqlDbType.VarChar, 500);
                param.Value = grabarSacramento.descripcion;
                param = cmd.Parameters.Add("@i_requerimiento", SqlDbType.VarChar, 500);
                param.Value = grabarSacramento.requerimiento;

                con.Open();

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var codigo = reader["codigo"];
                        var descripcion = reader["descripcion"];

                        Console.WriteLine("Codigo: " + codigo + "Descripcion: " + descripcion);
                    }

                    result = true;
                }
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Error interno: " + ex.InnerException.Message);
                }
            }
            finally
            {
                con.Close();
            }

            return result;
        }

        public List<Sacramento> getSacramentos()
        {
            List<Sacramento> sacramentos = new List<Sacramento>();

            SqlConnection con = new SqlConnection();
            SqlCommand cmd;
            SqlParameter param = new SqlParameter();
            DataSet ds = new DataSet();
            SqlDataReader reader;

            try
            {
                var appSettings = AppSettingsJson.GetAppSettings();
                var connectionString = appSettings["ConnectionStrings:SQLConnection"];

                con.ConnectionString = connectionString;
                cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ver_sacramento";

                con.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Sacramento sacramento = new Sacramento();
                        sacramento.nombre = reader["nombre"].ToString();
                        sacramento.descripcion = reader["descripcion"].ToString();
                        sacramento.requerimiento = reader["requerimiento"].ToString();

                        sacramentos.Add(sacramento);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Error interno: " + ex.InnerException.Message);
                }
            }
            finally
            {
                con.Close();
            }

            return sacramentos;
        }


    }
}
