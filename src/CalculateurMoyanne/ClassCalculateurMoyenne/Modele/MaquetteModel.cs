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
        public int Id
        {
             get;
             set;
        }

        private string nomMaquette;
        public double moyenneMaquuete { get; set; }

        public string NomMaquette
        {
            get { return nomMaquette; }
         private  set
            {
                if (string.IsNullOrWhiteSpace(value))

                {
                    throw new ArgumentException("Le Nom de la maquette est obligatoire");
                }

                nomMaquette = value;
            }
        }
        //public string GetNomMaquette()
        //{
        //    return NomMaquette;
        //}
        //private  void SetNomMaquette(string value)
        //{

        //    if (string.IsNullOrWhiteSpace(value))

        //    {
        //        throw new ArgumentException("Le Nom de la maquette est obligatoire");
        //    }

        //    NomMaquette = value;
        //}
        public ReadOnlyCollection<UE> UES { get; private set; }
        private readonly List<UE> ues = new List<UE>();
        public ReadOnlyCollection<BlocModel> BLOCS { get; private set; }
        private readonly List<BlocModel> blocs = new List<BlocModel>();
        



        public MaquetteModel(int id, string nomMaquette, double moyennemkt, List<BlocModel> blc)
        {
            Id = id;
            NomMaquette = nomMaquette;
            moyenneMaquuete = moyennemkt;
            BLOCS = new ReadOnlyCollection<BlocModel>(blocs);
            blocs.AddRange(blc);

        }
        public MaquetteModel(int id, string nomMaquette, double moyennemkt)
        {
            Id = id;
            NomMaquette = nomMaquette;
            moyenneMaquuete = moyennemkt;
           

        }
        public MaquetteModel(List<UE> u, List<BlocModel> blocs)
        {
            UES = u.AsReadOnly();
            //la
            BLOCS = new ReadOnlyCollection<BlocModel>(blocs);
        }

        public MaquetteModel(int id,string nomMaquette)
        {
            Id = id;
            setNomMaquete(nomMaquette);
          
        }
        public MaquetteModel( string nomMaquette)
        {

            setNomMaquete(nomMaquette);
            
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
        public override int GetHashCode()
        {
            return NomMaquette.GetHashCode();
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
            return NomMaquette. Equals(other.NomMaquette);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as MaquetteModel);
        }

        public MaquetteModel(string nomMaquette, int id)

        {
            setNomMaquete(nomMaquette);
            Id = id;
        }

        public MaquetteModel()
        {
        }

        //pour faire les tests updt stub
        public void setNomMaquete(string value)
        {
            NomMaquette = value;
        }
    }

}
