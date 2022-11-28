using ClassCalculateurMoyenne;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubCalculateur.Stub
{
    public class StubMatiere
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
        public async Task<IEnumerable<Matiere>> GetAll()
        {
            return listMatieres;
        }

        public bool update(Matiere data)
        {
            if (data != null)
            {

                int index = listMatieres.FindIndex(x => x.Note == data.Note);
                listMatieres[index] = data;
            }
            return false;
        }

    }
}
