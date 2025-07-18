using AusleihProjektGitHub.Fachklassen;
using AusleihProjektGitHub.Persistenzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AusleihProjektGitHub.Persistenz
{
    class DBSchaden
    {
        public static List<Schaden> AlleLesen()
        {
            

            List<Schaden> schadenListe = new List<Schaden>();
            using (MySql.Data.MySqlClient.MySqlConnection con = DBZugriff.OpenDB())
            {
                string sql = "SELECT * FROM Schaden";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, con);
                using (MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Schaden schaden = GetDataFromReader(rdr);
                        schadenListe.Add(schaden);
                    }
                }
            }
            schadenListe = schadenListe.OrderBy(schaden => schaden.Id).ToList();
            return new List<Schaden>();
        }

        public static void Speichern(Schaden schaden)
        {
            string sql =$"INSERT INTO Schaden (Id, FK_ObjektId, SchadenVorher, Schadenbes) " +
                $"VALUES ('{schaden.Id}', '{schaden.Objekt.Id}', '{schaden.SchadenVorher}', '{schaden.Schadenbes}')";
        }

        public static Schaden GetSchadenById(int id)
        {
            string zeile = "SELECT * FROM Schaden WHERE Id = " + id;
            using (MySql.Data.MySqlClient.MySqlConnection con = DBZugriff.OpenDB())
            using (MySql.Data.MySqlClient.MySqlDataReader rdr = DBZugriff.ExecuteReader(zeile, con))
            {
                Schaden schaden;
                if (rdr.Read())
                {
                    schaden = GetDataFromReader(rdr);
                    return schaden;
                }
                else
                    throw new Exception("Kein Schaden mit dieser Id gefunden");
            }

        }
        private static Schaden GetDataFromReader(MySql.Data.MySqlClient.MySqlDataReader rdr)
        {
            //diese Methode ist dazu da die richtigen daten beim Lesen aus der Datenbank zu bekommen
            Schaden schaden = new Schaden();
            schaden.Id = rdr.GetInt32("Id");
            schaden.Objekt = DBObjekt.GetObjektById(rdr.GetInt32("FK_ObjektId"));
            schaden.SchadenVorher = rdr.GetString("SchadenVorher");
            schaden.Schadenbes = rdr.GetString("Schadenbes");
            return schaden;
        }
    }
}
