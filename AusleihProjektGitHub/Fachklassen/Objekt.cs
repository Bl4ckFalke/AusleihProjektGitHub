using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AusleihProjektGitHub.Fachklassen
{
    class Objekt
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
        private string _kategorie;
        public string Kategorie
        {
            get
            {
                return _kategorie;
            }
            set
            {
                _kategorie = value;
            }
        }
        private string _objektName;
        public string ObjektName
        {
            get
            {
                return _objektName;
            }
            set
            {
                _objektName = value;
            }
        }
        private Schaden _schaden;
        public Schaden Schaden
        {
            get
            {
                return _schaden;
            }
            set
            {
                _schaden = value;
            }
        }

        public Objekt(int id, string kategorie, string objektName, Schaden schaden)
        {
            Id = id;
            Kategorie = kategorie;
            ObjektName = objektName;
            Schaden = schaden;
        }
        public Objekt()
        { }

        public override string ToString()
        {
            return $"{Id} - {Kategorie} - {ObjektName} - {Schaden}";
        }



        public void Speichern()
        {
            // Logik zum Speichern des Objekts in der Datenbank oder einer Datei in der Persistenz Schicht

        }

        public static List<Objekt> AlleLesen()
        {
            // Logik zum Lesen aller Objekte aus der Datenbank oder einer Datei in der Persistenz Schicht
            return new List<Objekt>();
        }
        public static Objekt GetObjektById(int id)
        {             // Logik zum Lesen eines Objekts anhand der ID aus der Datenbank oder einer Datei in der Persistenz Schicht
            return new Objekt();
        }
    }

}
