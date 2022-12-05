using ClassCalculateurMoyenne;
using StubCalculateur.Stub;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestCalculateurMoyanne.LesTests
{
    public class UnitTestUE
    {

        public static IEnumerable<object[]> Data_AddMatiereToUE()
        {
            yield return new object[]
            {
                true,
                new Matiere[]
                {
                new Matiere( 1,20,"mat",2),
                new Matiere(2,3,"histoire",4),
                new Matiere(4,12,"geo",2)
                },
                new UE(1,2,"UE2",
                new Matiere( 1,20,"mat",2),
                new Matiere(2,3,"histoire",4)),
                new Matiere(4,12,"geo",2)

             };
            yield return new object[]
            {
                false,
                new Matiere[]
                {
                new Matiere( 1,20,"mat",2),
                new Matiere(2,3,"histoire",4),
                new Matiere(4,12,"geo",2)
                },
                new UE(1,2,"UE2",
                new Matiere( 1,20,"mat",2),
                new Matiere(2,3,"histoire",4)),
                 new Matiere(4,12,"geo",2),
                new Matiere(5,2,"arithmetique",3)
            };
        }
        [Theory]
        [MemberData(nameof(Data_AddMatiereToUE))]
        public void Test_AddMatiereToUE(bool expectedResult,
                                          IEnumerable<Matiere> expectedMatiere,
                                          UE ue,
                                          Matiere matiere) {

       //   true si l'ajout est réussi et false sinon
            bool result = ue.AjouterMatiere(matiere);

            // comparaison avec le resultat qu'on espert avoir
            Assert.Equal(expectedResult, result);

            // 
            Assert.Equal(expectedMatiere.Count(), ue.Matieres.Count());
            Assert.All(expectedMatiere, j => ue.Matieres.Contains(j));


        }

    }

                
                
              

}

           
                //true,
                //new Artist[]
                //{
                //    new Artist("Miles", "Davis"),
                //    new Artist("Wayne", "Shorter"),
                //    new Artist("Herbie", "Hancock"),
                //    new Artist("Ron", "Carter"),
                //    new Artist("Tony", "Williams")
                //},
                //new Album("Miles Smiles", new DateTime(1967, 1, 1),
                //    new Artist("Miles", "Davis"),
                //    new Artist("Wayne", "Shorter"),
                //    new Artist("Herbie", "Hancock"),
                //    new Artist("Ron", "Carter")),
                //new Artist("Tony", "Williams")
           







        //{
        //    [Theory]
        //    [InlineData(false, "Mathematique", 2, "MTH", 2)]
        //    [InlineData(false, "", 0, "", 0)]
        //    [InlineData(true, "Mathematique", 0, "Mathematique", 0)]


        //    public void TestConstructor(bool isValid, string expectedMatiere, int expectedcoef,
        //     string intitulé, int coefficient)
        //    {
        //        if (!isValid)
        //        {
        //            Assert.Throws<ArgumentException>(
        //                () => new UE(intitulé, coefficient));
        //            return;
        //        }

        //        UE e = new UE(intitulé, coefficient);
        //        Assert.Equal(expectedMatiere,e.Intitulé);
        //        Assert.Equal(expectedcoef, e.Coefficient);
        //    }

        //   // test avec stub

        //    [Fact]
        //    public void TestUeStub()
        //    {
        //        stubUE stub = new stubUE();
        //        Assert.Equal(10, stub.GetAllUE(10).Result.Count());
        //    }
        //    [Fact]
        //    public void TestRemove()
        //    {
        //        stubUE stub = new stubUE();
        //        UE e = new UE("E1");
        //        stub.Add(e);
        //        stub.Delete(e);
        //        //Compter le nombre de UE dans un objet IEnumerable
        //        Assert.Equal(0, stub.GetAll().Result.Count());
        //    }
        //    public void TestUpdate()
        //    {
        //        stubUE stub = new stubUE();
        //        UE e = new UE("E1");
        //        stub.Add(e);
        //        e.setIntitulé("UE1");
        //        stub.Update(e);
        //        Assert.Equal("UE1", stub.GetAll().Result.First().Intitulé);
        //    }

        //}

   