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
    public class MaquetteDbDataManager : IDataManager<MaquetteModel>
    {
        public async Task<bool> Add(MaquetteModel mqt)
        {
            bool result = false;
            using (var context = new CalculContext())
            {
                MaquetteEntity entity = new MaquetteEntity
                {
                    NomMaquette = mqt.GetNomMaquette(),
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

        public async Task<bool> Delete(MaquetteModel maquette)
        {
            bool result = false;
            using (var context = new CalculContext())
            {
                MaquetteEntity entity = context.Maquettes.Find(maquette.GetNomMaquette());
                context.Maquettes.Remove(entity);
                result = await context.SaveChangesAsync() > 0;

            }
            return result;
        }

        public async Task<IEnumerable<MaquetteModel>> GetAll()
        {
            //using (var context = new CalculContext())
            //{
            //    return await context.Maquettes.Select(e => new MaquetteModel
            //    (e.Id,
            //        e.NomMaquette,
            //        e.Bloc.Select(u =>
            //         u.ue.Select(uee => new UE(uee.Id, uee.Coefficient, uee.intitulé,
            //            uee.mat.Select(ma => new Matiere(ma.id, ma.Note,ma.Nommatiere,ma.Coef)).ToArray()

            //            )).ToList()
            //            ),
            //        e.Bloc.Select(j => new BlocModel(j.Nom)).ToArray()
            //    )).ToListAsync();
            //}
            return null;
        }

        public async Task<MaquetteModel> GetDataWithName(string name)
        {
            //using (var context = new CalculContext())
            //{
            //    return await context.Maquettes.Where(e => e.NomMaquette == name).Select(e => new MaquetteModel
            //    (
            //        // e.Id,
            //        //e.NomMaquette,
            //        //e.Bloc.Select(u => u.ue).ToList(),
            //        //e.Bloc.Select(j => new BlocModel(j.Nom)).ToArray()
            //    )).FirstOrDefaultAsync();
            //}
            return null;
        }

        public async Task<bool> Update(MaquetteModel data)
        {
            bool result = false;
            using (var context = new CalculContext())
            {
                MaquetteEntity entity = context.Maquettes.Find(data.Id);
                entity.NomMaquette = data.GetNomMaquette();
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
