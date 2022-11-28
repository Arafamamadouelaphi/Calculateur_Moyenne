using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.Model
{
    public partial class Tache :ObservableObject
    {
        [ObservableProperty]
        private string text;
    }
}
