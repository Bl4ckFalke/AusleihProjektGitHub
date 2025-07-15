using AusleihProjektGitHub.Fachklassen;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AusleihProjektGitHub.Persistenz
{
    class DBPerson
    {
        public static List<Person> AlleLesen()
        {
            // TODO: SQL-Abfrage zum Lesen aller Personen
            return new List<Person>();
        }

        public static void Speichern(Person person)
        {
            // TODO: SQL-Abfrage zum Speichern einer Person
        }

        public static Person GetPersonById(int id)
        {
            // TODO: SQL-Abfrage zum Lesen einer Person nach ID
            return new Person();
        }

        private static Person GetDataFromReader(MySqlDataReader rdr)
        {
            //diese Methode ist dazu da die richtigen daten beim Lesen aus der Datenbank zu bekommen
            Person person = new Person();
            person.Id = rdr.GetInt32("Id");
            person.Rolle = (Rolle)rdr.GetInt32("Rolle");
            person.Vorname = rdr.GetString("Vorname");
            person.Nachname = rdr.GetString("Nachname");
            person.Klasse = rdr.GetString("Klasse");
            return person;
        }
    }
}
