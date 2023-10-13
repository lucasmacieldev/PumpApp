using Newtonsoft.Json;
using Plugin.CloudFirestore;
using Pump.Application.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.Emit;

namespace Pump.ViewModels
{
    internal class PerfilViewModel : INotifyPropertyChanged
    {
        #region vars
        private INavigation _navigation;
        public event PropertyChangedEventHandler PropertyChanged;

        public string peso { get; set; }
        public string Peso
        {
            get => peso; set
            {
                peso = value;
                RaisePropertyChanged("Peso");
            }
        }
        public string altura { get; set; }
        public string Altura
        {
            get => altura; set
            {
                altura = value;
                RaisePropertyChanged("Altura");
            }
        }

        public string panturrilaDireita { get; set; }
        public string PanturrilaDireita
        {
            get => panturrilaDireita; set
            {
                panturrilaDireita = value;
                RaisePropertyChanged("PanturrilaDireita");
            }
        }

        public string panturrilaEsquerda { get; set; }
        public string PanturrilaEsquerda
        {
            get => panturrilaEsquerda; set
            {
                panturrilaEsquerda = value;
                RaisePropertyChanged("PanturrilaEsquerda");
            }
        }
        public string coxaDireita { get; set; }
        public string CoxaDireita
        {
            get => coxaDireita; set
            {
                coxaDireita = value;
                RaisePropertyChanged("CoxaDireita");
            }
        }
        public string coxaEsquerda { get; set; }
        public string CoxaEsquerda
        {
            get => coxaEsquerda; set
            {
                coxaEsquerda = value;
                RaisePropertyChanged("CoxaEsquerda");
            }
        }
        public string bicepsEsquerda { get; set; }
        public string BicepsEsquerda
        {
            get => bicepsEsquerda; set
            {
                bicepsEsquerda = value;
                RaisePropertyChanged("BicepsEsquerda");
            }
        }
        public string bicepsDireto { get; set; }
        public string BicepsDireto
        {
            get => bicepsDireto; set
            {
                bicepsDireto = value;
                RaisePropertyChanged("BicepsDireto");
            }
        }
        public string anteBracoDireto { get; set; }
        public string AnteBracoDireto
        {
            get => anteBracoDireto; set
            {
                anteBracoDireto = value;
                RaisePropertyChanged("AnteBracoDireto");
            }
        }
        public string anteBracoEsquerdo { get; set; }
        public string AnteBracoEsquerdo
        {
            get => anteBracoEsquerdo; set
            {
                anteBracoEsquerdo = value;
                RaisePropertyChanged("AnteBracoEsquerdo");
            }
        }
        public string punhoEsquerdo { get; set; }
        public string PunhoEsquerdo
        {
            get => punhoEsquerdo; set
            {
                punhoEsquerdo = value;
                RaisePropertyChanged("PunhoEsquerdo");
            }
        }
        public string punhoDireto { get; set; }
        public string PunhoDireto
        {
            get => punhoDireto; set
            {
                punhoDireto = value;
                RaisePropertyChanged("PunhoDireto");
            }
        }
        public string peitoral { get; set; }
        public string Peitoral
        {
            get => peitoral; set
            {
                peitoral = value;
                RaisePropertyChanged("Peitoral");
            }
        }
        public string cintura { get; set; }
        public string Cintura
        {
            get => cintura; set
            {
                cintura = value;
                RaisePropertyChanged("Cintura");
            }
        }
        public string pescoco { get; set; }
        public string Pescoco
        {
            get => pescoco; set
            {
                pescoco = value;
                RaisePropertyChanged("Pescoco");
            }
        }

        public string pesoLivreGordura { get; set; }
        public string PesoLivreGordura
        {
            get => pesoLivreGordura; set
            {
                pesoLivreGordura = value;
                RaisePropertyChanged("PesoLivreGordura");
            }
        }

        public string labelname { get; set; }
        public string Labelname
        {
            get => labelname; set
            {
                labelname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("labelname"));
            }
        }
        public class Sexos
        {
            public string Name { get; set; }
        }
        public ObservableCollection<Sexos> Sexo{ get; set; }

        public Command RegisterBtn { get; }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
        #endregion


        public PerfilViewModel(INavigation navigation)
        {
            this._navigation = navigation;
            RegisterBtn = new Command(UpdateTappedAsync);

            LoadInfos();

            Sexo = new ObservableCollection<Sexos>
            {
                new Sexos() { Name = "Masculino", },
                new Sexos() { Name = "Feminino", }
            };
        }

        private async void LoadInfos()
        {
            var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));

            var response = await CrossCloudFirestore.Current
             .Instance
             .Collection("UserMetaDataModel")
             .WhereEqualsTo("Email", userInfo.User.Email)
             .GetAsync();

            var modelResponse = response.Documents.FirstOrDefault().ToObject<UserMetaDataModel>();

            Peso = modelResponse.Peso;
            Altura = modelResponse.Altura;
            PanturrilaDireita = modelResponse.PanturrilaDireita;
            PanturrilaEsquerda = modelResponse.PanturrilaEsquerda;
            CoxaDireita = modelResponse.CoxaDireita;
            CoxaEsquerda = modelResponse.CoxaEsquerda;
            BicepsEsquerda = modelResponse.BicepsEsquerda;
            BicepsDireto = modelResponse.BicepsDireto;
            AnteBracoDireto = modelResponse.AnteBracoDireto;
            AnteBracoEsquerdo = modelResponse.AnteBracoEsquerdo;
            PunhoEsquerdo = modelResponse.PunhoEsquerdo;
            PunhoDireto = modelResponse.PunhoDireto;
            Peitoral = modelResponse.Peitoral;
            Cintura = modelResponse.Cintura;
            Pescoco = modelResponse.Pescoco;
            PesoLivreGordura = modelResponse.PesoLivreGordura;
            Labelname = modelResponse.Sexo;
        }

        private async void UpdateTappedAsync(object obj)
        {
            try
            {
                var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));

                var response = await CrossCloudFirestore.Current
                     .Instance
                     .Collection("UserMetaDataModel")
                     .WhereEqualsTo("Email", userInfo.User.Email)
                     .GetAsync();

                await this._navigation.PushAsync(new Dashboard());
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Algo de errado aconteceu, tente novamente mais tarde!", "OK");
            }

        }
    }
}
