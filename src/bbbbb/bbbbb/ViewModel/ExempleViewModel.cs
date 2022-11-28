using bbbbb.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbbbb.ViewModel
{
    public partial class ExempleViewModel :ObservableObject
    { 
        public ExempleModel exemple { get; set; }
        public ExempleViewModel()
        {
            exemple=new ExempleModel();
            Items = new ObservableCollection<ExempleModel>();

        }
        [ObservableProperty]
       public ObservableCollection<ExempleModel> items;
       
        [RelayCommand]
       public  void Add()
        {
            if (string.IsNullOrEmpty(exemple.Nom))
                return;
            Items.Add(exemple);
            exemple.Nom = string.Empty;
        }
    }
}
