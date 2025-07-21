using AusleihProjektGitHub.Persistenz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AusleihProjektGitHub.Fachklassen
{
    public enum Rolle
    {
        Lehrer,
        ItAbteilung,
        Seketariat,
        Empfaenger
    }

    class Person
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private Rolle _rolle;
        public Rolle Rolle
        {
            get
            {
                return _rolle;
            }
            set
            {
                _rolle = value;
            }
        }


        private string _vorname;
        public string Vorname
        {
            get
            {
                return _vorname;
            }
            set
            {
                _vorname = value;
            }
        }

        private string _nachname;
        public string Nachname
        {
            get
            {
                return _nachname;
            }
            set
            {
                _nachname = value;
            }
        }

        private string _klasse;
        public string Klasse
        {
            get
            {
                return _klasse;
            }
            set
            {
                _klasse = value;
            }
        }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
        private string _passwort;
        public string Passwort
        {
            get
            {
                return _passwort;
            }
            set
            {
                _passwort = Verschluesseler.verschluesseln(value);
            }
        }



        public Person(int id, string vorname, string nachname, string klasse)
        {
            Id = id;
            Vorname = vorname;
            Nachname = nachname;
            Klasse = klasse;
        }

        public Person(string username, string password)
        {
            Username = username;
            Passwort = Verschluesseler.verschluesseln(password);
        }

        public Person()
        { }

        public override string ToString()
        {
            return $"{Vorname} {Nachname}, Klasse: {Klasse} (ID: {Id})";
        }
        public void Speichern()
        {
            
            DBPerson.Speichern(this);
        }

        public static List <Person> AlleLesen()
        {
           
           
            return DBPerson.AlleLesen();
        }

        public static Person GetPersonById(int id)
        {
           
            return DBPerson.GetPersonById(id);
        }

        public static Person Login(Person p)
        {
            return DBPerson.Anmelden(p);
        }
    }
}
