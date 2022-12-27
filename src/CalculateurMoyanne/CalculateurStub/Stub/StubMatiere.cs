using Bussness;
using ClassCalculateurMoyenne;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubCalculateur.Stub
{
    public class StubMatiere: IMatiereDbManager
    {
        private List<Matiere> listMatieres = new List<Matiere>();

        public async Task<bool> Add(Matiere data)
        {
            if (data != null)
            {
                listMatieres.Add(data);
                return true;
            }
            return false;
        }

        public bool delete(Matiere data)
        {
            if (data != null)
            {
             listMatieres .Remove(data);
                return true;
            }
            return false;
        }

        public Task<bool> Delete(Matiere data)
        {
            throw new NotImplementedException();
        }

        

        public Task<Matiere> GetDataWithName(string name)
        {
            throw new NotImplementedException();
        }

       

        public async Task<bool> Update(Matiere data)
        {
            if (data != null)
            {

                int index = listMatieres.FindIndex(x => x.Note == data.Note);
                listMatieres[index] = data;
            }
            return false;
        }

        public async Task<List<Matiere>> GetAll()
        {
            return listMatieres;
        }

        public Task<bool> AddUEBloc(UE data, int blocId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Matiere>> GetAllMatiereUE(UE ue)
        {
            throw new NotImplementedException();
        }
    }
}
