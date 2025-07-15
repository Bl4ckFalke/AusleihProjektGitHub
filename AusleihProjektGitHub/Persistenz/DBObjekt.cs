using AusleihProjektGitHub.Fachklassen;
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
            return new List<Objekt>();
        }
        public static void  Speichern(Objekt objekt)
        {
            // TODO: SQL-Abfrage zum Speichern eines Objekts

        }
        public static Objekt GetObjektById(int id)
        {
            // TODO: SQL-Abfrage zum Lesen eines Objekts nach ID
            return new Objekt();
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
