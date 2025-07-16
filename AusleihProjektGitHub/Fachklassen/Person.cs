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


        public Person(int id, string vorname, string nachname, string klasse)
        {
            _id = id;
            _vorname = vorname;
            _nachname = nachname;
            _klasse = klasse;
        }
        public Person()
        { }

        public override string ToString()
        {
            return $"{_vorname} {_nachname}, Klasse: {_klasse} (ID: {_id})";
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
    }
}
