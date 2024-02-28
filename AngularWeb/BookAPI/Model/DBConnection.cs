using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace BookAPI.Model
{
    public class DBConnection
    {
        private readonly IConfiguration Config;
        public DBConnection(IConfiguration _con)
        {
            Config = _con;
        }
        public SqlConnection BookCon()
        {
            return new SqlConnection(Config.GetConnectionString("BookDb"));
        }

    }
}
