using Bussness;
using CalculateurEF.Context;
using CalculateurEF.Entities;
using ClassCalculateurMoyenne;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateurMapping
{
    public class BlocDbDataManager<TContext>: IDataManager<BlocModel> where TContext :CalculContext,new()
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
        public async Task<bool>GetByMaquette(MaquetteModel maquette) {

           
            using (var context = new TContext())
            {
                // 
            }
            return true;
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
        }//getUEdansblc
        public async Task<List<UE>> GetAllUEBloc(int id)
        {
            List<UE> ls=new List<UE>();
            using (var context = new TContext())
            {
                var temp =  context.Bloc.Where(x=>x.Id==id).Select(e => e.UeEntityId).ToList();
                foreach (var item in temp)
                {
                    foreach (var i in item)
                    {
                        UE ue = new UE(i.Id, i.Coefficient, i.intitulé, i.mat.Select(m => new Matiere(m.id, m.Note, m.Nommatiere, m.Coef)).ToArray());
                        ls.Add(ue);
                    }
                }

                return ls;
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

        public async Task<bool> AddUEBloc(UE data,int blocId)
        {//addUedansbloc
            bool resultat = false;
            using (var context = new TContext())
            {
                UEentity entity = new UEentity
                {
                    intitulé = data.Intitulé,
                    IDForeignKey = blocId,
                };
                context.Ue.Add(entity);
                await context.SaveChangesAsync();
                resultat = true;
                return resultat;
            }
        }
    }
}
