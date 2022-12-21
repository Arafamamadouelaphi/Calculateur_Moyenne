using Bussness;
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
    public class MatiereDbDataManager<TContext> :IMatiereDbManager where TContext : CalculContext, new()
    {   //Maping entre la classe Matier et MatiereEntity
        public async Task<bool> Add(Matiere data)
        {
            bool result = false;
            using (var context = new CalculContext())
            {
                MatiereEntity entity = new MatiereEntity
                {
                    Nommatiere = data.Nommatiere,

                };               
                    context.matier.Add(entity);
                    await context.SaveChangesAsync();
                    result = true;                
            return result;

            }
        }

        public Task<bool> AddUEBloc(UE data, int blocId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Matiere mat)
        {
            bool result = false;
            using (var Context = new TContext())
            {
                MatiereEntity entity = Context.matier.Find(mat.Id);
                Context.matier.Remove(entity);
                result = await Context.SaveChangesAsync() > 0;
            }
            return result;
        }

        

        public async Task<List<Matiere>> GetAll()
        {
            using (var context = new TContext())
            {
                return await context.matier.Select(e => new Matiere
                (e.Id,
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
        public async Task<IEnumerable<Matiere>> GetAllMatiereUE(UE ue)
        {
            List<Matiere> ls = new List<Matiere>();
            using (var context = new TContext())
            {
                var BLC = await context.Ue.Include(m => m.mat)
                                      .SingleOrDefaultAsync(x => x.Id == ue.Id);
               
                if (BLC == null) return new List<Matiere>();
                foreach (var e in BLC.mat)
                {
                    ls.Add(new Matiere
                    {
                        Id=e.Id,
                        Note=e.Note,
                        Nommatiere=e.Nommatiere,
                        Coef=e.Coef

                        
                    });

                }
            }
            return ls;

        }

    }
}
