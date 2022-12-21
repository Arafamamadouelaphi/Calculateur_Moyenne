using ClassCalculateurMoyenne;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Bussness;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CalculateurApp.ViewModel
{
   
    public partial class UeViewModel:ObservableObject, IQueryAttributable
    {
        public Manager manager { get; set; }
      
        public Matiere ma { get; set; }

        public UeViewModel()
        {
          //Items = new ObservableCollection<Matiere>();
          //  ma = new Matiere();
           
           //init1();

        }
        public void init1()
        {
            Items = new ObservableCollection<Matiere>();

            try
            {
                GEtAllMatiere();
                ma = new Matiere();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            ma = new Matiere();
        }
        public string Nommatiere
        {
            get => ma.Nommatiere;
            set => SetProperty(ma.Nommatiere, value, ma, (u, v) => u.Nommatiere=v);

        }
        [ObservableProperty]
        ObservableCollection<Matiere> items;
        
        [ObservableProperty]
        int coefficient;
        [ObservableProperty]
        int note;

        [RelayCommand]
      async  void Add()
        {
           
            Matiere m = new Matiere(ma.Note, ma.Nommatiere, ma.Coef);
            Items.Add(m);
            await manager.AddMatiereUe(manager.SelectedUe, m);


        }
        [RelayCommand]
        async void Delete(Matiere bl)
        {
            if (Items.Contains(bl))
            {
                Items.Remove(bl);
                await manager.Deletee(bl);
                var y = await manager.GetAllMatUE();
            }

        }

        [RelayCommand]
        void GEtAllMatiere()
        {
            items.Clear();
            var result = manager.GetAllMatiereUE(manager.SelectedUe);
            foreach (var item in result.Result)
            {
                 items.Add(item);

            }

        }

       

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var Ue = query["matiere"] as UE;
            var MATList = Ue.Matieres;
            ma.IDUEForeignKey = Ue.Id;


            //var bloc = query["ue"] as BlocModel;
            //var ueList = bloc.ue;
            //ue.IDForeignKey = bloc.Id;


        }
    }
}
