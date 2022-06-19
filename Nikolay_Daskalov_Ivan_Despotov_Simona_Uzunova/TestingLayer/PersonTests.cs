using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using DataLayer;
using ServiceLayer;
using System;

namespace TestingLayer
{
    [TestClass]
    public class PersonTests
    {
        PersonContext ctx = DBContextManager.GetPersonContext();
        Person PERSON;
        
        [TestInitialize]
        public void Setup()
        {
            try
            {
                ctx.Delete("customid");
                //tries to delete the test user if tests have been ran before
            }
            catch (Exception e) { }
            Person customitem = new Person("customid", "Ivan", "Ivanov");
            ctx.Create(customitem);
            PERSON = customitem;
        }
        [TestCleanup]
        public void Cleanup()
        {
            ctx.Delete("customid");
            ctx.Create(PERSON);
        }
        [TestMethod]
        public void CreateTest()
        {
            Assert.IsNotNull(ctx.Read("customid"));
        }
        [TestMethod]
        public void ReadTest()
        {
            Assert.AreEqual("Ivan", ctx.Read("customid").FName);
        }
        [TestMethod]
        public void ReadAllTest()
        {
            Assert.IsNotNull(ctx.ReadAll());
        }
        [TestMethod]
        public void UpdateTest()
        {
            Person newperson = new Person("customid", "Georgi", "Georgiev");
            ctx.Update(newperson);
            Assert.AreEqual("Georgi", ctx.Read("customid").FName);
        }
        [TestMethod]
        public void DeleteTest()
        {
            ctx.Delete("customid");
            Assert.IsNull(ctx.Read("customid"));
            ctx.Create(PERSON);
        }

    }
}