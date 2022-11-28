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
    public class MaquetteDbDataManager : IDataManager<Maquette>
    {
        public async Task<bool> Add(Maquette mqt)
        {
            bool result = false;
            using (var context = new CalculContext())
            {
                MaquetteEntity entity = new MaquetteEntity
                {
                    NomMaquette = mqt.NomMaquette,
                };
                for (int i = 0; i < mqt.BLOCS.Count; i++)
                {                   
                    BlocEntity blocentitie = new BlocEntity
                    {
                        Nom = mqt.BLOCS[i].Nom
                    };
                    context.Maquettes.Add(entity);
                    await context.SaveChangesAsync();
                    result = true;
                }
                return result;

            }




        }

        public async Task<bool> Delete(Maquette maquette)
        {
            bool result = false;
            using (var context = new CalculContext())
            {
                MaquetteEntity entity = context.Maquettes.Find(maquette.NomMaquette);
                context.Maquettes.Remove(entity);
                result = await context.SaveChangesAsync() > 0;

            }
            return result;
        }

        public async Task<IEnumerable<Maquette>> GetAll()
        {
            using (var context = new CalculContext())
            {
                return await  context.Maquettes.Select(e => new Maquette
                (  e.Id,
                    e.NomMaquette,
                    e.Bloc.Select(j => new BlocModel(j.Nom)).ToArray()
                )).ToListAsync();
            }
        }

        public async Task<Maquette> GetDataWithName(string name)
        {
            using (var context = new CalculContext())
            {
                return await  context.Maquettes.Where(e => e.NomMaquette == name).Select(e => new Maquette
                (
                     e.Id,
                    e.NomMaquette,
                    e.Bloc.Select(j => new BlocModel(j.Nom)).ToArray()
                )).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> Update(Maquette data)
        {
            bool result = false;
            using (var context = new CalculContext())
            {
                MaquetteEntity entity = context.Maquettes.Find(data.Id);
                entity.NomMaquette = data.NomMaquette;
                entity.Bloc = data.BLOCS.Select(j => new BlocEntity
                {                   
                   Nom=j.Nom,
                }).ToList();
                result = await context.SaveChangesAsync() > 0;
            }
            return result;
        }
    }
}
