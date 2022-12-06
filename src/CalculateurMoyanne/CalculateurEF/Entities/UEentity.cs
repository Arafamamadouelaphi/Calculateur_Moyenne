using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CalculateurEF.Entities
{
    public class UEentity
    {
        public long Id { get; set; }

        public int Coefficient { get; set; }
        public string intitulé { get; set; }
       public  ICollection<MatiereEntity> mat { get; set; }
        public List<MatiereEntity> matiere;


        public UEentity()
        {
            mat = new List<MatiereEntity>();
        }
    }
}
