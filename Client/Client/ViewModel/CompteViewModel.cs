using Client.Model;
using Client.Service;
using Client.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace Client.ViewModel
{
    class CompteViewModel : ViewModelBase
    {
        public ICommand BtnModifyCompteCommand { get; private set; }
        public ICommand BtnClearCompteCommand { get; private set; }

        public ICommand BtnAddCompteCommand { get; private set; }
        private string _txtMail;

        private T_E_COMPTE_CPT compte;
        public ICommand BtnRechercher { get; private set; }

        public string TxtMail
        {
            get
            { return _txtMail; }

            set
            {
                _txtMail = value;
                RaisePropertyChanged();
            }
        }

        public T_E_COMPTE_CPT Compte
        {
            get
            {
                return compte;
            }

            set
            {
                compte = value;
                RaisePropertyChanged();
            }
        }
        

        public CompteViewModel()
        {
            Compte = new T_E_COMPTE_CPT();
            BtnRechercher = new RelayCommand(ActionRechercher);
            BtnModifyCompteCommand = new RelayCommand(ActionEdit);
            BtnClearCompteCommand = new RelayCommand(ActionClear);
            BtnAddCompteCommand = new RelayCommand(ActionCreate);
        }

        private void ActionCreate()
        {
            (RootPage.mySplitView.Content as Frame).Navigate(typeof(AjoutCompte));
        }

        private void ActionClear()
        {
            Compte = new T_E_COMPTE_CPT();
        }

        private async void ActionEdit()
        {
            if(await WSService.Instance.putCompte(Compte))
            {
                Debug.WriteLine("ok");
            } else
            {
                Debug.WriteLine("pasOk");
            }
           
        }

        private async void ActionRechercher()
        {
            var content = await WSService.Instance.getCompteByEmail(TxtMail);
            Compte = content;
        }
    }
}
