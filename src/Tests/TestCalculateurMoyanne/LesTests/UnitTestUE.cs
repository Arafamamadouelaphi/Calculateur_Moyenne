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














