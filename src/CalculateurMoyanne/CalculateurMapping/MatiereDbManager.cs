using BSN;
using CalculateurEF.Context;
using ClassCalculateurMoyenne;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateurMapping
{
    public class MatiereDbManager : IDataManager<Matiere>
    {   //Maping entre la classe Matier et MatiereEntity
        public Task<bool> Add(Matiere data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Matiere data)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Matiere>> GetAll()
        {
            using (var context = new CalculContext())
            {
                return   await context.matier.Select(e => new Matiere
                (  e.id,
                   e.Note,                   
                   e.Nommatiere,
                   e.Coef
                )).ToListAsync();
            }
        }

        public Task<Matiere> GetDataWithName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Matiere data)
        {
            throw new NotImplementedException();
        }
    }
}
