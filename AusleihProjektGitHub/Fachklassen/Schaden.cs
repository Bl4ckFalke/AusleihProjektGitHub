using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AusleihProjektGitHub.Fachklassen
{
    class Schaden
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

        private Objekt _objekt;
        public Objekt Objekt
        {
            get
            {
                return _objekt;
            }
            set
            {
                _objekt = value;
            }
        }

        private string _schadenVorher;
        public string SchadenVorher
        {
            get
            {
                return _schadenVorher;
            }
            set
            {
                _schadenVorher = value;
            }
        }
        private string _schadenbes;
        public string Schadenbes
        {
            get
            {
                return _schadenbes;
            }
            set
            {
                _schadenbes = value;
            }
        }

        public Schaden(int id, Objekt objekt, string schadenVorher, string schadenbes)
        {
            Id = id;
            Objekt = objekt;
            SchadenVorher = schadenVorher;
            Schadenbes = schadenbes;
        }
        public Schaden()
        { }

        public override string ToString()
        {
            return $"{Id} - {Objekt} - {SchadenVorher} - {Schadenbes}";
        }

        public void Speichern()
        {
            // Logik zum Speichern des Objekts in der Datenbank oder einer Datei in der Persistenz Schicht
        }
        public List<Schaden> AlleLesen()
        {
            // Logik zum Lesen aller Schäden aus der Datenbank oder einer Datei in der Persistenz Schicht
            return new List<Schaden>();
        }
        public Schaden GetSchadenById(int id)
        {
            // Logik zum Lesen eines bestimmten Schadens anhand der ID aus der Datenbank oder einer Datei in der Persistenz Schicht
            return new Schaden();
        }
    }
}
