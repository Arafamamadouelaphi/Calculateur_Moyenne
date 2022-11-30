using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCalculateurMoyenne
{
    public partial class BlocModel : ObservableObject
    {
        [ObservableProperty]
        private string nom;
        public long Id;
        private UE[] uEs;

        public ReadOnlyCollection<UE> ue { get; private set; }

    private  readonly List<UE> ues = new List<UE>();


        public BlocModel(string nombloc)
        {
            nom = nombloc;
        }
        public BlocModel(string nombloc,long id, List<UE> Ux)
        {
            Id = id;
            nom = nombloc;
            ue = new ReadOnlyCollection<UE>(Ux);

            //Ajouterue(Ux);

        }
        public BlocModel(string nombloc, object value)
        {
            nom = nombloc;
          
        }
        public BlocModel(string nombloc, int id, UE[] uEs) : this(nombloc)
        {
            Id = id;
            this.uEs = uEs;
        }

        public BlocModel()
        {
        }

        private IEnumerable<UE> Ajouterue(params UE[] ues)
        {
            List<UE> result = new();
            result.AddRange(ues.Where(a => Ajouterue(a)));
            return result;
        }


        //public override string ToString()
        //{
        //    return $"{ues}";
        //}
        //public IEnumerable<UE> Ajouterue(params UE[] ues)
        //{
        //    List<UE> result = new();
        //    result.AddRange(ues.Where(a => Ajouterue(a)));
        //    return result;
        //}
        public bool Ajouterue(UE uu)
        {
            if (!IsExist(uu))
            {
                ues.Add(uu);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SupprimerUE(UE c)
        {
            ues.Remove(c);
        }

        public bool IsExist(UE nouveauUE)
        {
            if (ues.Contains(nouveauUE))
                return true;
            return false;
        }

    }
}
