using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateurApp.ViewModel
{
    [QueryProperty("Nom", "Nom")]
    public partial class UeViewModel:ObservableObject
    {
        [ObservableProperty]
        string nom;

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}
