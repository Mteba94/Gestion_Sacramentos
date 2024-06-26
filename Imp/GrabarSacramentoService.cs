using Api_SCI.Dtos;
using Api_SCI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api_SCI.Imp
{
    public class GrabarSacramentoService
    {
        
        public Boolean GrabaSacramento(GrabarSacramento grabarSacramento)
        {

            Boolean result = false;

            SqlConnection con = new SqlConnection();
            SqlCommand cmd;
            SqlParameter param = new SqlParameter();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                var appSettings = AppSettingsJson.GetAppSettings();
                var connectionString = appSettings["ConnectionStrings:SQLConnection"];

                //con.ConnectionString = "Server=DESKTOP-HGGBRC3;Database=sgi_sacramentos; User Id = sa; Password = Tebalan04; TrustServerCertificate=True ";
                con.ConnectionString = connectionString;
                cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_agrega_sacramento";

                param = cmd.Parameters.Add("@i_nombre", SqlDbType.VarChar, 64);
                param.Value = grabarSacramento.nombre;
                param = cmd.Parameters.Add("@i_descripcion", SqlDbType.VarChar, 64);
                param.Value = grabarSacramento.descripcion;
                param = cmd.Parameters.Add("@i_requerimiento", SqlDbType.VarChar, 64);
                param.Value = grabarSacramento.requerimiento;

                da.SelectCommand = cmd;
                con.Open();
                da.Fill(ds);

                if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
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
    }
}
