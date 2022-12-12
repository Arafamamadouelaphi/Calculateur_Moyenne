// See https://aka.ms/new-console-template for more information
using CalculateurEF.Context;
using CalculateurEF.Entities;
using Bussness;
using CalculateurMapping;
using ClassCalculateurMoyenne;

public class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
      Manager blocDbDataManager = new Manager(new BlocDbDataManager<CalculContext>());
        // Manager maquetteDbDataManager = new Manager(new MaquetteDbDataManager());


        //Ajout de maquette
        //MaquetteModel maquette = new MaquetteModel();
        //maquette.NomMaquette = "M1";
        //await maquetteDbDataManager.AddMaquette(maquette);

        //AJOUT DE BLOC
        //BlocModel bloc = new BlocModel();
        //bloc.Nom = "Arafa";
        //bloc.IDMaquetteFrk = 1;
        //await blocDbDataManager.AddBloc(bloc);



        //Modification 
        BlocModel bloc = new BlocModel();
        var result = await blocDbDataManager.GetAllBloc();
        result.First().Nom = "Elaphi";
      
        await blocDbDataManager.UpdateBloc(result.First());


        //suppresion de bloc
        //BlocDbDataManager blocDbDataManager = new BlocDbDataManager();
        //  BlocModel bloc = new BlocModel();
        //  var result = await blocDbDataManager.GetAllBloc();
        // await blocDbDataManager.DeleteById(1);

        //ajout de ue dans bloc
        //BlocDbDataManager blocDbDataManager1 = new BlocDbDataManager();
        //BlocModel bloc = new BlocModel();


        //UE uE = new UE();
        //uE.Intitulé = "f";
        //uE.IDForeignKey = 1;
        //await blocDbDataManager.AddUEBloc(bloc);


    }
}