using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class GameContext : IDB<Game, string>
    {
        private Izpit3Context ctx;

        public GameContext()
        {
            ctx = new Izpit3Context();
        }
        public void Create(Game item)
        {
            try
            {
                ctx.Games.Add(item);
                ctx.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public Game Read(string key)
        {
            try
            {
                 return ctx.Games.Find(key);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<Game> ReadAll()
        {
            try
            {
                return ctx.Games.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public void Update(Game item)
        {
            try
            {
                Game oldgame = Read(item.ID);
                ctx.Entry(oldgame).CurrentValues.SetValues(item);
                ctx.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public void Delete(string key)
        {
            try
            {
                Game game = Read(key);
                ctx.Games.Remove(game);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        
    }
}
