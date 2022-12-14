using ClassCalculateurMoyenne;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussness
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

        public MaquetteModel SelectedMaquetteModel { get; set; }



        public IDataManager<MaquetteModel> MaquetteDbDataManager => maquetteDbDataManager;
        private readonly IMaquetteDbManager maquetteDbDataManager;
        public IDataManager<BlocModel> BlocDbDataManager => blocDbDataManager;
        private readonly IDataManager<BlocModel> blocDbDataManager;
        public IDataManager<UE> UeDbDataManager => ueDbDataManager;
        private readonly IDataManager<UE> ueDbDataManager;
        public IDataManager<Matiere> MatiereDbDataManager => matiereDbDataManager;
        private readonly IDataManager<Matiere> matiereDbDataManager;
       
     #endregion


     #region Constructeurs

        public Manager(IMaquetteDbManager maquettemanager)
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

        public Manager(IDataManager<Matiere> matiereManager,IDataManager<UE> UeManager, IDataManager<BlocModel> blocmanager, IMaquetteDbManager maquettemanager)
        {
        this.matiereDbDataManager = matiereManager;
        matiere = new ReadOnlyCollection<Matiere>(matieres);
        this.maquetteDbDataManager = maquettemanager;
        maquette = new ReadOnlyCollection<MaquetteModel>(maquettes);
        this.blocDbDataManager = blocmanager;
        bloc = new ReadOnlyCollection<BlocModel>(blocs);
        this.ueDbDataManager = UeManager;
        ue = new ReadOnlyCollection<UE>(ues);
        }

     #endregion

     #region Methodes
        //Add Maquette
    
       public Task<bool> AddMaquette(MaquetteModel maqt)
       {
        if (maquetteDbDataManager == null)
        {
               return Task.FromResult(false);
        }
         
           return maquetteDbDataManager.Add(maqt);
       }

        //Delete Maquette
        public async Task<bool> Deletemqt(MaquetteModel maqt)
        {
          if (maquetteDbDataManager == null)
          {
               return false;
          }
            return await maquetteDbDataManager.Delete(maqt);
        }
        //Update Maquette
        public async Task<bool> UpdateMaquette(MaquetteModel maqt)
        {
            if (maquetteDbDataManager == null)
            {
                return false;
            }
            return await maquetteDbDataManager.Update(maqt);
        }
        //  GEt all Maquette
        public async Task<List<MaquetteModel>> GetAllMaquette()
        {
            return await maquetteDbDataManager.GetAll();
        }
        // Get maquetteByName
       public MaquetteModel  GetMaquetteByName(string maquetteName)
        {
             return maquetteDbDataManager.GetDataWithName(maquetteName).Result;

        }
        // add bloc
        public Task<bool> AddBloc(BlocModel bloc)
        {
            var response = blocDbDataManager == null;
            if (response)
            {
                return Task.FromResult(false);
            }

            return blocDbDataManager.Add(bloc);
        }
        public async Task<bool> AddBlocmaquette(MaquetteModel mqt, BlocModel blocModel)
        {
            var response = maquetteDbDataManager == null;
            if (response)
            {
                return false;
            }

            return await maquetteDbDataManager.AddBlocmaquette(mqt, blocModel);
        }

        //public Task<bool> Adddansbloc(BlocModel bloc)
        //{
        //    if (blocDbDataManager == null)
        //    {
        //        return Task.FromResult(false);
        //    }

        //    return blocDbDataManager.Add(bloc);
        //}

        //Delete bloc 
        public async Task<bool> DeleteBloc(BlocModel bl)
        {
            if (BlocDbDataManager == null)
            {
                return false;
            }
            return await BlocDbDataManager.Delete(bl);
        }
        //public async Task<bool> DeleteBlocById(int id)
        //{
              
        //}

        //Update bloc
        public async Task<bool> UpdateBloc(BlocModel bl)
        {
            if (BlocDbDataManager == null)
            {
                return false;
            }
            return await BlocDbDataManager.Update(bl);
        }
        //GetAllbloc
        public async Task<IEnumerable<BlocModel>> GetAllBloc()
        {
            return await BlocDbDataManager.GetAll();
        }
        #endregion
    }
}
