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
        
        public MainWindow()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string password = pwd.Text; //platzhalter vor merge 
            string username = usern.Text;

            Person person = Person.Login(username, password);

            if (person == null)
            {
                MessageBox.Show("Anmelde-Daten nicht richtig", "Fehler");
                pwd.Clear();
                usern.Clear();
                return;
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Person p = Person.Login(new Person(UserTextBox.Text, PasswordTextBox.Text));
                HauptFenster hauptFenster = new HauptFenster(p);
                
                this.Close();
                hauptFenster.Show();
            }
            catch
            (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler beim Anmelden ");
            }
            
            
        }
    }
}
