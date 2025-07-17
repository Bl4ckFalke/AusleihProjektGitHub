using AusleihProjektGitHub.Fachklassen;
using AusleihProjektGitHub.Persistenzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AusleihProjektGitHub.Persistenz
{
    class DBObjekt
    {
        public static List<Objekt> AlleLesen()
        {
            // TODO: SQL-Abfrage zum Lesen aller Objekte

            List<Objekt> objekte = new List<Objekt>();
            using (MySql.Data.MySqlClient.MySqlConnection con = DBZugriff.OpenDB())
            {
                string sql = "SELECT * FROM Objekt";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, con);
                using (MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Objekt objekt = GetDataFromReader(rdr);
                        objekte.Add(objekt);
                    }
                }
            }

            objekte = objekte.OrderBy(objekt => objekt.Id).ToList();

            return objekte;
        }
        public static void  Speichern(Objekt objekt)
        {
            string sql = $"INSERT INTO Objekt (Id, Kategorie, Name) " +
                $"VALUES ('{objekt.Id}', '{objekt.Kategorie}', '{objekt.ObjektName}')";

        }
        public static Objekt GetObjektById(int id)
        {
            string zeile = "SELECT * FROM Objekt WHERE Id = " + id;
            using (MySql.Data.MySqlClient.MySqlConnection con = DBZugriff.OpenDB())
            using (MySql.Data.MySqlClient.MySqlDataReader rdr = DBZugriff.ExecuteReader(zeile, con))
            {
                Objekt objekt;
                if (rdr.Read())
                {
                    objekt = GetDataFromReader(rdr);
                    return objekt;
                }
                else
                    throw new Exception("Kein Objekt mit dieser Id gefunden");
            }
        }

        private static Objekt GetDataFromReader(MySql.Data.MySqlClient.MySqlDataReader rdr)
        {
            //diese Methode ist dazu da die richtigen daten beim Lesen aus der Datenbank zu bekommen
            Objekt objekt = new Objekt();
            objekt.Id = rdr.GetInt32("Id");
            objekt.Kategorie = rdr.GetString("Kategorie");
            objekt.ObjektName = rdr.GetString("Name");
 
            return objekt;
        }
    }
}
