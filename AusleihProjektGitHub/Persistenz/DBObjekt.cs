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
            List<Objekt> objekte = new List<Objekt>();

            using (var con = DBZugriff.OpenDB())
            {
                string sql = @"SELECT 
                          o.Id,
                          o.Kategorie,
                          o.Name,
                          s.Id AS SchadenId
                       FROM Objekt o
                       LEFT JOIN Schaden s ON o.Id = s.FK_ObjektId
                       ORDER BY o.Id";

                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, con))
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Objekt objekt = GetDataFromReader(rdr);
                        objekte.Add(objekt);
                    }
                }
            }

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

        public static List<string> AlleObjektarten()
        {
            string zeile = "SELECT DISTINCT Kategorie FROM Objekt";
            using (MySql.Data.MySqlClient.MySqlConnection con = DBZugriff.OpenDB())
            using (MySql.Data.MySqlClient.MySqlDataReader rdr = DBZugriff.ExecuteReader(zeile, con))
            {
                List<string> kategorieListe = new List<string>();
                while (rdr.Read())
                {
                    string kategorie = rdr.GetString("Kategorie");
                    kategorieListe.Add(kategorie);
                }
                return kategorieListe;
            }

        }

        private static Objekt GetDataFromReader(MySql.Data.MySqlClient.MySqlDataReader rdr)
        {
            //diese Methode ist dazu da die richtigen daten beim Lesen aus der Datenbank zu bekommen
            Objekt objekt = new Objekt
            {
                Id = rdr.GetInt32("Id"),
                Kategorie = rdr.GetString("Kategorie"),
                ObjektName = rdr.GetString("Name"),
                Schaden = !rdr.IsDBNull(rdr.GetOrdinal("Id"))
                  ? new Schaden { Id = rdr.GetInt32("Id") }
                  : null
            };

            
            return objekt;
        }
    }
}
