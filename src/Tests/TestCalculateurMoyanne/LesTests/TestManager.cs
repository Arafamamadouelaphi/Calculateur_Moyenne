using System;
using StubCalculateur.Stub;
using ClassCalculateurMoyenne;
using Bussness;
using Xunit;



namespace TestCalculateurMoyanne.LesTests
{
	public class TestManager
	{
        [Fact]
        public void TestAddMaquette()
		{
			MaquetteModel maquette = new MaquetteModel("B1");
			Manager manager = new Manager(new StubMaquette());
			manager.AddMaquette(maquette);
			Assert.Single(manager.MaquetteDbDataManager.GetAll().Result);			
		}
        [Fact]
        public void TestAddBloc()
        {
            BlocModel bloc = new BlocModel("B1");
            Manager manager = new Manager(new StubBloc());
            manager.AddBloc (bloc);
            Assert.Single(manager.BlocDbDataManager.GetAll().Result);
        }
        [Fact]
        public void TestGetUEBloc()
        {
            BlocModel bloc = new BlocModel("B1");
            Manager manager = new Manager(new StubBloc());
            manager.AddBloc(bloc);

        }
        [Fact]
        public void TestDELETEBloc()
        {
            BlocModel bloc = new BlocModel("B1");
            Manager manager = new Manager(new StubBloc());
            manager.DeleteBloc(bloc);

        }
        public void TestUpdateBloc()
        {
            BlocModel bloc = new BlocModel("B1");
            Manager manager = new Manager(new StubBloc());
            manager.UpdateBloc( bloc);

        }
        [Fact]
        public void TestGetAllTEBloc()
        {
            BlocModel bloc = new BlocModel("B1");
            Manager manager = new Manager(new StubBloc());
            manager.GetAllBloc();

        }


    }
}

