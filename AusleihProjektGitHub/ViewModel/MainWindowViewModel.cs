using AusleihProjektGitHub.Fachklassen;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AusleihProjektGitHub.ViewModel
{
    public class MainWindowViewModel : BaseModel
    {
        // Liste für das DataGrid
        private ObservableCollection<AusleihSchein> _lstSchein;
        public ObservableCollection<AusleihSchein> LstSchein
        {
            get => _lstSchein;
            set
            {
                _lstSchein = value;
                OnPropertyChanged(nameof(LstSchein));
            }
        }

        // Aktuell ausgewählter Schein
        private AusleihSchein _selectedSchein;
        public AusleihSchein SelectedSchein
        {
            get => _selectedSchein;
            set
            {
                _selectedSchein = value;
                IsAusleihscheinSelected = this._selectedSchein != null;
                OnPropertyChanged(nameof(SelectedSchein));
            }
        }

        // Filter: nur eigene Scheine
        private bool _cbSelbstErstellt;
        public bool CbSelbstErstellt
        {
            get => _cbSelbstErstellt;
            set
            {
                _cbSelbstErstellt = value;
                OnPropertyChanged(nameof(CbSelbstErstellt));
                LadeAusleihscheine(); // neu laden bei Änderung
            }
        }

        // Der aktuell eingeloggte Benutzer
        private Person _user;
        public Person User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
                LadeAusleihscheine(); // neu laden bei Änderung
            }
        }

        private bool _isAusleihscheinSelected;
        public bool IsAusleihscheinSelected
        {
            get
            {
                return _isAusleihscheinSelected;
            }
            set
            {
                this._isAusleihscheinSelected = value;
                OnPropertyChanged(nameof(IsAusleihscheinSelected));
            }
        }
        // Filter: ausgewählte Klasse
        private string _selectedKlasse;
        public string SelectedKlasse
        {
            get => _selectedKlasse;
            set
            {
                _selectedKlasse = value;
                OnPropertyChanged(nameof(SelectedKlasse));
                LadeAusleihscheine(); // neu laden bei Änderung
            }
        }

        // Filter: ausgewählte Objektart
        private string _selectedObjektart;
        public string SelectedObjektart
        {
            get => _selectedObjektart;
            set
            {
                _selectedObjektart = value;
                OnPropertyChanged(nameof(SelectedObjektart));
                LadeAusleihscheine(); // neu laden bei Änderung
            }
        }

        private string _nameFilter;
        public string NameFilter
        {
            get => _nameFilter;
            set
            {
                _nameFilter = value;
                OnPropertyChanged(nameof(NameFilter));
                LadeAusleihscheine(); // bei Änderung neu laden
            }
        }

        private ObservableCollection<Person> _erstellFensterEmpfaengerLst;
        public ObservableCollection<Person> ErstellFensterEmpfaengerLst
        {
            get => _erstellFensterEmpfaengerLst;
            set
            {
                _erstellFensterEmpfaengerLst = value;
                OnPropertyChanged(nameof(ErstellFensterEmpfaengerLst));

            }
        }

        private Person _erstellFensterEmpfaengerSel;
        public Person ErstellFensterEmpfaengerSel
        {
            get => _erstellFensterEmpfaengerSel;
            set
            {
                _erstellFensterEmpfaengerSel = value;
                OnPropertyChanged(nameof(ErstellFensterEmpfaengerSel));
                IsEmpaengerSelected = this._erstellFensterEmpfaengerSel != null;

            }
        }
        private ObservableCollection<string> _erstellFensterKlasseLst;
        public ObservableCollection<string> ErstellFensterKlasseLst
        {
            get => _erstellFensterKlasseLst;
            set
            {
                _erstellFensterKlasseLst = value;
                OnPropertyChanged(nameof(ErstellFensterKlasseLst));

            }
        }
        private string _erstellFensterKlasseSel;
        public string ErstellFensterKlasseSel
        {
            get => _erstellFensterKlasseSel;
            set
            {
                _erstellFensterKlasseSel = value;
                OnPropertyChanged(nameof(ErstellFensterKlasseSel));
                LadeErstellFensterEmpfaenger(); // bei Änderung neu laden
            }
        }

        private bool _isEmpaengerSelected;
        public bool IsEmpaengerSelected
        {
            get => _isEmpaengerSelected;
            set
            {
                _isEmpaengerSelected = value;
                OnPropertyChanged(nameof(IsEmpaengerSelected));

            }
        }

        // ComboBox-Datenquellen
        public ObservableCollection<string> KlassenListe { get; set; }
        public ObservableCollection<string> ObjektartenListe { get; set; }

        public MainWindowViewModel()
        {
            LstSchein = new ObservableCollection<AusleihSchein>();

            // ComboBoxen vorbereiten
            KlassenListe = new ObservableCollection<string>(Person.AlleKlassen().Prepend("Alle"));
            ObjektartenListe = new ObservableCollection<string>(Objekt.AlleObjektarten().Prepend("Alle"));

            // Standardfilter setzen
            SelectedKlasse = "Alle";
            SelectedObjektart = "Alle";
            CbSelbstErstellt = true;
        }

        public void LadeAusleihscheine()
        {
            List<string> filterteile = new();

            if (CbSelbstErstellt && User != null)
                filterteile.Add($"Ausleiher.Id = {User.Id}");

            if (!string.IsNullOrWhiteSpace(SelectedKlasse) && SelectedKlasse != "Alle")
                filterteile.Add($"Empfaenger.Klasse = '{SelectedKlasse}'");

            if (!string.IsNullOrWhiteSpace(SelectedObjektart) && SelectedObjektart != "Alle")
                filterteile.Add($"Objekt.Kategorie = '{SelectedObjektart}'");

            if (!string.IsNullOrWhiteSpace(NameFilter) && NameFilter != "Name eingeben")
                filterteile.Add($"Empfaenger.Nachname LIKE '%{NameFilter}%'");

            string filter = filterteile.Count > 0 ? string.Join(" AND ", filterteile) : "1=1";

            LstSchein = new ObservableCollection<AusleihSchein>(AusleihSchein.AlleLesen(filter));


        }

        public void LadeErstellFensterDaten()
        {
            ErstellFensterKlasseLst = new ObservableCollection<string>();
            ErstellFensterKlasseLst.Clear();
            ErstellFensterEmpfaengerLst = new ObservableCollection<Person>();
            ErstellFensterEmpfaengerLst.Clear();
            ErstellFensterEmpfaengerLst = new ObservableCollection<Person>(Person.AlleLesen(" Rolle = 3"));
           

            ErstellFensterKlasseLst = new ObservableCollection<string>(Person.AlleKlassen().Prepend("Alle"));
            ErstellFensterKlasseSel = "Alle"; // Standardwert setzen


        }
        public void LadeErstellFensterEmpfaenger()
        {
            if (ErstellFensterKlasseSel == "Alle")
            {
                ErstellFensterEmpfaengerLst = new ObservableCollection<Person>(Person.AlleLesen(" Rolle = 3"));

                if (ErstellFensterEmpfaengerLst.Count == 0)
                {
                    ErstellFensterEmpfaengerLst.Add(new Person(0, "Keine", "Keine", "Klasse"));
                }
            }
            else
            {
                ErstellFensterEmpfaengerLst = new ObservableCollection<Person>(Person.AlleLesen($"Rolle = 3 AND Klasse = '{ErstellFensterKlasseSel}'"));
            }
        }

        
    }
}
