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
   // [QueryProperty("Nom", "Nom")]
    public partial class UeViewModel:ObservableObject
    {
        //[ObservableProperty]
        //string nom;

        //[RelayCommand]
        //async Task GoBack()
        //{
        //    await Shell.Current.GoToAsync("..");
        //}
     public UE u { get; set; }
     public Matiere ma { get; set; }

        public UeViewModel()
        {
            Tems = new ObservableCollection<Matiere>();
            Items = new ObservableCollection<Matiere>();
          

            ma = new Matiere();
            u = new UE();

        }
        [ObservableProperty]
        ObservableCollection<Matiere> items;
        [ObservableProperty]
        ObservableCollection<Matiere> tems;

        [ObservableProperty]
        string coefficient;
        [ObservableProperty]
        string nommatiere;
        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrEmpty(ma.Nommatiere))
                return;
            Matiere m = new Matiere(ma.Nommatiere);
            
            Items.Add(m);
            ma.Nommatiere = string.Empty;
        }
        [RelayCommand]
        void AddCoefUE()
        {
            
          
        }
        [RelayCommand]
        void Delete(Matiere bl)
        {
            if (Items.Contains(bl))
            {
                Items.Remove(bl);
            }
        }


    }
}
