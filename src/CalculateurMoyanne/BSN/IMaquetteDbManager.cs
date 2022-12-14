using System;
using ClassCalculateurMoyenne;

namespace Bussness
{
	public interface IMaquetteDbManager : IDataManager<MaquetteModel>
	{
        Task<bool> AddBlocmaquette(MaquetteModel mqt, BlocModel blocModel);
    }
}

