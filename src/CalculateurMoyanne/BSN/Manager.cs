﻿using ClassCalculateurMoyenne;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSN
{
    public class Manager
    {
        #region propriétés
        public ReadOnlyCollection<MaquetteModel> maquette { get; private set; }
        private readonly List<MaquetteModel> maquettes = new();
        public ReadOnlyCollection<BlocModel> bloc { get; private set; }
        private readonly List<BlocModel> blocs = new();
        public ReadOnlyCollection<UE> ue { get; private set; }
        private readonly List<UE> ues = new();
        public ReadOnlyCollection<Matiere> matiere { get; private set; }
        private readonly List<Matiere> matieres = new();



        public IDataManager<MaquetteModel> MaquetteDbDataManager => maquetteDbDataManager;
        private readonly IDataManager<MaquetteModel> maquetteDbDataManager;
        public IDataManager<BlocModel> BlocDbDataManager => blocDbDataManager;
        private readonly IDataManager<BlocModel> blocDbDataManager;
        public IDataManager<UE> UeDbDataManager => ueDbDataManager;
        private readonly IDataManager<UE> ueDbDataManager;
       // private IDataManager<Matiere> matiereDbDataManager;

        public IDataManager<Matiere> MatiereDbDataManager => matiereDbDataManager;
       private readonly IDataManager<Matiere> matiereDbDataManager;


        #endregion


        #region Constructeurs

        public Manager(IDataManager<MaquetteModel> maquettemanager)
        {
           this.maquetteDbDataManager = maquettemanager;
            maquette = new ReadOnlyCollection<MaquetteModel>(maquettes);
        }
        public Manager(IDataManager<BlocModel>blocmanager)
        {
            this.blocDbDataManager = blocmanager;
              bloc = new ReadOnlyCollection<BlocModel>(blocs);
        }
        public Manager(IDataManager<UE> UeManager)
        {
            this.ueDbDataManager = UeManager;
            ue = new ReadOnlyCollection<UE>(ues);
        }
        public Manager(IDataManager<Matiere> matiereDbDataManager)
        {
            this.matiereDbDataManager = matiereDbDataManager;
            matiere = new ReadOnlyCollection<Matiere>(matieres);
        }

        public Manager(IDataManager<Matiere> matiereManager,IDataManager<UE> UeManager, IDataManager<BlocModel> blocmanager, IDataManager<MaquetteModel> maquettemanager,)
        {


            this.matiereDbDataManager = matiereManager;
            Matiere = new ReadOnlyCollection<Matiere>(matieres);
        //    this.maquettemanager = maquettemanager;
        //    MaquetteModel = new ReadOnlyCollection<MaquetteModel>(maquettes);
        //    this.partieDataManager = partieDataManager;
        //    Parties = new ReadOnlyCollection<Partie>(parties);
        //    this.joueurDataManager = joueurManager;
        //    Joueurs = new ReadOnlyCollection<Joueur>(joueurs);
        }



        #endregion





        //public Task<bool> AddMaquette(MaquetteModel maqt)
        //{
        //    if (MaquetteDbDataManager == null)
        //    {
        //        return Task.FromResult(false);
        //    }
        //    return MaquetteDbDataManager.Add(maqt);

        //}

        //public async Task<bool> Deletemqt(MaquetteModel maqt)
        //{
        //    if (MaquetteDbDataManager == null)
        //    {
        //        return false;
        //    }
        //    return await MaquetteDbDataManager.Delete(mqt);
        //}


    }
}
