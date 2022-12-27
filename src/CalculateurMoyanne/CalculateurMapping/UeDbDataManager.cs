using Bussness;
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
    public class UeDbDataManager<TContext> : IUeDbDataManager where TContext:CalculContext,new ()
    {

        public async Task<bool> AddMatiereUe( UE uE,Matiere matiere)
        {
            bool result = false;
            using (var context = new TContext())
            {
                UEentity data = await context.Ue.FindAsync(uE.Id);
                if (data != null)
                {
                    MatiereEntity entity = new MatiereEntity
                    {
                        Id = matiere.Id,
                        Note=matiere.Note,
                        Nommatiere = matiere.Nommatiere,
                        Coef = matiere.Coef,
                        UEentity = new UEentity
                        {
                            Id = uE.Id,
                            intitulé = uE.Intitulé
                        },
                    };
                    if (!data.mat.Contains(entity))
                    {
                        data.mat.Add(entity);
                        context.Ue.Update(data);
                        result = await context.SaveChangesAsync() > 0;
                    }
                }
                return result;
            }

        }





        public async Task<bool> Add(UE data)
        {
            bool resultat = false;
            using (var context = new TContext())
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
            using (var context = new TContext())
            {
                UEentity entity = context.Ue.Find(data.Id);
                context.Ue.Remove(entity);
                result = await context.SaveChangesAsync() > 0;

            }
            return true;
        }
        public async Task<List<UE>> GetAll()
        {
            using (var context = new TContext())
            {
                return await context.Ue.Select(e => new UE
                (
                   e.Id,
                   e.Coefficient,
                   e.intitulé,
                    moyennneUE(e.mat.Select(m => new Matiere(m.Note, m.Nommatiere, m.Coef)).ToList()),
                   e.mat.Select(j => new Matiere(j.Note,j.Nommatiere,j.Coef)).ToArray()
                   
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
            using (var context = new TContext())
            {
                UEentity entity = context.Ue.Find(data.Id);
                entity.intitulé = data.Intitulé;
                entity.mat = data.Matieres.Select(j => new MatiereEntity
                {
                    Nommatiere = j.Nommatiere,
                }).ToList();
                result = await context.SaveChangesAsync() > 0;
            }
            return result;
        }
        
        public async Task<IEnumerable<UE>> GetAllUEBloc(BlocModel bloc)
        {
            List<UE> ls=new List<UE>();
            using (var context = new TContext())
            {
              
                var BLC = await context.Bloc.Include(
                    x => x.UeEntityId).ThenInclude(y => y.mat)
                  .SingleOrDefaultAsync(x => x.Id == bloc.Id);
                    

                if (BLC == null) return new List<UE>();
                foreach (var e in BLC.UeEntityId)
                {
                    ls.Add(new UE
                    {
                        Id = e.Id,
                        Intitulé = e.intitulé,
                        Coefficient=e.Coefficient,
                        IDForeignKey = e.IDForeignKey,
                      MoyenneUe=  moyennneUE(e.mat.Select(m => new Matiere(m.Note, m.Nommatiere, m.Coef)).ToList()),
                //   Matieres =  e.mat.Select(j => new Matiere(j.Note, j.Nommatiere, j.Coef)).ToArray()
                    });
                   
                }
            }
            return ls;
           
        }
        public static double moyennneUE(List<Matiere> matieres )
        {   
            //(note *coef)+()+......./sum coef
            double moyenne = 0;
            int coefs=0;//sum de coef
            double notecoefficiees = 0;//somme des notes *coefs
           
            if (matieres.Count > 0)
            {
                for(int m=0; m< matieres.Count; m++)
                {
                    coefs += matieres[m].Coef;
                    notecoefficiees += matieres[m].Note * matieres[m].Coef;

                }
                moyenne = notecoefficiees / coefs;

            }
            return moyenne;
        }
    }
}
