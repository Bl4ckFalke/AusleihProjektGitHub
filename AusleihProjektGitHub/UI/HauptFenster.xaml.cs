using AusleihProjektGitHub.Fachklassen;
using AusleihProjektGitHub.UI;
using AusleihProjektGitHub.ViewModel;
using System.Security.Cryptography.X509Certificates;
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
    private MainWindowViewModel _mvModel;
    
    public HauptFenster(Person p)
    {
        InitializeComponent();
         Person a = p;
        FillCbObjektart();
        cbObjektart.SelectedIndex = 0; // Selektiert "Alle" als Standardwert
        FillCbKlassen(a);

        _mvModel = FindResource("mwvm") as MainWindowViewModel;
        


    }

    private void bttn_erstellen(object sender, RoutedEventArgs e)
    {
        ErstellenFenster erstellenFenster = new ErstellenFenster();
        erstellenFenster.ShowDialog();

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

    private void FillCbKlassen(Person a)
    {
        cbKlassen.Items.Clear();
        cbKlassen.Items.Add("Alle");// Alle wird als erste Option hinzugefügt
        foreach (string klasse in Person.AlleKlassen())
        {
            cbKlassen.Items.Add(klasse);

        }
        if (a.Klasse != null)
        {
            cbKlassen.SelectedItem = a.Klasse; // falls der user eine Klasse hat, wird diese vorausgewählt
        }
    }

    
}