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

namespace CalculateurApp.ViewModel;

public  partial class MaquetteViewModel:ObservableObject
{
   
    public BlocModel blocModel { get; set; }
   // public ReadOnlyObservableCollection<BlocModel>lst { get; set; }
    public Manager manager { get; set; }


    public MaquetteViewModel()
    {
        //Items = new ObservableCollection<BlocModel>();

        //try
        //{
        //    foreach (var BB in manager.GetAllBloc().Result)
        //        Items.Add(BB);
        //}
        //catch (Exception ex)
        //{
        //    Debug.WriteLine(ex);
        //}
       

        //blocModel = new BlocModel();
    }
    public void init1()
    {
        Items = new ObservableCollection<BlocModel>();

        try
        {
            foreach (var BB in manager.GetAllBloc().Result)
                Items.Add(BB);
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
    ObservableCollection<BlocModel> lstblc=new ObservableCollection<BlocModel>();
    [ObservableProperty]
    string nom;

[RelayCommand]
    async void Add()
    {
       // Manager blocDbDataManager = new Manager(new BlocDbDataManager<CalculDbMaui>());
     
        if (string.IsNullOrEmpty(blocModel.Nom))
            return;
        //BlocModel u = blocModel;
        //MaquetteModel u = new MaquetteModel();
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

       
        //if (Items.Contains(model))
        //{
        //    Items.Remove(model);
        //    await manager.Deletemqt(model);

        //    var v = await manager.GetAllMaquette();
        //    Console.WriteLine(v);

        //}
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
        await Shell.Current.GoToAsync($"{nameof(UE)}?Nom={s}");

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

    [RelayCommand]
    public void Blocview(IEnumerable<BlocModel> blocModels)
    {
        //items.Add
    }
}
