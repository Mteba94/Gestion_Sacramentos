using Api_SCI.Dtos;
using Api_SCI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api_SCI.Imp
{
    public class PersonaSacramentoService
    {
        public Response GrabaPersonaSacramento(PersonaSacramento grabarSacramento)
        {
            Response resp = new Response();

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
                cmd.CommandText = "sp_agrega_persona_sacramento";

                param = cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 2);
                param.Value = grabarSacramento.operacion;
                param = cmd.Parameters.Add("@i_nombre", SqlDbType.VarChar, 64);
                param.Value = grabarSacramento.nombre;
                param = cmd.Parameters.Add("@i_apellido", SqlDbType.VarChar, 64);
                param.Value = grabarSacramento.apellido;
                param = cmd.Parameters.Add("@i_fecha_nac", SqlDbType.Date);
                param.Value = grabarSacramento.fechaNacimiento;
                param = cmd.Parameters.Add("@i_tipoDoc", SqlDbType.VarChar, 5);
                param.Value = grabarSacramento.tipoDocumento;
                param = cmd.Parameters.Add("@i_documento", SqlDbType.VarChar, 20);
                param.Value = grabarSacramento.numeroDocumento;
                param = cmd.Parameters.Add("@i_telefono", SqlDbType.VarChar, 11);
                param.Value = grabarSacramento.telefono;
                param = cmd.Parameters.Add("@i_direccion", SqlDbType.VarChar, 100);
                param.Value = grabarSacramento.direccion;
                param = cmd.Parameters.Add("@i_fechaCelebra", SqlDbType.Date);
                param.Value = grabarSacramento.fechaCelebracion;
                param = cmd.Parameters.Add("@i_papa", SqlDbType.VarChar, 64);
                param.Value = grabarSacramento.papa;
                param = cmd.Parameters.Add("@i_mama", SqlDbType.VarChar, 64);
                param.Value = grabarSacramento.mama;
                param = cmd.Parameters.Add("@i_padrino", SqlDbType.VarChar, 64);
                param.Value = grabarSacramento.padrino;
                param = cmd.Parameters.Add("@i_madrina", SqlDbType.VarChar, 64);
                param.Value = grabarSacramento.madrina;

                con.Open();

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        resp.codigo = reader.GetInt32(reader.GetOrdinal("codigo"));
                        resp.descripcion = reader["descripcion"].ToString();

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
            }
            finally
            {
                con.Close();
            }
            return resp;
        }

        public List<PersonaSacramento> getSacramentos()
        {
            List<PersonaSacramento> personaSacramentos = new List<PersonaSacramento>();

            SqlConnection con = new SqlConnection();
            SqlCommand cmd;
            SqlParameter param = new SqlParameter();
            DataSet ds = new DataSet();
            SqlDataReader reader;

            try
            {
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
            }
            finally
            {
                con.Close();
            }

            return personaSacramentos;
        }
    }
}
