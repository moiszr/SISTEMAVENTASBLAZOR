using System.Data;
using Presentation.Entities;
using System.Data.SqlClient;

namespace Presentation.Data
{
    public class D_Users
    {
        public SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=StoreInBlazor;Integrated Security=True;MultipleActiveResultSets=True;Application Name=StoreInBlazor;");

        public List<E_Users> BuscarUsuario(E_Users users)
        {
            List<E_Users> Listar = new List<E_Users>();

            SqlDataReader reader = null!;
            SqlCommand cmd = new SqlCommand("SP_BUSCARUSERNAME", conn);
            cmd.CommandType = CommandType.StoredProcedure; 

            conn.Open();
            cmd.Parameters.AddWithValue("@USERNAME", users.Username);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Listar.Add(new E_Users
                {
                    Id = Convert.ToInt32(reader["ID"])!,
                    Code = Convert.ToString(reader["CODE"])!,
                    Name = Convert.ToString(reader["NAME"])!,
                    LastName = Convert.ToString(reader["LASTNAME"])!,
                    Username = Convert.ToString(reader["USERNAME"])!,
                    Email = Convert.ToString(reader["EMAIL"])!,
                    Password = Convert.ToString(reader["PASSWORD"])!,
                    Avatar = Convert.ToString(reader["AVATAR"])!,
                    Rol_id = Convert.ToInt32(reader["ROL_ID"])!
                });
            }

            conn.Close();
            reader.Close();

            return Listar;
        }

        public void InsertarProductos(E_Users users)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_INSERTUSERS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                cmd.Parameters.AddWithValue("@NAME", users.Name);
                cmd.Parameters.AddWithValue("@LASTNAME", users.LastName);
                cmd.Parameters.AddWithValue("@USERNAME", users.Username);
                cmd.Parameters.AddWithValue("@EMAIL", users.Email);
                cmd.Parameters.AddWithValue("@PASSWORD", users.Password);
                cmd.Parameters.AddWithValue("@AVATAR", users.Avatar);
                cmd.Parameters.AddWithValue("@ROL_ID", users.Rol_id);

                cmd.ExecuteNonQuery();
                conn.Close();
                E_Users.Users.Add(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
    }
}