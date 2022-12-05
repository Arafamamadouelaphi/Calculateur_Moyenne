using BSN;
using ClassCalculateurMoyenne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateurMapping
{
    public class UeDbDataManager : IDataManager<UE>
    {
        public Task<bool> Add(UE data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(UE data)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UE>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UE> GetDataWithName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UE data)
        {
            throw new NotImplementedException();
        }
    }
}
