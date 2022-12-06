using BSN;
using CalculateurEF.Context;
using CalculateurEF.Entities;
using ClassCalculateurMoyenne;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateurMapping
{
    public class MatiereDbDataManager : IDataManager<Matiere>
    {   //Maping entre la classe Matier et MatiereEntity
        public async Task<bool> Add(Matiere data)
        {
            bool result = false;
            using (var context = new CalculContext())
            {
                MatiereEntity entity = new MatiereEntity
                {
                    Nommatiere = data.GetNommatiere(),

                };               
                    context.matier.Add(entity);
                    await context.SaveChangesAsync();
                    result = true;                
            return result;

            }
        }

        public async Task<bool> Delete(Matiere mat)
        {
            bool result = false;
            using (var Context = new CalculContext())
            {
                MatiereEntity entity = Context.matier.Find(mat.GetNommatiere());
                Context.matier.Remove(entity);
                result = await Context.SaveChangesAsync() > 0;
            }
            return result;
        }

        public async Task<IEnumerable<Matiere>> GetAll()
        {
            using (var context = new CalculContext())
            {
                return await context.matier.Select(e => new Matiere
                (e.id,
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

        public async Task<bool> Update(Matiere mat)
        {
            bool result = false;
            using (var context = new CalculContext())
            {
                MatiereEntity entity = context.matier?.Find(mat.Id);
                if (entity != null)
                {
                    entity.Nommatiere = mat.Nommatiere;
                    result = await context.SaveChangesAsync() > 0;
                }
                return result;
            }


        }
    }
}
