using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCalculateurMoyenne
{
    public class Bloc
    {
        public int Id; 
        public ReadOnlyCollection<UE> ue { get; private set; }

        private readonly List<UE> ues = new List<UE>();
        public Bloc(int id)
        {
            Id = id;
        }
        //public override string ToString()
        //{
        //    return $"{ues}";
        //}
        public IEnumerable<UE> Ajouterue(params UE[] ues)
        {
            List<UE> result = new();
            result.AddRange(ues.Where(a => Ajouterue(a)));
            return result;
        }
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
