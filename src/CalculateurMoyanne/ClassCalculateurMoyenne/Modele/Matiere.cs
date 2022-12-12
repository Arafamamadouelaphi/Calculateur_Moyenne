using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCalculateurMoyenne
{
    public   class Matiere
    {
        public long Id { get; set; }

        public string Nommatiere;
        public int Note { get; private set; }
        public int Coef { get; private set; }
        public string GetNommatiere()
        {
            return Nommatiere;
        }

        private void SetNomMaquette(string value)
        {
            this.Nommatiere = value;
        
        }


            public Matiere(long id ,int note, string nommatiere, int coef)
        {
            Id = id;
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
            return $"{Nommatiere},{Note},{Coef}";
        }
    }
}
