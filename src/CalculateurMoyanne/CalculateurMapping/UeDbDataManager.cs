using BSN;
using CalculateurEF.Context;
using CalculateurEF.Entities;
using ClassCalculateurMoyenne;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CalculateurMapping
{
    public class UeDbDataManager : IDataManager<UE>
    {
        public async Task<bool> Add(UE data)
        {
            bool resultat = false;
            using (var context = new CalculContext())
            {
                UEentity entity = new UEentity
                {
                    intitulé = data.GetIntitulé(),
                };
                for (int i = 0; i < data.Matieres.Count; i++)
                {
                    MatiereEntity matiereEntity = new MatiereEntity
                    {
                        Nommatiere = data.Matieres[i].Nommatiere

                    };
                    context.Ue.Add(entity);
                    await context.SaveChangesAsync();
                    resultat = true;
                }
                return resultat;
            }
        }

        public  async Task<bool> Delete(UE data)
        {
            bool result = false;
            using (var context = new CalculContext())
            {
                UEentity entity = context.Ue.Find(data.Intitulé);
                context.Ue.Remove(entity);
                result = await context.SaveChangesAsync() > 0;

            }
            return true;
        }

        public async Task<IEnumerable<UE>> GetAll()
        {
            using (var context = new CalculContext())
            {
                return await context.Ue.Select(e => new UE
                (
                   e.Id,
                   e.Coefficient,
                   e.intitulé,
                   e.matiere.Select(j => new Matiere(j.Nommatiere)).ToArray()
                )).ToListAsync();
            }
        }

        public Task<UE> GetDataWithName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(UE data)
        {
            bool result = false;
            using (var context = new CalculContext())
            {
                UEentity entity = context.Ue.Find(data.Id);
                entity.intitulé = data.Intitulé;
                entity.matiere = data.Matieres.Select(j => new MatiereEntity
                {
                    Nommatiere = j.Nommatiere,
                }).ToList();
                result = await context.SaveChangesAsync() > 0;
            }
            return result;
        }
    }
}
