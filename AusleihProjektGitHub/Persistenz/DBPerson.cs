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
            

            List<Person> liste = new List<Person>();

            using (MySqlConnection con = DBZugriff.OpenDB())
            {
                string sql = "SELECT Id, Rolle, Vorname, Nachname, Klasse FROM Person";
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

        public static List<Person> AlleLesen(string filter)
        {
            List<Person> liste = new List<Person>();

            using (MySqlConnection con = DBZugriff.OpenDB())
            {
                string sql = "SELECT Id, Rolle, Vorname, Nachname, Klasse FROM Person WHERE "+ filter;
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
            string sql = $"INSERT INTO Person (Rolle, Vorname, Nachname, Klasse) " +
                $"VALUES ('{(int)person.Rolle}', '{person.Vorname}', '{person.Nachname}', '{person.Klasse}')";
            DBZugriff.ExecuteNonQuery(sql);
        }

        public static Person GetPersonById(int id)
        {
            string zeile = "SELECT * FROM Person WHERE Id = " + id;
            using (MySqlConnection con = DBZugriff.OpenDB())
            using (MySqlDataReader rdr = DBZugriff.ExecuteReader(zeile, con))
            {
                Person person;
                if (rdr.Read())
                {
                    person = GetDataFromReader(rdr);
                    return person;
                }
                else
                    throw new Exception("Kein Person mit dieser Id gefunden");
            }
        }

        public static Person Anmelden(Person p)
        {
            string zeile = $"SELECT * FROM Person WHERE Username = '{p.Username}' AND Passwort = '{p.Passwort}'";
            using (MySqlConnection con = DBZugriff.OpenDB())
            using (MySqlDataReader rdr = DBZugriff.ExecuteReader(zeile, con))
            {
                Person person;
                if (rdr.Read())
                {
                    person = GetDataFromReader(rdr);
                    return person;
                }
                else
                    throw new Exception("Anmeldung fehlgeschlagen: Falscher Benutzername oder Passwort");
            }
        }

        public static List<string> AlleKlassen()
        {
            string zeile = "SELECT DISTINCT Klasse FROM Person";
            List<string> klassen = new List<string>();
            using (MySqlConnection con = DBZugriff.OpenDB())
            using (MySqlDataReader rdr = DBZugriff.ExecuteReader(zeile, con))
            {
                while(rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("Klasse")))
                    {
                        string klasse = rdr.GetString("Klasse");

                        klassen.Add(klasse);
                    }
                }
                return klassen;
            }
        }

        private static Person GetDataFromReader(MySqlDataReader rdr)
        {
            //diese Methode ist dazu da die richtigen daten beim Lesen aus der Datenbank zu bekommen
            Person person = new Person();
            person.Id = rdr.GetInt32("Id");
            person.Rolle = (Rolle)rdr.GetInt32("Rolle");
            person.Vorname = rdr.GetString("Vorname");
            person.Nachname = rdr.GetString("Nachname");

            if(rdr.GetOrdinal("Klasse") == null || rdr.IsDBNull(rdr.GetOrdinal("Klasse")))
            {
                person.Klasse = null; // Falls Klasse NULL ist, wird sie auf null gesetzt
            }
            else
                person.Klasse = rdr.GetString("Klasse");
            return person;
        }

        
    }
}
