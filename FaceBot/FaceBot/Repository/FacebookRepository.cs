using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FaceBot.Repository
{
    class FacebookRepository
    {
        private string connectionString;

        public FacebookRepository()
        {
            connectionString = ConfigurationManager.AppSettings["connectionString"];
        }

        public void Insert(string friend)
        {
            var comment = new {
                Friend = friend,
            };

            using (var connection = new SqlConnection(connectionString)) {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                connection.Execute("INSERT INTO COMMENTS_MADE(Friend,Created_At) VALUES(@Friend,GETDATE())", comment);

                connection.Close();
            }
        }

        public void Log(string friend, string Message)
        {
            var log = new
            {
                Friend = friend,
                Log = Message
            };

            using (var connection = new SqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                connection.Execute("INSERT INTO COMMENTS_LOG(Friend,Log,Created_At) VALUES(@Friend,@Log,GETDATE())", log);

                connection.Close();
            }
        }
    }
}
