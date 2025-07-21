using AusleihProjektGitHub.Persistenz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AusleihProjektGitHub.Fachklassen
{
    public class AusleihSchein
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
        private Person _ersteller;
        public Person Ersteller
        {
            get
            {
                return _ersteller;
            }
            set
            {
                _ersteller = value;
            }
        }
        private Person _empfaenger;
        public Person Empfaenger
        {
            get
            {
                return _empfaenger;
            }
            set
            {
                _empfaenger = value;
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
        private string _grund;
        public string Grund
        {
            get
            {
                return _grund;
            }
            set
            {
                _grund = value;
            }
        }
        private DateTime _erstellDatum;
        public DateTime ErstellDatum
        {
            get
            {
                return _erstellDatum;
            }
            set
            {
                _erstellDatum = value;
            }
        }

        private DateTime _startDatum;
        public DateTime StartDatum
        {
            get
            {
                return _startDatum;
            }
            set
            {
                _startDatum = value;
            }
        }
        private DateTime _endDatum;
        public DateTime EndDatum
        {
            get
            {
                return _endDatum;
            }
            set
            {
                _endDatum = value;
            }
        }
        public AusleihSchein(int id, Person ersteller, Person empfaenger, Objekt objekt, string grund, DateTime erstellDatum, DateTime startDatum, DateTime endDatum)
        {
            Id = id;
            Ersteller = ersteller;
            Empfaenger = empfaenger;
            Objekt = objekt;
            Grund = grund;
            ErstellDatum = erstellDatum;
            StartDatum = startDatum;
            EndDatum = endDatum;
        }
        public AusleihSchein()
        {}
        public override string ToString()
        {
            return $"AusleihSchein ID: {Id}, Ersteller: {Ersteller.Vorname} {Ersteller.Nachname}, Empfänger: {Empfaenger.Vorname} {Empfaenger.Nachname}, Objekt: {Objekt.ObjektName}, Grund: {Grund}, ErstellDatum: {ErstellDatum.ToShortDateString()}";
        }
        public void Speichern()
        {
            DBAusleihSchein.Speichern(this);
        }
        public static List<AusleihSchein> AlleLesen()
        {
            return DBAusleihSchein.AlleLesen();
        }
        public static AusleihSchein GetAusleihScheinById(int id)
        {
            return DBAusleihSchein.GetAusleihScheinById(id);

        }
    }
}
