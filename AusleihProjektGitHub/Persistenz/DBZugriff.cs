using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AusleihProjektGitHub.Persistenzen
{
    public static class DBZugriff
    {
        public static MySqlConnection OpenDB()
        {
            String constr = "Server=bszw.ddns.net;Database=bfi2326a_JW_OO_NM_AP_AusleihProjekt;Uid=bfi2326a;Pwd=geheim;";
            MySqlConnection con = new MySqlConnection(constr);
            con.Open(); //öffnen der Verbindung
            return con;
        }

        public static void CloseDB(MySqlConnection con)
        {
            con.Close();
        }
        public static int ExecuteNonQuery(String sql)
        {
            using (MySqlConnection con = DBZugriff.OpenDB())
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                int anz = cmd.ExecuteNonQuery();
                return anz;
            }


        }
        public static MySqlDataReader ExecuteReader(string sql, MySqlConnection con)
        {


            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            return rdr;

        }
        public static int GetLastInsertId(MySqlConnection con)
        {


            /// Liefert die letzte vergeben Id bezogen auf diese Connection
            MySqlCommand cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", con);
            int id = Convert.ToInt32(cmd.ExecuteScalar());

            return id;
        }
    }
}
