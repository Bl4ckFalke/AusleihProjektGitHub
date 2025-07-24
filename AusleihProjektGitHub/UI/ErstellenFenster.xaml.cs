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
    /// Interaktionslogik für ErstellenFenster.xaml
    /// </summary>
    public partial class ErstellenFenster : Window
    {
        private MainWindowViewModel _mvModel;
        public ErstellenFenster()
        {
            InitializeComponent();
            this._mvModel = FindResource("mwvm") as MainWindowViewModel;
            ErstellerTextBox.Text = _mvModel.User.Nachname;
            StartDatumDatePicker.Text = DateTime.Now.ToString("dd.MM.yyyy");


        }

        private void ersteller(object sender, TextChangedEventArgs e)
        {

        }

        private void startdat(object sender, TextChangedEventArgs e)
        {

        }

        private void objekt_tb(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void empfaenger(object sender, TextChangedEventArgs e)
        {

        }

        private void enddat(object sender, TextChangedEventArgs e)
        {

        }

        private void obj_id(object sender, TextChangedEventArgs e)
        {

        }

        private void bttn_erstellen(object sender, RoutedEventArgs e)
        {

        }

        private void bttn_abbrechen(object sender, RoutedEventArgs e)
        {

        }
    }
}
