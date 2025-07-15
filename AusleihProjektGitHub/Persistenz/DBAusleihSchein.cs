using AusleihProjektGitHub.Fachklassen;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AusleihProjektGitHub.Persistenz
{
    class DBAusleihSchein
    {
        public static List<AusleihSchein> AlleLesen()
        {
            //TODO: SQL-Abfrage zum Lesen aller Ausleihscheine
            return new List<AusleihSchein>();
        }
        public static void Speichern(AusleihSchein ausleihSchein) 
        {
            //TODO: SQL-Abfrage zum Speichern eines Ausleihscheins
        }
        public static AusleihSchein GetAusleihScheinById(int id)
        {
            //TODO: SQL-Abfrage zum Lesen eines Ausleihscheins nach ID
            return new AusleihSchein();
        }
        private static AusleihSchein GetDataFromReader(MySqlDataReader rdr)
        {
            // diese Methode ist dazu da die richtigen Daten beim Lesen aus der Datenbank zu bekommen
            AusleihSchein ausleihSchein = new AusleihSchein();
            ausleihSchein.Id = rdr.GetInt32("Id");
            ausleihSchein.Ersteller = DBPerson.GetPersonById(rdr.GetInt32("AusleiherId"));
            ausleihSchein.Empfaenger = DBPerson.GetPersonById(rdr.GetInt32("EmpfaengerId"));
            ausleihSchein.Objekt = DBObjekt.GetObjektById(rdr.GetInt32("ObjektId"));
            ausleihSchein.StartDatum = rdr.GetDateTime("StartDatum");
            ausleihSchein.EndDatum = rdr.GetDateTime("EndDatum");
            ausleihSchein.Grund = rdr.GetString("Grund");
            ausleihSchein.ErstellDatum = rdr.GetDateTime("ErstellDatum");
            return ausleihSchein;
        }
    }
}
