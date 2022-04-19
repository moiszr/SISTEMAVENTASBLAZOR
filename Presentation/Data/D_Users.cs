using System.Data;
using Presentation.Entities;
using System.Data.SqlClient;

namespace Presentation.Data
{
    public class D_Users : SQLConnConfig
    {
        public D_Users(string Conexion) : base(Conexion)
        {
        }

        public List<E_Users> GetUser()
        {
            List<E_Users> Listar = new List<E_Users>();
            using (SqlConnection conn = new SqlConnection(ConnectionStrings))
            {
                SqlDataReader reader = null!;
                SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE username = @username", conn);
                cmd.CommandType = CommandType.StoredProcedure; 

                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Listar.Add(new E_Users
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Code = Convert.ToString(reader["code"]),
                        Name = Convert.ToString(reader["name"]),
                        LastName = Convert.ToString(reader["last_name"]),
                        Username = Convert.ToString(reader["username"]),
                        Email = Convert.ToString(reader["email"]),
                        Password = Convert.ToString(reader["password"]),
                        Avatar = Convert.ToString(reader["avatar"]),
                        Rol_id = Convert.ToInt32(reader["rol_id"])
                    });
                }

                conn.Close();
                reader.Close();
            }
            return Listar;
        }

        public void InsertarProductos(E_Users users)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStrings))
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
            }
        }
    }
}