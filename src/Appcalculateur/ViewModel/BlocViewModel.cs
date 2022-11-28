using ClassCalculateurMoyenne;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appcalculateur.ViewModel
{
    public partial class BlocViewModel :ObservableObject
    {
        public BlocModel blocModel { get; set; }
        public BlocViewModel()
        {
            Items = new ObservableCollection<BlocModel>();
            blocModel = new BlocModel();
        }
        [ObservableProperty]
        ObservableCollection<BlocModel> items;

        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrEmpty(blocModel.Nom))
                return;
            Items.Add(blocModel);
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
            await Shell.Current.GoToAsync($"{nameof(UE)}?Text={s}");

        }
    }


}

