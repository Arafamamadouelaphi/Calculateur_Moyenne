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
        public BlocModel SelecteBlocModel { get; set; }
        public UE SelectedUe { get; set; }



        public IDataManager<MaquetteModel> MaquetteDbDataManager => maquetteDbDataManager;
        private readonly IMaquetteDbManager maquetteDbDataManager;
        public IBlocDbManager BlocDbDataManager => blocDbDataManager;
        private readonly IBlocDbManager blocDbDataManager;
        public IUeDbDataManager UeDbDataManager => ueDbDataManager;
        private readonly IUeDbDataManager ueDbDataManager;
        public IMatiereDbManager MatiereDbDataManager => matiereDbDataManager;
        private readonly IMatiereDbManager matiereDbDataManager;
       
     #endregion


     #region Constructeurs

        public Manager(IMaquetteDbManager maquettemanager)
        {
           this.maquetteDbDataManager = maquettemanager;
            maquette = new ReadOnlyCollection<MaquetteModel>(maquettes);
        }

        public Manager( IBlocDbManager  blocmanager)
        {
            this.blocDbDataManager = blocmanager;
              bloc = new ReadOnlyCollection<BlocModel>(blocs);
        }
        public Manager(IUeDbDataManager UeManager)
        {
            this.ueDbDataManager = UeManager;
            ue = new ReadOnlyCollection<UE>(ues);
        }
        public Manager(IMatiereDbManager matiereDbDataManager)
        {
            this.matiereDbDataManager = matiereDbDataManager;
            matiere = new ReadOnlyCollection<Matiere>(matieres);
        }

        public Manager(IMatiereDbManager matiereManager, IUeDbDataManager UeManager, IBlocDbManager blocmanager, IMaquetteDbManager maquettemanager)
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
        public async Task <IEnumerable<BlocModel>> GetByMaquette(MaquetteModel maquetteModel)
        {
            //if (BlocDbDataManager==null)
            //{
            //    return false;  GetAllUEBloc

            //}
            return await blocDbDataManager.GetByMaquette(maquetteModel);
        }
        public async Task<IEnumerable<UE>> GetAllUEBloc(BlocModel bloc)
        {
            
            return await ueDbDataManager.GetAllUEBloc(bloc);
        }
        public async Task<IEnumerable<Matiere>> GetAllMatiereUE(UE ue)
        {

            return await matiereDbDataManager.GetAllMatiereUE(ue);
        }
        public async Task<bool> AddBlocmaquette(MaquetteModel mqt, BlocModel blocModel)
            {
           
            if (maquetteDbDataManager == null)
            {
                return false;
            }

            return await maquetteDbDataManager.AddBlocmaquette(mqt, blocModel);
        }
        public async Task<bool> AddUeBloc(BlocModel bloc, UE uE)
        {

            if (BlocDbDataManager == null)
            {
                return false;
            }

            return await blocDbDataManager.AddUeBloc(bloc, uE);
        }


        public async Task<bool> AddMatiereUe(UE uE, Matiere matiere)
        {

            if (UeDbDataManager == null)
            {
                return false;
            }

            return await ueDbDataManager.AddMatiereUe(uE, matiere);
        }



        public async Task<bool> DeleteBloc(BlocModel bl)
        {
            if (BlocDbDataManager == null)
            {
                return false;
            }
            return await BlocDbDataManager.Delete(bl);
        }
        public async Task<bool> Deletee(Matiere bl)
        {
            if (MatiereDbDataManager == null)
            {
                return false;
            }
            return await MatiereDbDataManager.Delete(bl);
        }

        public async Task<bool> DeleteUe(UE data)
        {
            if (UeDbDataManager == null)
            {
                return false;
            }
            return await UeDbDataManager.Delete(data);
        }

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
        //getAllue
        public async Task<IEnumerable<UE>> GetAllue()
        {
            return await ueDbDataManager.GetAll();
        }
        //getallmatieredansue
        public async Task<IEnumerable<Matiere>> GetAllMatUE()
        {

            return await matiereDbDataManager.GetAll();
        }


        #endregion
    }
}
