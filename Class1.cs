using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace araçkiralamagrup2
{
    internal class Class1
    {
        string baglanticumlesi = "Server=localhost;database=arackiralamagrup2;uid=root;pwd=Ostim.123;";

        public MySqlConnection baglan()
        {
            MySqlConnection baglanti =new MySqlConnection(baglanticumlesi);
            MySqlConnection.ClearPool (baglanti);
            return baglanti;
        }
    }
}
