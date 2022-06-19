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
    public class GameTests
    {
        GameContext ctx = DBContextManager.GetGameContext();
        Game GAME;

        [TestInitialize]
        public void Setup()
        {
            try
            {
                ctx.Delete("customid");
                //tries to delete the test user if tests have been ran before
            }
            catch (Exception e) { }
            Game customitem = new Game("customid", "Minecraft", (decimal)19.99, "01.01.2010");
            ctx.Create(customitem);
            GAME = customitem;
        }
        [TestCleanup]
        public void Cleanup()
        {
            ctx.Delete("customid");
            ctx.Create(GAME);
        }
        [TestMethod]
        public void CreateTest()
        {
            Assert.IsNotNull(ctx.Read("customid"));
        }
        [TestMethod]
        public void ReadTest()
        {
            Assert.AreEqual("Minecraft", ctx.Read("customid").Name);
        }
        [TestMethod]
        public void ReadAllTest()
        {
            Assert.IsNotNull(ctx.ReadAll());
        }
        [TestMethod]
        public void UpdateTest()
        {
            Game newgame = new Game("customid", "League of Legends", (decimal)0.00, "01.01.2009");
            ctx.Update(newgame);
            Assert.AreEqual("League of Legends", ctx.Read("customid").Name);
        }
        [TestMethod]
        public void DeleteTest()
        {
            ctx.Delete("customid");
            Assert.IsNull(ctx.Read("customid"));
            ctx.Create(GAME);
        }

    }
}
