using ClassCalculateurMoyenne;
using StubCalculateur.Stub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestCalculateurMoyanne.LesTests
{
    public class UnitTestMaquette
    {
        MaquetteModel m = new MaquetteModel("L3");
        [Fact]
        public void Test()
        {
            Assert.NotNull(m);
            Assert.Equal("L3", m.GetNomMaquette());
            Assert.NotEqual("E3", m.GetNomMaquette());
        }
        [Fact]
        public void TestInvalidMaquette()
        {
            Assert.Throws<ArgumentException>(() => new MaquetteModel(null));

        }      
            [Theory]
            [InlineData(false, "L6" ,"L3")]
            [InlineData(false, "",  "")]
            [InlineData(true, "M1", "M1" )]            
            public void TestConstructor(bool isValid, string expectedNomMaquette, 
             string NomMaquette)
            {
                if (!isValid)
                {
                    Assert.Throws<ArgumentException>( () => new MaquetteModel(NomMaquette));
                    return;
                }

                MaquetteModel m = new MaquetteModel(NomMaquette);
                Assert.Equal(expectedNomMaquette, m.GetNomMaquette());
              
            }
            // test avec stub

            [Fact]
            public void TestMaquetteStub()
            {
                StubMaquette stub = new StubMaquette();
                Assert.Equal(10, stub.GetAllMaquette(10).Result.Count());
            }
            [Fact]
            public void TestRemove()
            {
                StubMaquette stub = new StubMaquette();
                MaquetteModel e = new MaquetteModel("L1");
                stub.Add(e);
                stub.Delete(e);
                //Compter le nombre de Maq dans un objet IEnumerable
                Assert.Equal(0, stub.GetAll().Result.Count());
            }
            [Fact]
            public void TestUpdate()
            {
                StubMaquette stub = new StubMaquette();
                MaquetteModel e = new MaquetteModel("E1");
                stub.Add(e);
                e.setNomMaquete("L1");
                stub.Update(e);
                Assert.Equal("L1", stub.GetAll().Result.First().GetNomMaquette());
            }

        }
    }

