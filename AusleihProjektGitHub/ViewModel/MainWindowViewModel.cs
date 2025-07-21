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
        private bool _cbSelbstErstellt;
        public bool CbSelbstErstellt
        {
            get 
            {
                return _cbSelbstErstellt;
            }
            set
            {
                _cbSelbstErstellt = value;
                OnPropertyChanged("CbSelbstErstellt");
            }
        }
        private Person _user;

        public Person User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

        public MainWindowViewModel()
        {
            string filter = "";
            if (CbSelbstErstellt) 
            {
                
                filter = $"ErstellerId = {User.Id}";
            }
            if(filter != "")
            {
                this.LstSchein = new ObservableCollection<AusleihSchein>(AusleihSchein.AlleLesen(filter));
            }
            else
                this.LstSchein = new ObservableCollection<AusleihSchein>(AusleihSchein.AlleLesen());
            
        }
    }
}

