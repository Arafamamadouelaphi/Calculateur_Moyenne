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

        UE u = new UE("f");
        [Fact]
        public void Test()
        {
             Assert.NotNull(u);
            Assert.Equal("f", u.Intitulé);
            Assert.NotEqual("oo", u.Intitulé);
        }
        [Fact]
        public void testInvalid()
        {
            Assert.Throws<ArgumentException>(() => new UE(null));
        }
        [Fact]
        public void Remove()
        {
            stubUE stub = new stubUE();
            UE e = new UE("L1");
            stub.Add(e);
            stub.Delete(e);
            //Compter le nombre de Maq dans un objet IEnumerable
            Assert.Equal(0, stub.GetAll().Result.Count());
        }
        [Fact]
        public void TestUpdate()
        {
            stubUE stub = new stubUE();
            UE e = new UE("L1");
            stub.Add(e);
            e.setIntitulé("L1");
            stub.Update(e);
            Assert.Equal("L1", stub.GetAll().Result.First().GetIntitulé());
        }


    }
}


//public static IEnumerable<object[]> Data_AddMatiereToUE()
//{
//    yield return new object[]
//    {
//        true,
//        new Matiere[]
//        {
//        new Matiere( 1,20,"mat",2),
//        new Matiere(2,3,"histoire",4),
//        new Matiere(4,12,"geo",2)
//        },
//        new UE(1,2,"UE2",
//        new Matiere( 1,20,"mat",2),
//        new Matiere(2,3,"histoire",4)),
//        new Matiere(4,12,"geo",2)

//     };
//    yield return new object[]
//    {
//        false,
//        new Matiere[]
//        {
//        new Matiere( 1,20,"mat",2),
//        new Matiere(2,3,"histoire",4),
//        new Matiere(4,12,"geo",2)
//        },
//        new UE(1,2,"UE2",
//        new Matiere( 1,20,"mat",2),
//        new Matiere(2,3,"histoire",4)),
//         new Matiere(4,12,"geo",2),
//        new Matiere(5,2,"arithmetique",3)
//    };

//[Theory]
// [MemberData(nameof(Data_AddMatiereToUE))]
// public void Test_AddMatiereToUE(bool expectedResult,
//                                   IEnumerable<Matiere> expectedMatiere,
//                                   UE ue,
//                                   Matiere matiere) {

////   true si l'ajout est réussi et false sinon
//     bool result = ue.AjouterMatiere(matiere);

//     // comparaison avec le resultat qu'on espert avoir
//     Assert.Equal(expectedResult, result);

//     // 
//     Assert.Equal(expectedMatiere.Count(), ue.Matieres.Count());
//     Assert.All(expectedMatiere, j => ue.Matieres.Contains(j));


// }












