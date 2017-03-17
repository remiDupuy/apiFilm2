using Client.Model;
using Client.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace Client.ViewModel
{
    class AjoutCompteViewModel : ViewModelBase
    {

        public ICommand BtnSaveAjoutCompteCommand { get; private set; }
        public ICommand BtnClearAjoutCompteCommand { get; private set; }
        
        private string _txtMail;

        private T_E_COMPTE_CPT compte;


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

        public AjoutCompteViewModel()
        {
            Compte = new T_E_COMPTE_CPT();
            BtnSaveAjoutCompteCommand = new RelayCommand(ActionCreate);
            BtnClearAjoutCompteCommand = new RelayCommand(ActionClear);
        }

        private async void ActionCreate()
        {
            var coord = await WSService.Instance.getCoordonnees(Compte.CPT_RUE, compte.CPT_CP, compte.CPT_VILLE);
            Compte.CPT_LATITUDE = coord.resourceSets[0].resources[0].geocodePoints[0].coordinates[0];
            Compte.CPT_LONGITUDE = coord.resourceSets[0].resources[0].geocodePoints[0].coordinates[1];

            // Create a string that contains the name of the hashing algorithm to use.
            String strAlgName = HashAlgorithmNames.Sha512;

            // Create a HashAlgorithmProvider object.
            HashAlgorithmProvider objAlgProv = HashAlgorithmProvider.OpenAlgorithm(strAlgName);

            // Create a CryptographicHash object. This object can be reused to continually
            // hash new messages.
            CryptographicHash objHash = objAlgProv.CreateHash();

            String strMsg1 = Compte.CPT_PWD;
            IBuffer buffMsg1 = CryptographicBuffer.ConvertStringToBinary(strMsg1, BinaryStringEncoding.Utf16BE);
            objHash.Append(buffMsg1);
            IBuffer buffHash1 = objHash.GetValueAndReset();

            Compte.CPT_PWD = CryptographicBuffer.EncodeToBase64String(buffHash1);
            var result = await WSService.Instance.createCompte(Compte);
            if(result)
            {
                MessageDialog msg = new MessageDialog("Compte ajouté");
                await msg.ShowAsync();
                Compte = new T_E_COMPTE_CPT();
            } else
            {
                MessageDialog msg = new MessageDialog("Erreur");
                await msg.ShowAsync();
            }
            
        }

        private void ActionClear()
        {
            Compte = new T_E_COMPTE_CPT();
        }



    
    }
}
