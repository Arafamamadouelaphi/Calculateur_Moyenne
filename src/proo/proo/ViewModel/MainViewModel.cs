using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proo.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<string> items;
        [ObservableProperty]
        string text;
        public MainViewModel()
        {
            Items = new ObservableCollection<string>();

        }

     
        [RelayCommand]
        void Add()
        {  if (string.IsNullOrWhiteSpace(Text))
                return;
            Items.Add(Text);
            Text = string.Empty;
        }
        [RelayCommand]
        void Delete(string s)
        {
            if (Items.Contains(s))
            {
                Items.Remove(s);
            }
        }
        [RelayCommand]
        async Task Tap(String s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
              
        }
    }
}
