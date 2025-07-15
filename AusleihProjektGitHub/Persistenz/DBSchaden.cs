using AusleihProjektGitHub.Fachklassen;
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
            // TODO: SQL-Abfrage zum Lesen aller Schäden
            return new List<Schaden>();
        }

        public static void Speichern(Schaden schaden)
        {
            // TODO: SQL-Abfrage zum Speichern eines Schadens
        }

        public static Schaden GetSchadenById(int id)
        {
            //TODO: SQL-Abfrage zum Lesen eines Schadens nach ID
            return new Schaden();
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
