using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateurEF.Entities
{
    public class BlocEntity
    {
        #region Propriétés
        public int Id { get; set; }
        public string Nom { get; set; }

        //public  ICollection<UEentity> ue { get; set; }


        //#region Constructeurs
        //public BlocEntity()
        //{
        //    ue = new List<UEentity>();
        //}
        #endregion

    }
}
