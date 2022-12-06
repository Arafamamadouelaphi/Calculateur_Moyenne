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
    [QueryProperty("Nom", "Nom")]
    public partial class BlocViewModel:ObservableObject
    {
        
       
        public BlocModel blocModel { get; set; }
        public UE ue { get; set; }
        public BlocViewModel()
        {
            Items = new ObservableCollection<UE>();
            blocModel=new BlocModel();
            ue = new UE();

        }
        [ObservableProperty]
        ObservableCollection<UE> items;
        [ObservableProperty]
        string intitulé;


        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrEmpty(ue.Intitulé)&& string.IsNullOrEmpty(ue.Coefficient.ToString()))
                return;
            UE u = new UE(ue.Intitulé,ue.Coefficient);
            //u.Intitulé = ue.Intitulé;
            Items.Add(u);
            ue.Intitulé = string.Empty;
            ue.Coefficient = 0;
        }
        [RelayCommand]
        void Delete(UE bl)
        {
            if (Items.Contains(bl))
            {
                Items.Remove(bl);
            }
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }


  

   
}

