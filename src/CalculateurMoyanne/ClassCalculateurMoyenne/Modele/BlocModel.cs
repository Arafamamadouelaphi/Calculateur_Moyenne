using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCalculateurMoyenne
{
    public partial class BlocModel : ObservableObject,IEquatable<BlocModel>
    {
        [ObservableProperty]
        private string nom;

        public double MoyenneBloc { get; set; }
        public int IDMaquetteFrk { get;  set; }
        public string GetNom()
        {
            return nom;
        }
        public int Id
        {
            get;
             set;
        }
        public void  setNom(string value)
        {
            if (string.IsNullOrWhiteSpace(value))

            {
                throw new ArgumentException("Le Nom est obligatoire");
            }

            nom = value;
        }
       
        [ObservableProperty]
        private UE[] uEs;

        public ReadOnlyCollection<UE> ue { get; private set; }//= new ReadOnlyCollection<UE>(new List<UE>());

        private  readonly List<UE> ues = new List<UE>();


        public BlocModel(string nombloc)
        {
            
            setNom(nombloc);
        }
        public BlocModel(string nombloc,int id, List<UE> Ux)
        {
            Id = id;
            nom = nombloc;
            ues.AddRange(Ux);
            ue = new ReadOnlyCollection<UE>(ues);

        }

        //public BlocModel(string nombloc, int id, List<UE> Ux,)
        //{
        //    Id = id;
        //    nom = nombloc;
        //    ues.AddRange(Ux);
        //    ue = new ReadOnlyCollection<UE>(ues);

        //}
       
        public BlocModel( List<UE> Ux)
        {
           
            ue = new ReadOnlyCollection<UE>(Ux);

        }

        public BlocModel(string nombloc, object value)
        {
            nom = nombloc;

        }
      
        public BlocModel(string nombloc, int id, UE[] uEs) 
        {
            nom = nombloc;
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
        public bool Equals(BlocModel other)
        {
            return  nom.Equals(other.GetNom());

        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as BlocModel);
        }
        public override int GetHashCode()
        {
            return nom.GetHashCode();
        }
    }
}
