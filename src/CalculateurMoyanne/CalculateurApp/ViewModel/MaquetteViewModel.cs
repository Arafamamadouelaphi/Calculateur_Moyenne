using Bussness;
using CalculateurApp.View;
using CalculateurEF.Context;
using CalculateurEF;
using CalculateurMapping;
using ClassCalculateurMoyenne;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CalculateurApp.ViewModel
{
    public  partial class MaquetteViewModel:ObservableObject
    {
       
        public BlocModel blocModel { get; set; }
       //public ReadOnlyObservableCollection<BlocModel>lst { get; set; }
        public Manager manager { get; set; }


        public MaquetteViewModel()
        { //route
            Routing.RegisterRoute(nameof(UeView), typeof(UeView));
        }
        public void init1()
        {
            Items = new ObservableCollection<BlocModel>();

            try
            {
                GetAllBloc();
                    
                blocModel = new BlocModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }


            blocModel = new BlocModel();
        }
        [ObservableProperty]
        ObservableCollection<BlocModel> items;
        [ObservableProperty]
        string nom;

      

    [RelayCommand]
        async void Add()
        {
            
            if (string.IsNullOrEmpty(Nom))
                return;
            blocModel.Nom = Nom;
            Items.Add(blocModel);
          await  manager.AddBlocmaquette(manager.SelectedMaquetteModel, blocModel);

        }
         [RelayCommand]
        async void Delete(BlocModel bl)
        
        {
            if (Items.Contains(bl))
            {
                Items.Remove(bl);
                await manager.DeleteBloc(bl);
                var o = await manager.GetAllBloc();
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
        async Task Tap(BlocModel blocModel)
        {
            // await Shell.Current.GoToAsync($"{nameof(UE)}?Nom={s}");
            manager.SelecteBlocModel =blocModel;
            var parametre = new Dictionary<string, Object>
            {
                {"ue",blocModel}
            };
            await Shell.Current.GoToAsync($"{nameof(UeView)}",parametre);

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
            items.Clear();

            var result = manager.GetByMaquette(manager.SelectedMaquetteModel);
           foreach(var item in  result.Result)
           {
                items.Add(item);

            }
        }
    }
}
