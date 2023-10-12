using Newtonsoft.Json;
using Plugin.CloudFirestore;
using Pump.Application.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Pump.ViewModels
{
    internal class FirstAcessViewModel : INotifyPropertyChanged
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
        public Command SkipBtn { get; }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
        #endregion


        public FirstAcessViewModel(INavigation navigation)
        {
            this._navigation = navigation;
            RegisterBtn = new Command(FirstAccessTappedAsync);
            SkipBtn = new Command(SkipBtnTappedAsync);

            Sexo = new ObservableCollection<Sexos>
            {
                new Sexos() { Name = "Masculino", },
                new Sexos() { Name = "Feminino", }
            };
        }

        //public event EventHandler OnPickerSelectedIndexChanged;

        private async void FirstAccessTappedAsync(object obj)
        {
            try
            {
                var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));
                var newItem = new UserMetaDataModel
                {
                    Email = userInfo.User.Email,
                    Peso = Peso,
                    Altura = Altura,
                    PanturrilaDireita = PanturrilaDireita,
                    PanturrilaEsquerda = PanturrilaEsquerda,
                    CoxaDireita = CoxaDireita,
                    CoxaEsquerda = CoxaEsquerda,
                    BicepsEsquerda = BicepsEsquerda,
                    BicepsDireto = BicepsDireto,
                    AnteBracoDireto = AnteBracoDireto,
                    AnteBracoEsquerdo = AnteBracoEsquerdo,
                    PunhoEsquerdo = PunhoEsquerdo,
                    PunhoDireto = PunhoDireto,
                    Peitoral = Peitoral,
                    Cintura = Cintura,
                    Pescoco = Pescoco,
                    PesoLivreGordura = PesoLivreGordura,
                    Sexo = Labelname
                };

                await CrossCloudFirestore.Current
                  .Instance
                  .Collection("UserMetaDataModel")
                  .AddAsync(newItem);

                await this._navigation.PushAsync(new Dashboard());
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Algo de errado aconteceu, tente novamente mais tarde!", "OK");
            }

        }

        private async void SkipBtnTappedAsync(object obj)
        {
            await App.Current.MainPage.DisplayAlert("Erro", "Tudo bem, Porem para conseguirmos te auxiliar precisamos de todas informações, caso você queria, pode atualizar os seus dados em seu perfil!", "OK");

            try
            {
                var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));
                var newItem = new UserMetaDataModel
                {
                    Email = userInfo.User.Email
                };

                await CrossCloudFirestore.Current
                  .Instance
                  .Collection("UserMetaDataModel")
                  .AddAsync(newItem);

                await this._navigation.PushAsync(new Dashboard());
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Algo de errado aconteceu, tente novamente mais tarde!", "OK");
            }
        }
    }
}
