using AusleihProjektGitHub.Fachklassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AusleihProjektGitHub.UI
{
    /// <summary>
    /// Interaktionslogik für LoginFenster.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person user = new Person();
        public MainWindow()
        {
            InitializeComponent();
        }


        private bool PwdLogin(string password, string username)
        {
            bool pwdRichtig = Verschluesseler.PasswortPruefen(password, user.Passwort);
            
            if(pwdRichtig == false)
            {
                return false;
            }

            return true;
        }
        //TODO: prüfen auf angelegter benutzer auf datenbank
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string password = "test123";
            string username = "usertest";

            user.Passwort = password;
            user.Username = username;

            bool anmeldung = PwdLogin(password, username);

            if (anmeldung == false)
            {
                //hier wird alle ausgefüllte inhalte gelöscht und man bekommt eine messsagebox

                MessageBox.Show("Anmelde Daten nicht richtig", "Fehler");
            }
            else
            {
                this.Close();
                HauptFenster hf = new HauptFenster();
                hf.Show();

            }




        }
    }
}
