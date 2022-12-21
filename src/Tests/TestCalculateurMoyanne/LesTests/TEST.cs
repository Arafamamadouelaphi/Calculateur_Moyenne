using System;
using StubCalculateur.Stub;
using ClassCalculateurMoyenne;
using Bussness;
using Xunit;

namespace TestCalculateurMoyanne.LesTests
{
	public class Test
	{
        Matiere m = new Matiere(2, "ALGO", 3);

        [Fact]
        public void TestONS()
        {
            Assert.NotNull(m);
            Assert.Equal(2, m.Note);
            Assert.Equal("ALGO", m.Nommatiere);
            Assert.Equal(3, m.Coef);
            Assert.NotEqual(21, m.Note);
            Assert.NotEqual("GO", m.Nommatiere);
            Assert.NotEqual(33, m.Coef);
        }
    }

}