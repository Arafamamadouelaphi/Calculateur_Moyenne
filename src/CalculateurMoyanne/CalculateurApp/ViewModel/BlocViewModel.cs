using ClassCalculateurMoyenne;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Bussness;
using System.Threading.Tasks;
using System.Diagnostics;
using CalculateurApp.View;

namespace CalculateurApp.ViewModel;


public partial class BlocViewModel:ObservableObject,IQueryAttributable
{
    public UE ue { get; set; }
    public Manager manager { get; set; }
    public BlocViewModel()
    {
     Routing.RegisterRoute(nameof(MatiereView), typeof(MatiereView));
     //ue = new UE();
      // Items = new ObservableCollection<UE>();
    }

    public void init1()
    {
        Items = new ObservableCollection<UE>();

        try
        {
            GEtAllUE();

            ue = new UE();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }


        ue = new UE();
    }
    [ObservableProperty]
    ObservableCollection<UE> items;
    [ObservableProperty]
    string intitulé;

    [RelayCommand]
    async void Add()
    {
        if (string.IsNullOrEmpty(Intitulé)&& string.IsNullOrEmpty(ue.Coefficient.ToString()))
            return;
        // ue.Intitulé = Intitulé;
        UE u = new UE(Intitulé, ue.Coefficient);
        Items.Add(u);
        await manager.AddUeBloc(manager.SelecteBlocModel, u);
      
    }
    [RelayCommand]
    async void Delete(UE bl)
    {
        if (Items.Contains(bl))
        {
            Items.Remove(bl);
            await manager.DeleteUe(bl);
            var y = await manager.GetAllue();
        }

    }
     [RelayCommand]
        async Task Tapp(UE ue)
        {
        // await Shell.Current.GoToAsync($"{nameof(UE)}?Nom={s}");
        //manager.SelecteBlocModel =blocModel;
        //var parametre = new Dictionary<string, Object>
        //{
        //    {"ue",blocModel}
        //};
        //await Shell.Current.GoToAsync($"{nameof(UeView)}",parametre);


        manager.SelectedUe = ue;
        var parametre = new Dictionary<string, Object>
            {
                {"matiere",ue}
            };
        await Shell.Current.GoToAsync($"{nameof(MatiereView)}", parametre);

    }
    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
    //page
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var bloc = query["ue"] as BlocModel;
        var ueList = bloc.ue;
        ue.IDForeignKey = bloc.Id;
    }
    [RelayCommand]
    void GEtAllUE()
    {
        items.Clear();
        var result = manager.GetAllUEBloc(manager.SelecteBlocModel);
        foreach (var item in result.Result)
        {
            items.Add(item);

        }

    }


}






