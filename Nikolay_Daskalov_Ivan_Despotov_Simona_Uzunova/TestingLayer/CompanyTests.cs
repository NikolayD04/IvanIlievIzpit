using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;
using ServiceLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingLayer
{
    [TestClass]
    public class CompanyTests
    {
        CompanyContext ctx = DBContextManager.GetCompanyContext();
        Company COMPANY;
        
        [TestInitialize]
        public void Setup()
        {
            try
            {
                ctx.Delete("customid");
                //tries to delete the test user if tests have been ran before
            }
            catch (Exception e) { }
            Company customitem = new Company("customid", "Ubisoft", "Sofia");
            ctx.Create(customitem);
            COMPANY = customitem;
        }
        [TestCleanup]
        public void Cleanup()
        {
            ctx.Delete("customid");
            ctx.Create(COMPANY);
        }
        [TestMethod]
        public void CreateTest()
        {
            Assert.IsNotNull(ctx.Read("customid"));
        }
        [TestMethod]
        public void ReadTest()
        {
            Assert.AreEqual("Ubisoft", ctx.Read("customid").Name);
        }
        [TestMethod]
        public void ReadAllTest()
        {
            Assert.IsNotNull(ctx.ReadAll());
        }
        [TestMethod]
        public void UpdateTest()
        {
            Company newcompany = new Company("customid", "Riot Games", "London");
            ctx.Update(newcompany);
            Assert.AreEqual("Riot Games", ctx.Read("customid").Name);
        }
        [TestMethod]
        public void DeleteTest()
        {
            ctx.Delete("customid");
            Assert.IsNull(ctx.Read("customid"));
            ctx.Create(COMPANY);
        }

    }
}
