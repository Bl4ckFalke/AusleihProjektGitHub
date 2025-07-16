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
    class DBPerson
    {
        public static List<Person> AlleLesen()
        {
            // TODO: SQL-Abfrage zum Lesen aller Personen

            List<Person> liste = new List<Person>();

            using (MySqlConnection con = DBZugriff.OpenDB())
            {
                string sql = "SELECT * FROM AusleihSchein";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Person person = GetDataFromReader(rdr);
                        liste.Add(person);
                    }
                }
            }
            liste = liste.OrderBy(ausleihScheine => ausleihScheine.Id).ToList();


            return liste;
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
