using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        private string password2 = "";

        public int Id { get => id; set => id = value; }

        public string Code { get => code; set => code = value; }
        [Required (ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(30, ErrorMessage = "El nombre es demasiado largo")]
        public string Name { get => name; set => name = value; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        [StringLength(70, ErrorMessage = "El apellido es demasiado largo")]
        public string LastName { get => lastName; set => lastName = value; }

        [Required (ErrorMessage = "El campo Nombre de usuario es obligatorio.")]
        [StringLength(20, ErrorMessage = "El nombre de usuario es demasiado largo")]
        public string Username { get => username; set => username = value; }

        [Required(ErrorMessage = "El campo de correo electrónico es obligatorio.")]
        [StringLength(128, ErrorMessage = "El correo electronico es demasiado largo")]
        public string Email { get => email; set => email = value; }

        public string Password { get => password; set => password = value; }

        public string Avatar { get => avatar; set => avatar = value; }

        public int Rol_id { get => rol_id; set => rol_id = value; }

        [Required(ErrorMessage = "El campo de Contraseña es obligatorio.")]
        [MinLength(8, ErrorMessage = "Su contraseña es demasiada corta")]
        public string Password2 { get => password2; set => password2 = value; }

        public static List<E_Users> Users = new List<E_Users>();
    }
}
