using System;
using ClassCalculateurMoyenne;
namespace Bussness
{
	public interface IBlocDbManager:IDataManager<BlocModel>
	{
		Task<IEnumerable<BlocModel>> GetByMaquette(MaquetteModel maquetteModel);
        Task <bool> AddUeBloc(BlocModel bloc, UE uE);

    }
}

