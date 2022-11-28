using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace db.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel()
        {
           
            
        }
        [ObservableProperty]
        ObservableCollection<string> items;
        [ObservableProperty]
        string text;
        [RelayCommand]
         void Add()
        {
           
        }
       
       
    }
}
