using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCalculateurMoyenne
{
    public class MoyenneGeneral 
    {    public long Id { get; set; }
        public int Resultat { get; set; }
        public MoyenneGeneral( long id,int   resultat) 
        
        {
            Id = id;
            Resultat = resultat;

        }

       
        
    }
}
