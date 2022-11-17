using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCalculateurMoyenne
{
    public class Maquette
    {
        public ReadOnlyCollection<UE> UES{ get; private set; }

        private readonly List<UE> ues = new List<UE>();
        public ReadOnlyCollection<Bloc> BLOCS { get; private set; }

        private readonly List<Bloc> blocs = new List<Bloc>();
        public Maquette(List<UE>u,List<Bloc>blc)
        {
            UES = new ReadOnlyCollection<UE>(u);
            BLOCS = new ReadOnlyCollection<Bloc>(blc);
      
        }
        public void supprimer(UE e)
        {
            ues.Remove(e);
        }
        public void supprimer(Bloc e)
        {
            blocs.Remove(e);
        }
        public bool ajouteUE(UE e)
        {
            if (IsExiste(e))
            {
                ues.Add(e);
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool ajouteBloc(Bloc b)
        {
            if (IsExiste(b))
            {
                blocs.Add(b);
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool IsExiste(Bloc b)
        {
            if(blocs.Contains(b))
                return true;
            return false;
        }

        public bool IsExiste(UE newue)
        {
            if (ues.Contains(newue))
                return true;
                return false;
        }



    }
}
