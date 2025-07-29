using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace AusleihProjektGitHub.Fachklassen
{
    class Verschluesseler
    {
        //Hier wird bei der angabe des neue passwords, das password verschlüsselt
        public static string verschluesseln(string passwort)
        {
            return BCrypt.Net.BCrypt.HashPassword(passwort);
        }

        //Hier wird bei den LOGIN das Password geprüft
        public static bool PasswortPruefen(string passwortEingabe, string gespeicherterHash)
        {
            return BCrypt.Net.BCrypt.Verify(passwortEingabe, gespeicherterHash);
        }
    }
}
