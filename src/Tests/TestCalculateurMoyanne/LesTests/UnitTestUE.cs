using ClassCalculateurMoyenne;
using StubCalculateur.Stub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestCalculateurMoyanne.LesTests
{
    public class UnitTestUE
    {


        UE e = new UE("E2");

        private bool isEqual;

        [Fact]

        public void Test()
        {
            Assert.NotNull(e);
            Assert.Equal("E2", e.Intitulé);
            Assert.NotEqual("E3", e.Intitulé);
        }
        [Fact]
        public void TestInvalidUE()
        {

            Assert.Throws<ArgumentException>(() => new UE(null));

        }
      public class Artist_InlineData_UT
        {
            [Theory]
            [InlineData(false, "Mathematique", 2, "MTH", 2)]
            [InlineData(false, "", 0, "", 0)]
            [InlineData(true, "Mathematique", 0, "Mathematique", 0)]


            public void TestConstructor(bool isValid, string expectedMatiere, int expectedcoef,
             string intitulé, int coefficient)
            {
                if (!isValid)
                {
                    Assert.Throws<ArgumentException>(
                        () => new UE(intitulé, coefficient));
                    return;
                }

                UE e = new UE(intitulé, coefficient);
                Assert.Equal(expectedMatiere,e.Intitulé);
                Assert.Equal(expectedcoef, e.Coefficient);
            }

           // test avec stub

            [Fact]
            public void TestUeStub()
            {
                stubUE stub = new stubUE();
                Assert.Equal(10, stub.GetAllUE(10).Result.Count());
            }
            [Fact]
            public void TestRemove()
            {
                stubUE stub = new stubUE();
                UE e = new UE("E1");
                stub.Add(e);
                stub.Delete(e);
                //Compter le nombre de UE dans un objet IEnumerable
                Assert.Equal(0, stub.GetAll().Result.Count());
            }
            public void TestUpdate()
            {
                stubUE stub = new stubUE();
                UE e = new UE("E1");
                stub.Add(e);
                e.setIntitulé("UE1");
                stub.Update(e);
                Assert.Equal("UE1", stub.GetAll().Result.First().Intitulé);
            }

        }

    }
}
    