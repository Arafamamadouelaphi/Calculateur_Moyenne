using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCalculateurMoyenne
{
    public  class Maquette
    {
        public int Id;
        public ReadOnlyCollection<UE> UES { get; set; }

        private readonly List<UE> ues = new List<UE>();

        public ReadOnlyCollection<BlocModel> BLOCS { get; private set; }
        public string NomMaquette { get; set; }

        private readonly List<BlocModel> blocs = new List<BlocModel>();
        private object value;

        public Maquette(List<UE> u, List<BlocModel> blc)
        {
            UES = new ReadOnlyCollection<UE>(u);
            BLOCS = new ReadOnlyCollection<BlocModel>(blc);

        }

        public Maquette(long id,string nomMaquette, object value)
        {
            Id = Id;
            NomMaquette = nomMaquette;
            this.value = value;
        }

        public void supprimer(UE e)
        {
            ues.Remove(e);
        }
        public void supprimer(BlocModel e)
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
        public bool ajouteBloc(BlocModel b)
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

        private bool IsExiste(BlocModel b)
        {
            if (blocs.Contains(b))
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
