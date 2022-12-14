using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateurEF.Entities
{
    public class MaquetteEntity
    {
        //  public ReadOnlyCollection<BlocEntity> B { get; private set; }
        #region Propriétés
        public int Id { get; set; }
        public string NomMaquette { get; set; }

        public ICollection<BlocEntity> Bloc { get; set; }= new List<BlocEntity>();
       // public ICollection<UEentity> UeEntityId { get; set; } = new List<UEentity>();

        #endregion
        #region Constructeurs
        public MaquetteEntity()
        {
         Bloc= new List<BlocEntity>();
        }
        #endregion
    }
}
