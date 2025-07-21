using AusleihProjektGitHub.Fachklassen;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AusleihProjektGitHub.ViewModel
{
    public class MainWindowViewModel : BaseModel
    {
        private ObservableCollection<AusleihSchein> _lstSchein;
        public ObservableCollection<AusleihSchein> LstSchein
        {
            get
            {
                return _lstSchein;
            }
            set
            {
                _lstSchein = value;
                OnPropertyChanged("LstSchein");
            }
        }
        private AusleihSchein _selectedSchein;
        public AusleihSchein SelectedSchein
        {
            get
            {
                return _selectedSchein;
            }
            set
            {
                _selectedSchein = value;
                OnPropertyChanged("SelectedSchein");
            }
        }

        public MainWindowViewModel()
        {
            this.LstSchein = new ObservableCollection<AusleihSchein>(AusleihSchein.AlleLesen());
            
        }
    }
}

