using System.Data;
using System.Data.SqlClient;

namespace Presentation.Data
{
    public class SQLConnConfig
    {
        public string ConnectionStrings { get; }

        public SQLConnConfig(string Conexion) => ConnectionStrings = Conexion;
    }
}
