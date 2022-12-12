using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateurEF.Entities
{
    public class MatiereEntity
    {
        public string Nommatiere { get; set; }
        public long id { get; set; }
        public int Note { get; set; }
        public int Coef { get; set; }
        public long IDUEForeignKey
        {
            get; set;
        }
        [ForeignKey("IDUEForeignKey")]
        public UEentity  UEentity
        {
            get; set;
        }

    }
}
