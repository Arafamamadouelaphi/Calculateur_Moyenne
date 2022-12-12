using Bussness;
using ClassCalculateurMoyenne;
//using ClassCalculateurMoyenne.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubCalculateur.Stub
{
    public class StubBloc: IDataManager<BlocModel>
    {
        private List<BlocModel> listb = new List<BlocModel>();
        public List<UE> ue = new List<UE>();

        public async Task<bool> Add(BlocModel data)
        {
            if (data != null)
            {
                listb.Add(data);
                return true;
            }
            return false;
        }

        
        
        public async Task<bool> Update(BlocModel data)
        {
            if (data != null)
            {

                int index = listb.FindIndex(x => x.ue == data.ue);
                listb[index] = data;
            }
            return false;
        }
        public async Task<IEnumerable<BlocModel>> GetAllUEdb(int n = 10)
        {
                for (int j = 0; j < n; j++)
                {
                    ue.Add(new UE(""));
                }
                listb.Add(new BlocModel("ue"));
                ue.Clear();
            
            return listb;
        }
        public async Task <IEnumerable<BlocModel>> GetAllBloc(int n = 10)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    ue.Add(new UE("h"));
                }
                listb.Add(new BlocModel("ue"));
                ue.Clear();
            }
            return listb;
        }

       public  Task<bool> Delete(BlocModel data)
        {
            if (data != null)
            {
                listb.Remove(data);
                return Task.FromResult( true);
            }
            return Task.FromResult(false);
        }

        public Task<BlocModel> GetDataWithName(string name)
        {
            throw new NotImplementedException();
        }

       public async Task<List<BlocModel>> GetAll()
        {
            return listb;
        }

        public Task<bool> AddUEBloc(UE data, int blocId)
        {
            throw new NotImplementedException();
        }
    }

   
}
