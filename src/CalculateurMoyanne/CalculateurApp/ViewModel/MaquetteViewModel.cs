using BSN;
using CalculateurApp.View;
using CalculateurEF.Context;
using ClassCalculateurMoyenne;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateurApp.ViewModel
{
    public  partial class MaquetteViewModel:ObservableObject
    {
       // public  Maquette maquette { get; set; }
        public BlocModel blocModel { get; set; }

        public MaquetteViewModel()
        {
            Items = new ObservableCollection<BlocModel>();

            blocModel = new BlocModel();
        }
        [ObservableProperty]
        ObservableCollection<BlocModel> items;
       
        [ObservableProperty]
        string nom;
       
        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrEmpty(blocModel.Nom))
                return;
            BlocModel u = new BlocModel(blocModel.Nom);
            //u.Intitulé = ue.Intitulé;
            Items.Add(u);
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
        async Task Tap(String s)
        {
            await Shell.Current.GoToAsync($"{nameof(BlocModel)}?Nom={s}");

        }
        [RelayCommand]
        public void GetAllUE()
        {

           // var result=Manager
        }
    }
}
