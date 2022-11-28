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
        [ObservableProperty]
        string nom;
        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
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

        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrEmpty(ue.Intitulé))
                return;
            UE u = new UE(ue.Intitulé);
            //u.Intitulé = ue.Intitulé;
            Items.Add(u);
            ue.Intitulé = string.Empty;
        }
        [RelayCommand]
        void Delete(UE bl)
        {
            if (Items.Contains(bl))
            {
                Items.Remove(bl);
            }
        }


        
        //[RelayCommand]
        //async Task Tap(String s)
        //{
        //    await Shell.Current.GoToAsync($"{nameof(UE)}?Nom={s}");

        //}
    }


    //    public ObservableCollection<BlocModel> blcs { get; set; }
    //    public BlocViewModel()
    //    {
    //        Items = new ObservableCollection<string>();

    //    }

    //    [ObservableProperty]
    //    ObservableCollection<int> item;

    //    [RelayCommand]
    //    public void FillData()
    //    {
    //        blcs = new ObservableCollection<BlocModel>
    //        {
    //            new BlocModel()
    //            {
    //                id=0,
    //            },
    //            new BlocModel()
    //            {
    //                id=1,
    //            },
    //            new BlocModel()
    //            {
    //                id=2,
    //            },
    //            new BlocModel()
    //            {
    //                id=3,
    //            },
    //            new BlocModel()
    //            {
    //                id=4,
    //            },
    //        };

    //ckkkkkkkk}
}

