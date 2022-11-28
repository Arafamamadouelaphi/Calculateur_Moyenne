using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSN
{
    public interface IDataManager<Data>
    {
        Task<bool> Add(Data data);
        Task<bool> Delete(Data data);
        Task<bool> Update(Data data);
        Task<Data> GetDataWithName(string name);
        Task<IEnumerable<Data>> GetAll();
    }
}
