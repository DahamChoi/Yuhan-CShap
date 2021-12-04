using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Database
{
    class DatabaseController
    {
        private static readonly string _ConnetionString = "Server=localhost;Database=yuhan;Uid=root;Pwd=1234";
        private readonly MySqlConnection _Connetion = new MySqlConnection(_ConnetionString);

        public DatabaseController()
        {
            _Connetion.Open();
        }

        ~DatabaseController()
        {
            _Connetion.Close();
        }

        public void ExcuteQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, _Connetion);
            command.ExecuteNonQuery();
        }

        public DataSet ExcuteSelectQuery(string query)
        {
            DataSet ret = new DataSet();

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, _Connetion);
            adapter.Fill(ret, "Tab1");

            return ret;
        }
    }
}
