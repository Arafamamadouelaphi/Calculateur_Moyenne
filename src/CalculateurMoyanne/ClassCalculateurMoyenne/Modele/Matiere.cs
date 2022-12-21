using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCalculateurMoyenne
{
    public partial class Matiere : ObservableObject, IEquatable<Matiere>
    {
        public long Id { get; set; }
        public long IDUEForeignKey { get; set; }
        [ObservableProperty]
        private int note;
        [ObservableProperty]
        private int coef;
       private  string nommatiere;
        public string Nommatiere
        {
            get { return nommatiere; }
             set
            {
                if (string.IsNullOrWhiteSpace(value))

                {
                    throw new ArgumentException("Le Nom de la maquette est obligatoire");
                }

                nommatiere = value;
            }
        }
        //public void setNomMatier(string value)
        //{
        //    Nommatiere = value;

        //}



        //private void SetNomMaquette(string value)
        //{
        //    if (string.IsNullOrEmpty(value))

        //    {
        //        throw new ArgumentException("Nommatiere est obligatoire");
        //    }

        //    this.Nommatiere = value;

        //}


        public Matiere(long id, int note, string nommatiere, int coef)
        {
            Id = id;
            Coef = coef;
            Nommatiere = nommatiere;
            Note = note;

        }

        public Matiere( int note, string nommatiere, int coef)
        {
           
            Coef = coef;
            Nommatiere = nommatiere;
            Note = note;

        }

        public Matiere(string nommatiere)
        {
            Nommatiere = nommatiere;
        }

        public Matiere()
        {
        }

        public override string ToString()
        {
            return $"{Id},{Nommatiere},{Note},{Coef}";
        }
        

        public bool Equals(Matiere  other)
        {
            return Nommatiere.Equals(other.Nommatiere);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Matiere);
        }
        public override int GetHashCode()
        {
            return Nommatiere.GetHashCode();
        }
       

    }
}
