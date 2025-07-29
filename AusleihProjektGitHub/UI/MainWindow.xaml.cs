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


        private void UserLogin(object sender, TextChangedEventArgs e)
        {

            Person person = Person.Anmelden(username, password);

        private void PwdLogin(object sender, TextChangedEventArgs e)
        {

        }

            // Erfolgreich angemeldet
            HauptFenster hf = new HauptFenster(person);
            hf.Show();
            this.Close();

        }
    }
}
