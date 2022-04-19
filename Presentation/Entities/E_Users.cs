using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Entities
{
    public class E_Users
    {
        private int id;
        private string code = "";
        private string name = "";
        private string lastName = "";
        private string username = "";
        private string email = "";
        private string password = "";
        private string avatar = "";
        private int rol_id;

        public int Id { get => id; set => id = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Avatar { get => avatar; set => avatar = value; }
        public int Rol_id { get => rol_id; set => rol_id = value; }
    }
}
