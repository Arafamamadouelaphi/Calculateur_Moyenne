﻿using ClassCalculateurMoyenne;
using StubCalculateur.Stub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestCalculateurMoyanne.LesTests
{
    public class UnitTestBloc
    {
        BlocModel b = new BlocModel("B3");
        [Fact]
        public void Test()
        {
            Assert.NotNull(b);
            Assert.Equal("B3", b.Nom);
            Assert.NotEqual("E3", b.Nom);
        }
        [Fact]
        public void TestInvalidBloc()
        {
            string nom=null;
            Assert.Throws<ArgumentException>(() => new BlocModel(nom));
        }


        [Fact]
        public void TestBlocStub()
        {
            StubBloc stub = new StubBloc();
            Assert.Equal(10, stub.GetAllBloc(10).Result.Count());
        }
        [Fact]
        public void TestRemove()
        {
            StubBloc stub = new StubBloc();
            BlocModel e = new BlocModel("L1");
            stub.Add(e);
            stub.Delete(e);
            //Compter le nombre de Maq dans un objet IEnumerable
            Assert.Equal(0, stub.GetAll().Result.Count());
        }
        [Fact]
        public void TestUpdate()
        {
            StubBloc stub = new StubBloc();
            BlocModel e = new BlocModel("E1");
            stub.Add(e);
            e.setNom("L1");
            stub.Update(e);
            Assert.Equal("L1", stub.GetAll().Result.First().GetNom());
        }



    }




    }
