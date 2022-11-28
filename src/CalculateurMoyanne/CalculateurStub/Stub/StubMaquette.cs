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
        private List<Maquette> lstmqt = new List<Maquette>();

        public bool Delete(Maquette data)
        {
            if (data != null)
            {
                lstmqt.Remove(data);
                return true;
            }
            return false;
        }
        public bool Add(Maquette data)
        {
            if(data != null)
            {
                lstmqt.Add(data);
                return true;
            }
            
            return false;
        }
       public IEnumerable<Maquette> GetAll()
        {
            return lstmqt;
        }
        public IEnumerable<Maquette> GetAllUeBloc(int n = 10)
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
             //   lstmqt.Add(new Maquette(ues,listb));
                ues.Clear();
            }
            return lstmqt;
        }





    }
}
