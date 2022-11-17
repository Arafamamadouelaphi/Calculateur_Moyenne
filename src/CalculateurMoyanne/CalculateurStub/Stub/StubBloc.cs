using ClassCalculateurMoyenne;
using ClassCalculateurMoyenne.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubCalculateur.Stub
{
    public class StubBloc
    {
        private List<Bloc> listb = new List<Bloc>();
        public List<UE> ue = new List<UE>();

        public async Task<bool> Add(Bloc data)
        {
            if (data != null)
            {
                listb.Add(data);
                return true;
            }
            return false;
        }
        public  bool Delete(Bloc data)
        {
            if (data != null)
            {
                listb.Remove(data);
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<Bloc>> GetAll()
        {
            return listb;
        }
        public async Task<bool> Update(Bloc data)
        {
            if (data != null)
            {

                int index = listb.FindIndex(x => x.ue == data.ue);
                listb[index] = data;
            }
            return false;
        }
        public IEnumerable<Bloc> GetAllUE(int n = 10)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    ue.Add(new UE(""));
                }
                listb.Add(new Bloc(ue));
                ue.Clear();
            }
            return listb;
        }





    }

   
}
