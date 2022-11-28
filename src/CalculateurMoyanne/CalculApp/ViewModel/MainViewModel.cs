using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CalculApp.ViewModel
{
    public partial class MainViewModel:ObservableObject
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<string>();

        }

        [ObservableProperty]
        ObservableCollection<string> items;
        [ObservableProperty]
        string nom;
        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrWhiteSpace(Nom))
                return;
            Items.Add(Nom);
            Nom = string.Empty;
        }
        [RelayCommand]
        void Delete(string s)
        {
            if (Items.Contains(s))
            {
                Items.Remove(s);
            }
        }
    }
}

