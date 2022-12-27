using Bussness;
using CalculateurEF.Context;
using CalculateurEF.Entities;
using ClassCalculateurMoyenne;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CalculateurMapping
{
    public class BlocDbDataManager<TContext>: IBlocDbManager  where TContext :CalculContext,new()
    {//ajout de bloc 
        public async Task<bool> Add(BlocModel blc)
        {
            bool resultat = false;
            using (var context = new TContext())
            {
                BlocEntity entity = new BlocEntity
                {
                    Nom = blc.GetNom(),
                   // IDMaquetteFrk=blc.IDMaquetteFrk
                };              
                    context.Bloc.Add(entity);

                try { await context.SaveChangesAsync(); }
                catch (Exception e) { Debug.WriteLine("ex"); }
                    //context.SaveChanges();
                    resultat = true;
            }
            return resultat;
        }//delete

        public async Task<bool> Delete(BlocModel bloc)
        {
            bool result = false;
            using (var context = new TContext())
            {
                BlocEntity entity = context.Bloc.Find(bloc.Id);
                context.Bloc.Remove(entity);
                result = await context.SaveChangesAsync() > 0;
            }
            return true;
        }

        public async Task<bool> DeleteById(int  id)
        {
            bool result = false;
            using (var context = new TContext())
            {
                BlocEntity entity = context.Bloc.Find(id);
                context.Bloc.Remove(entity);
                result = await context.SaveChangesAsync() > 0;
            }
            return true;
        }
        public async Task<IEnumerable<BlocModel>>GetByMaquette(MaquetteModel maquetteModel) {

            List<BlocModel> blocModels = new List<BlocModel>();
            using (var context = new TContext())
            {
                var maq = await context.Maquettes.Include(m => m.Bloc).ThenInclude(
                   x => x.UeEntityId).ThenInclude(y => y.mat)
                  .SingleOrDefaultAsync(x => x.Id == maquetteModel.Id);
      
                if (maq == null) return new List<BlocModel>();

                foreach (var e in maq.Bloc)
                {
                    blocModels.Add(new BlocModel
                    {
                        Id = e.Id,
                        Nom = e.Nom,
                        IDMaquetteFrk = e.IDMaquetteFrk,
                        MoyenneBloc = moyenneBloc(e.UeEntityId.Select(
                          u => new UE(u.Id, u.Coefficient, u.intitulé, 0, u.mat.Select(m => new Matiere(m.Note, m.Nommatiere, m.Coef)).ToArray())
                    ).ToList())
                    });
                }
                return blocModels.AsEnumerable<BlocModel>();
            }
           
        }
        

        public static double moyenneBloc(List<UE> ues)
        {
            double moyennebolcs = 0;
            int Coefs = 0;
            double moyennecoefficier=0;
            if (ues.Count > 0)
            {
                for(int u = 0; u < ues.Count; u++)
                {
                    ues[u].MoyenneUe = UeDbDataManager<CalculContext>.moyennneUE(ues[u].Matieres.ToList());
                    Coefs += ues[u].Coefficient;
                    moyennecoefficier += ues[u].MoyenneUe * ues[u].Coefficient;
                }

                moyennebolcs = moyennecoefficier / Coefs;

            }
            return moyennebolcs;
        }
          

        public async Task<List<BlocModel>> GetAll()
        { //getAll
            using (var context = new TContext())
            {
                var temp= await  context.Bloc.Select(e => new BlocModel
                (
                   e.Nom,
                   e.Id, new UE[0]
                  //e.ue.Select(j => new UE(j.intitulé)).ToArray()
                )).ToListAsync();
                return temp;
            }
        }

        public async Task<BlocModel> GetDataWithName(string name)
        {
            using (var context = new TContext())
            {
                return await context.Bloc.Where(e => e.Nom == name).Select(e => new BlocModel
                (   
                    e.Nom,            
                    e.UeEntityId.Select(j => new UE(j.intitulé)).ToArray()
                )).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> Update(BlocModel data)
        {//update
            bool result = false;
            using (var context = new TContext())
            {
                BlocEntity entity = context.Bloc.Find(data.Id);
                entity.Nom = data.Nom ;
                entity.UeEntityId = data.ue.Select(j => new UEentity
                {
                    intitulé = j.Intitulé,
                }).ToList();
                bool v = await context.SaveChangesAsync() > 0;
                result = v;
            }
            return result;
        }

       
        public async Task<bool> AddUeBloc(BlocModel bloc, UE uE)
        {
            bool result = false;
            using (var context = new TContext())
            {
                BlocEntity data = await context.Bloc.FindAsync(bloc.Id);
                if (data != null)
                {
                    UEentity entity = new UEentity
                    {
                        Id=uE.Id,
                        intitulé = uE.Intitulé,
                        Coefficient=uE.Coefficient,
                        BlocEntity = new BlocEntity
                        {
                            Id = bloc.Id,
                            Nom = bloc.Nom
                        },
                    };
                    if (!data.UeEntityId.Contains(entity))
                    {
                        data.UeEntityId.Add(entity);
                        context.Bloc.Update(data);
                        result = await context.SaveChangesAsync() > 0;
                    }
                }
                return result;
            }

        }

       
    }
}
