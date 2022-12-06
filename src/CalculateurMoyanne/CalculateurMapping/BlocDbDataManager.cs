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
    public class BlocDbDataManager : IDataManager<BlocModel>
    {
        public async Task<bool> Add(BlocModel data)
        {
            bool resultat = false;
            using (var context = new CalculContext())
            {
                BlocEntity entity = new BlocEntity
                {
                    Nom = data.Getnom(),
                };
                for (int i = 0; i < data.ue.Count; i++)
                {
                    UEentity uEentity = new UEentity
                    {
                        intitulé = data.ue[i].Intitulé
                      
                    };
                    context.Bloc.Add(entity);
                    await context.SaveChangesAsync();
                    resultat = true;
                }
                return resultat;
            }
        }

        public async Task<bool> Delete(BlocModel bloc)
        {
            bool result = false;
           using (var context = new CalculContext())
            {
                BlocEntity entity = context.Bloc.Find(bloc.Nom);
                context.Bloc.Remove(entity);
                result = await context.SaveChangesAsync() > 0;

            }
            return true;
        }

        public async Task<IEnumerable<BlocModel>> GetAll()
        {
            using (var context = new CalculContext())
            {
                return await  context.Bloc.Select(e => new BlocModel
                (
                   e.Nom,
                   e.Id,
                   e.ue.Select(j => new UE(j.intitulé)).ToArray()
                )).ToListAsync();
            }
        }

        public async Task<BlocModel> GetDataWithName(string name)
        {
            using (var context = new CalculContext())
            {
                return await context.Bloc.Where(e => e.Nom == name).Select(e => new BlocModel
                (   
                    e.Nom,            
                    e.ue.Select(j => new UE(j.intitulé)).ToArray()
                )).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> Update(BlocModel data)
        {
            bool result = false;
            using (var context = new CalculContext())
            {
                BlocEntity entity = context.Bloc.Find(data.Id);
                entity.Nom = data.Nom ;
                entity.ue = data.ue.Select(j => new UEentity
                {
                    intitulé = j.Intitulé,
                }).ToList();
                result = await context.SaveChangesAsync() > 0;
            }
            return result;
        }
    }
}
