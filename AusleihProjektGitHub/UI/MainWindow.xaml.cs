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

            HauptFenster hauptFenster = new HauptFenster(person);

            this.Close();
            hauptFenster.Show();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                if (usern.IsFocused)
                {
                    pwd.Focus();
                }
                e.Handled = true;
            }
            else if (e.Key == Key.Up)
            {
                if (pwd.IsFocused)
                {
                    usern.Focus();
                }
                e.Handled = true;
            }
        }

    }
}
