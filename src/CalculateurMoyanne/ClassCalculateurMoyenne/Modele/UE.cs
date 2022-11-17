using System.Collections.ObjectModel;

namespace ClassCalculateurMoyenne
{
    public class UE : IEquatable<UE>
    {
        public ReadOnlyCollection<Matiere> Matieres { get; private set; }

        private readonly List<Matiere> matieres = new List<Matiere>();
        public int Coefficient { get; set; }
        public string Intitulé { get; set; }
        //public UE(List<Matiere> _matieres, int coefficient ,string intitulé)
        //{
        //    Matieres = new ReadOnlyCollection<Matiere>(_matieres);
        //    Coefficient = coefficient;
        //   Intitulé = intitulé;
        //}
        public UE(string intitulé)
        {
            intitulé = intitulé;
        }
        public override string ToString()
        {
            return $"{matieres},{Coefficient},{Intitulé}";

        }

        public bool Equals(UE other)
        {
            return Equals(other.Intitulé);
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
