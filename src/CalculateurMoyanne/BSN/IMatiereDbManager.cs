using System;
using ClassCalculateurMoyenne;
namespace Bussness
{
	public interface IMatiereDbManager : IDataManager<Matiere>
    {
        Task<IEnumerable<Matiere>> GetAllMatiereUE(UE ue);
    }
}

