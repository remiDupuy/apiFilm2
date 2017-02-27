using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.ViewModel
{
    class CompteViewModel : ViewModelBase
    {
        public ICommand BtnRechercher { get; private set; }

        public CompteViewModel()
        {
            BtnRechercher = new RelayCommand(ActionRechercher);
        }

        private void ActionRechercher()
        {

        }
    }
}
