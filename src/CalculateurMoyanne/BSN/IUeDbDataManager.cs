using System;
using ClassCalculateurMoyenne;

namespace Bussness
{
	public interface IUeDbDataManager:IDataManager<UE>
	{
        Task<IEnumerable<UE>> GetAllUEBloc(BlocModel bloc);
        Task<bool> AddMatiereUe(UE uE, Matiere matiere);
    }
}

