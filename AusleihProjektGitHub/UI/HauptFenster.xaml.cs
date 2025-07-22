using AusleihProjektGitHub.Fachklassen;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AusleihProjektGitHub;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class HauptFenster : Window
{
    public HauptFenster()
    {
        InitializeComponent();
        FillCbObjektart();
        cbObjektart.SelectedIndex = 0; // Set default selection to "Alle"
        FillCbKlassen();
        cbKlassen.SelectedIndex = 0; // Set default selection to "Alle"
    }

    private void bttn_erstellen(object sender, RoutedEventArgs e)
    {

    }

    private void bttn_verwalten(object sender, RoutedEventArgs e)
    {

    }

    private void suche_Name(object sender, TextChangedEventArgs e)
    {

    }

    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {

    }

    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {

    }


    private void FillCbObjektart()
    {
        cbObjektart.Items.Clear();
        cbObjektart.Items.Add("Alle"); // Add "Alle" as the first item
        foreach (string kategorie in Objekt.AlleObjektarten())
        {
            cbObjektart.Items.Add(kategorie);
        }
    }

    private void FillCbKlassen()
    {
        cbKlassen.Items.Clear();
        cbKlassen.Items.Add("Alle"); // Add "Alle" as the first item
        foreach (string klasse in Person.AlleKlassen())
        {
            cbKlassen.Items.Add(klasse);
        }
    }
}