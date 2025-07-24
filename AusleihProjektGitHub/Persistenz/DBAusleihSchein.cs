using AusleihProjektGitHub.Fachklassen;
using AusleihProjektGitHub.Persistenzen;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AusleihProjektGitHub.Persistenz
{
    class DBAusleihSchein
    {
        public static List<AusleihSchein> AlleLesen()
        {
            
            List<AusleihSchein> ausleihScheine = new List<AusleihSchein>();
            using(MySqlConnection con = DBZugriff.OpenDB())
            {
                string sql = "SELECT * FROM AusleihSchein";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        AusleihSchein ausleihSchein = GetDataFromReader(rdr);
                        ausleihScheine.Add(ausleihSchein);
                    }
                }
            }
            ausleihScheine = ausleihScheine.OrderBy(ausleihScheine => ausleihScheine.Id).ToList();

            return ausleihScheine;
        }
        public static List<AusleihSchein> AlleLesen(string filter)   
        {
            // Diese Methode liest alle Ausleihscheine für eine bestimmte Person
            List<AusleihSchein> ausleihScheine = new List<AusleihSchein>();
            using (MySqlConnection con = DBZugriff.OpenDB())
            {
                string sql = "SELECT * FROM AusleihSchein " +
                            "INNER JOIN Person AS Ausleiher ON AusleihSchein.AusleiherId = Ausleiher.Id " +
                            "INNER JOIN Person AS Empfaenger ON AusleihSchein.EmpfaengerId = Empfaenger.Id " +
                            "INNER JOIN Objekt ON AusleihSchein.ObjektId = Objekt.Id " +
                            $"WHERE {filter}";


                MySqlCommand cmd = new MySqlCommand(sql, con);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        AusleihSchein ausleihSchein = GetDataFromReader(rdr);
                        ausleihScheine.Add(ausleihSchein);
                    }
                }
            }
            ausleihScheine = ausleihScheine.OrderBy(ausleihScheine => ausleihScheine.Id).ToList();
            return ausleihScheine;
        }
        public static void Speichern(AusleihSchein ausleihSchein) 
        {
            string sql = $"INSERT INTO AusleihSchein (AusleiherId, EmpfaengerId, ObjektId, StartDatum, EndDatum, Grund, ErstellDatum)" +
                $" VALUES ('{ausleihSchein.Empfaenger.Id}', '{ausleihSchein.Empfaenger.Id}','{ausleihSchein.Objekt.Id}'," +
                $" '{ausleihSchein.StartDatum.ToString("yyyy-MM-dd")}', '{ausleihSchein.EndDatum.ToString("yyyy-MM-dd")}'," +
                $" '{ausleihSchein.Grund}', '{ausleihSchein.ErstellDatum.ToString("yyyy-MM-dd")}')";
            DBZugriff.ExecuteNonQuery(sql);

        }
        public static AusleihSchein GetAusleihScheinById(int id)
        {
            string zeile = "Select * FROM AusleihSchein WHERE Id = " + id;
            using (MySqlConnection con = DBZugriff.OpenDB())
            using (MySqlDataReader rdr = DBZugriff.ExecuteReader(zeile, con))
            {
                AusleihSchein a;
                if (rdr.Read())
                {
                    a = GetDataFromReader(rdr);
                    return a;
                }
                else
                    throw new Exception("Kein Ausleihschein mit dieser Id gefunden");
            }
            
        }
        private static AusleihSchein GetDataFromReader(MySqlDataReader rdr)
        {
            // diese Methode ist dazu da die richtigen Daten beim Lesen aus der Datenbank zu bekommen
            AusleihSchein ausleihSchein = new AusleihSchein();
            ausleihSchein.Id = rdr.GetInt32("Id");
            ausleihSchein.Ersteller = DBPerson.GetPersonById(rdr.GetInt32("AusleiherId"));
            ausleihSchein.Empfaenger = DBPerson.GetPersonById(rdr.GetInt32("EmpfaengerId"));
            ausleihSchein.Objekt = DBObjekt.GetObjektById(rdr.GetInt32("ObjektId"));
            ausleihSchein.StartDatum = rdr.GetDateTime("StartDatum");
            ausleihSchein.EndDatum = rdr.GetDateTime("EndDatum");
            ausleihSchein.Grund = rdr.GetString("Grund");
            ausleihSchein.ErstellDatum = rdr.GetDateTime("ErstellDatum");
            return ausleihSchein;
        }
    }
}
