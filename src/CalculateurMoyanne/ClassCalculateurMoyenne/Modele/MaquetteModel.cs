using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCalculateurMoyenne
{
    public  class MaquetteModel:IEquatable<MaquetteModel>
    {
        public int Id;
        public ReadOnlyCollection<UE> UES { get; set; }

        private readonly List<UE> ues = new List<UE>();

        public ReadOnlyCollection<BlocModel> BLOCS { get; private set; }
        public string NomMaquette { get; set; }

        private readonly List<BlocModel> blocs = new List<BlocModel>();
        private object value;

        public MaquetteModel(List<UE> u, List<BlocModel> blc)
        {
            UES = new ReadOnlyCollection<UE>(u);
            BLOCS = new ReadOnlyCollection<BlocModel>(blc);

        }

        public MaquetteModel(long id,string nomMaquette, object value)
        {
            Id = Id;
            NomMaquette = nomMaquette;
            this.value = value;
        }
        public MaquetteModel( string nomMaquette)
        {
            
            NomMaquette = nomMaquette;
            
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

        public bool Equals(MaquetteModel other)
        {
            return Equals(other.NomMaquette);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as UE);
        }

        public MaquetteModel(string nomMaquette, int id)

        {
            NomMaquette = nomMaquette;
            Id = id;
        }
        public void setNomMaquete(string nom)
        {
            NomMaquette =nom;
        }

    }
}
