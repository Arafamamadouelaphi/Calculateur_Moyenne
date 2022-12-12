using Bussness;
using CalculateurApp.View;
using CalculateurEF.Context;
using CalculateurMapping;
using ClassCalculateurMoyenne;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CalculateurApp.ViewModel
{
    public  partial class MaquetteViewModel:ObservableObject
    {
       
        public BlocModel blocModel { get; set; }
       // public ReadOnlyObservableCollection<BlocModel>lst { get; set; }
        public Manager manager;

        public MaquetteViewModel()
        {
            Items = new ObservableCollection<BlocModel>();
            //foreach (var BB in manager.GetAllBloc().Result)
            //    Items.Add(BB);
            blocModel = new BlocModel();
        }
        [ObservableProperty]
        ObservableCollection<BlocModel> items;
        [ObservableProperty]
        ObservableCollection<BlocModel> lstblc=new ObservableCollection<BlocModel>();

        [ObservableProperty]
        string nom;
       
        [RelayCommand]
        void Add()
        {
            Manager blocDbDataManager = new Manager(new BlocDbDataManager<CalculDbMaui>());
            if (string.IsNullOrEmpty(blocModel.Nom))
                return;
            BlocModel u = new BlocModel(blocModel.Nom);        
            Items.Add(u);
            blocDbDataManager.AddBloc(blocModel);
            blocModel.Nom = string.Empty; 
        }
         [RelayCommand]
        void Delete(BlocModel bl)
        
        {
            if (Items.Contains(bl))
            {
                Items.Remove(bl);
            }
        }
        
        [RelayCommand]
        void AjoutUE(BlocModel bl)

        {
            if (Items.Contains(bl))
            {
                Items.Remove(bl);
            }
        }



        [RelayCommand]
        async Task Tap(String s)
        {
            await Shell.Current.GoToAsync($"{nameof(BlocModel)}?Nom={s}");

        }
        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var Maquette = query["maquette"] as MaquetteModel;

            blocModel.IDMaquetteFrk = Maquette.Id;
        }
        [RelayCommand]
        public void GetAllBloc()
        {

            var result = manager.GetAllBloc();
           foreach(var item in  result.Result)
           {
                lstblc.Add(item);

            }
        }
    }
}
