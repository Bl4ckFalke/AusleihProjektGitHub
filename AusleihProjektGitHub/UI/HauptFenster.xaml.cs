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
        this._mvModel = FindResource("mwvm") as MainWindowViewModel;
        this._mvModel.User = p; // Setzt den aktuellen Benutzer im ViewModel
        InitializeComponent();
        
        Person a = p;
        FillCbObjektart();
        cbObjektart.SelectedIndex = 0; // Selektiert "Alle" als Standardwert
        FillCbKlassen(a);

        
        


    }

    private void bttn_erstellen(object sender, RoutedEventArgs e)
    {
        ErstellenFenster erstellenFenster = new ErstellenFenster(user);
        erstellenFenster.ShowDialog();

    }

    private void bttn_verwalten(object sender, RoutedEventArgs e)
    {

    }

    private void suche_Name(object sender, TextChangedEventArgs e)
    {

    }

    private void FillCbObjektart()
    {/*
        cbObjektart.Items.Clear();
        cbObjektart.Items.Add("Alle"); // Add "Alle" as the first item
        foreach (string kategorie in Objekt.AlleObjektarten())
        {
            cbObjektart.Items.Add(kategorie);
        }
        */
    }

    private void FillCbKlassen(Person a)
    {
        /*cbKlassen.Items.Clear();
        cbKlassen.Items.Add("Alle");// Alle wird als erste Option hinzugefügt
        foreach (string klasse in Person.AlleKlassen())
        {
            cbKlassen.Items.Add(klasse);
            cbKlassen.SelectedIndex = 0; // Setzt den Index auf 0, damit "Alle" vorausgewählt ist, wird überschrieben, falls der User eine Klasse hat
        }
        if (a.Klasse != null)
        {
            cbKlassen.SelectedItem = a.Klasse; // falls der user eine Klasse hat, wird diese vorausgewählt
        }
        */
    }

    private void CbSelbstChecked(object sender, RoutedEventArgs e)
    {
        
        this._mvModel.CbSelbstErstellt = true;
    }

    private void CbSelbstUnchecked(object sender, RoutedEventArgs e)
    {

        
        this._mvModel.CbSelbstErstellt = false;
    }
}