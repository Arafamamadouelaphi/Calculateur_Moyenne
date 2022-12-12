using System;
using System.Collections.ObjectModel;
using ClassCalculateurMoyenne;
using CalculateurMapping;
using Bussness;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CalculateurApp.View;
using System.Linq;

namespace CalculateurApp.ViewModel
{
    public partial class PageAjoutMaquette : ObservableObject
    {
        public MaquetteModel maquette { get; set; }
        public Manager manager;


        public PageAjoutMaquette()
        {
            manager = new Manager(new MaquetteDbDataManager<CalculDbMaui>());

            Items = new ObservableCollection<MaquetteModel>();
            foreach(var mm in manager.GetAllMaquette().Result)
           Items.Add( mm);
            maquette = new MaquetteModel();

        }

        [ObservableProperty]
        ObservableCollection<MaquetteModel> items;
        public string NomMaquette
        {
            get => maquette.NomMaquette;
            set => SetProperty(maquette.NomMaquette, value, maquette, (u, v) => u.setNomMaquete(v));

        }
        [RelayCommand]
        async void Add()
        {
            Manager maquetteDbDataManager = new Manager(new MaquetteDbDataManager<CalculDbMaui>());

            if (string.IsNullOrEmpty(NomMaquette))
                return;
            MaquetteModel u = maquette;
            Items.Add(u);
            await maquetteDbDataManager.AddMaquette(maquette);
            //maquette.NomMaquette = string.Empty;
           
        }
   [RelayCommand]
        async void Delete(MaquetteModel model)

        {
         
            if (Items.Contains(model))
            {
                Items.Remove(model);
                await manager.Deletemqt(model);

                var v = await manager.GetAllMaquette();
                Console.WriteLine(v);               

            }
        }



        [RelayCommand]
        async void GetAllMaquette()
        {
            Manager maquetteDbDataManager = new Manager(new MaquetteDbDataManager<CalculDbMaui>());

            await maquetteDbDataManager.GetAllMaquette();
        }
        [RelayCommand]
        async Task GoBack(string maquetteName)
        {
            var maquette = manager.GetMaquetteByName(maquetteName);

            var parametre = new Dictionary<string, Object>
            {
                {"maquette",maquette }
            };

            await Shell.Current.GoToAsync($"{nameof(BlockView)}",parametre);
        }

    }
}

