using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.MVVM.Model
{
    [AddINotifyPropertyChangedInterface]
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName{ get; set; }
        public string Color { get; set; }
        public int PendingTask { get; set; }
        public float percentage { get; set; }



    }
}
