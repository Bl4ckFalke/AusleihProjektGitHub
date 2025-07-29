using AusleihProjektGitHub.Fachklassen;
using AusleihProjektGitHub.ViewModel;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string password = pwd.Text; //platzhalter vor merge 
            string username = usern.Text;

            Person person = DBPerson.Anmelden(username, password);

            if (person == null)
            {
                MessageBox.Show("Anmelde-Daten nicht richtig", "Fehler");
                pwd.Clear();
                usern.Clear();
                return;
            }

            // Erfolgreich angemeldet
            HauptFenster hf = new HauptFenster();
            hf.Show();
            this.Close();

            }
        }
    }
}
