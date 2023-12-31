﻿using Bussness;
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
    public class MaquetteDbDataManager<TContext> : IMaquetteDbManager where TContext : CalculContext, new()
    {
        public MaquetteDbDataManager()
        {
            using (var context = new TContext())
            {
                context.Database.EnsureCreated();
            }
        }
        public async Task<bool> Add(MaquetteModel mqt)
        { //Add mqt
            bool result = false;
            using (var context = new TContext())
            {
                //context.Database.EnsureCreated();
                MaquetteEntity entity = new MaquetteEntity
                {
                    NomMaquette = mqt.NomMaquette,
                };
                context.Maquettes.Add(entity);
                context.SaveChanges();
                return result;

            }
            
        }
        //ajt de bloc

        public async Task<bool> AddBlocmaquette(MaquetteModel mqt,BlocModel blocModel)
        { 
            bool result = false;
            using (var context = new TContext())
            {
                MaquetteEntity data = await context.Maquettes.FindAsync(mqt.Id);
                if (data != null)
                {
                    BlocEntity entity = new BlocEntity
                    {
                        Id = blocModel.Id,
                        Nom = blocModel.Nom,
                        MaquetteEntity = new MaquetteEntity
                        {
                            Id = mqt.Id,
                            NomMaquette = mqt.NomMaquette
                        },
                    };
                    if (!data.Bloc.Contains(entity))
                    {
                     data.Bloc.Add(entity);
                     context.Maquettes.Update(data);
                     result = await  context.SaveChangesAsync() > 0;
                    }
                }
                
                return result;

            }

        }

        //delete maquette
        public async Task<bool> Delete(MaquetteModel maquette)
        {
            bool result = false;
            using (var context = new TContext())
            {
                MaquetteEntity entity = context.Maquettes.Find(maquette.Id);
                context.Maquettes.Remove(entity);
                result = await context.SaveChangesAsync() > 0;

            }
            return result;
        }


        //delete maquette
        public async Task<bool> DeleteById(MaquetteModel maquette)
        {
            bool result = false;
            using (var context = new TContext())
            {
                MaquetteEntity entity = context.Maquettes.Find(maquette.Id);
                context.Maquettes.Remove(entity);
                result = await context.SaveChangesAsync() > 0;

            }
            return result;
        }

      

        public async Task<MaquetteModel> GetDataWithName(string name)
        {
            
              using (var context = new TContext())
                {
                    MaquetteModel _mqt = null;

                    var query = await context.Maquettes.FirstOrDefaultAsync(n => n.NomMaquette == name);
                    _mqt = new MaquetteModel(query.Id, query.NomMaquette);
                    return _mqt;
                }
        }
            
        public async Task<bool> Update(MaquetteModel data)
        {//update mqt
            bool result = false;
            using (var context = new TContext())
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
        //getAll mqt
        public async Task<List<MaquetteModel>> GetAll()
        {
            using (var context = new TContext())
            {
                List<MaquetteModel> maquettes = new List<MaquetteModel>();
                foreach (var item in context.Maquettes.
                    Include(m => m.Bloc).
                    ThenInclude(x=>x.UeEntityId).
                    ThenInclude(y => y.mat).ToList()) 
                {
                    maquettes.Add(new MaquetteModel

                    (
                     item.Id,
                     item.NomMaquette,
                     MoyenneMaquette(
                         item.Bloc.Select
                          (
                                     m => new BlocModel
                                 (
                                     m.Nom,
                                     m.Id,
                                     m.UeEntityId.Select
                                 (
                                        u =>
                                        new UE

                                         (
                                             u.Id,
                                             u.Coefficient,
                                             u.intitulé,
                                             0,
                                             u.mat.Select
                                             (m => new Matiere
                                                (
                                                 m.Note,
                                                 m.Nommatiere,
                                                 m.Coef
                                                 )
                                             )
                                             .ToArray()
                                  )
                             ).ToArray()

                           )
                         ).ToList()
                        )
                    
                     ));
                }
                return maquettes;
            }
        }


public double MoyenneMaquette(List<BlocModel> blocModels)
        {

            double Moyennetotal = 0;
            double MoyenneMaquette = 0;
            int nbrbloc = 0;

            if (blocModels.Count > 0)
            {

             for(int i = 0; i < blocModels.Count; i++)
             {
                    blocModels[i].MoyenneBloc = BlocDbDataManager<CalculContext>.moyenneBloc(blocModels[i].UEs.ToList());


                    MoyenneMaquette += blocModels[i].MoyenneBloc;
                         

             }

                Moyennetotal = MoyenneMaquette / blocModels.Count;




            }return Moyennetotal;








        } 








       
    }
}
