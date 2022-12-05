using ClassCalculateurMoyenne;
using ClassCalculateurMoyenne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubCalculateur.Stub
{
    public class StubMaquette
    {
        private List<BlocModel> listb = new List<BlocModel>();
        public List<UE> ues = new List<UE>();
        private List<MaquetteModel> lstmqt = new List<MaquetteModel>();

        public bool Delete(MaquetteModel data)
        {
            if (data != null)
            {
                lstmqt.Remove(data);
                return true;
            }
            return false;
        }
        public bool Add(MaquetteModel data)
        {
            if(data != null)
            {
                lstmqt.Add(data);
                return true;
            }
            
            return false;
        }
        public async Task<IEnumerable<MaquetteModel>> GetAll()
        {
            return lstmqt;
        }
        public async Task<IEnumerable<MaquetteModel>> GetAllMaquette(int n = 10)
        {
            for (int i = 0; i < n; i++)
            {
                Add(new MaquetteModel("Maquette " + i + 1));
            }
            return lstmqt;
        }
        public async Task<bool> Update(MaquetteModel data)
        {
            if (data != null)
            {
                int index = lstmqt.FindIndex(x => x.BLOCS == data.BLOCS);
                lstmqt[index] = data;
            }
            return false;
        }
        public IEnumerable<MaquetteModel> GetAllUeBloc(int n = 10)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    ues.Add(new UE(""));
                }
                for(int v = 0; v < 10; v++)
                {
                    listb.Add(new BlocModel(""));
                }
                lstmqt.Add(new MaquetteModel(ues,listb));
                ues.Clear();
            }
            return lstmqt;
        }





    }
}
