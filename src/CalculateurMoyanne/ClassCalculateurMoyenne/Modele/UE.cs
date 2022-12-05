using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ClassCalculateurMoyenne
{
    public partial class UE : ObservableObject, IEquatable<UE>
    {   public long Id { get; set; }
        public ReadOnlyCollection<Matiere> Matieres { get; private set; }
        private readonly List<Matiere> matieres = new List<Matiere>();
        [ObservableProperty]
        private int coefficient;
        [ObservableProperty]
        private string intitulé;


        public UE (   long id, int coefficient, string intitulé,params Matiere[] matieres)
        {
            Id = id;
            Coefficient = coefficient;
            Intitulé = intitulé;
            Matieres = new ReadOnlyCollection<Matiere>(matieres);

        }
        public void setIntitulé(string intitulé)
        {
            Intitulé = intitulé;
        }
        public UE( List<Matiere> _matieres, int coefficient)
        {
            
            Matieres = new ReadOnlyCollection<Matiere>(_matieres);
            Coefficient = coefficient;
            
        }
        public UE(string intitulé)
        {
            this.intitulé = intitulé;
        }
        public UE() { }

        public UE(string intitulé, int coefficient) 
            
        {
            Intitulé = intitulé;
            Coefficient = coefficient;
        }

        public override string ToString()
        {
            return $"{Id},{matieres},{Coefficient},{Intitulé}";

        }

        public bool Equals(UE other)
        {
            return matieres.Equals(other.matieres);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as UE);
        }
        public override int GetHashCode()
        {
            return Matieres.GetHashCode();
        }
        public IEnumerable<Matiere> AjouterMatiere(params Matiere[] matieres)
        {
            List<Matiere> result = new();
            result.AddRange(matieres.Where(a => AjouterMatiere(a)));
            return result;
        }
        public bool AjouterMatiere(Matiere matiere)
        {
            if (!IsExist(matiere))
            {
                matieres.Add(matiere);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsExist(Matiere nouvMatiere)
        {
            if (matieres.Contains(nouvMatiere))
                return true;
            return false;
        }
        public void SupprimerMatiere(Matiere matiere)
        {
            matieres.Remove(matiere);
        }
        //public void ajtCoef(int Coefficient)
        //{
        //    UE.Add(Coefficient);
        //}


    }
}
