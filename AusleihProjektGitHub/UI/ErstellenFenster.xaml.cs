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


        private void bttn_erstellen(object sender, RoutedEventArgs e)
        {
            

            this.Close();
        }

        private void bttn_abbrechen(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
