using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class PersonContext : IDB<Person, string>
    {
        private Izpit3Context ctx;

        public PersonContext()
        {
            ctx = new Izpit3Context();
        }
        public void Create(Person item)
        {
            try
            {
                ctx.People.Add(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Person Read(string key)
        {
            try
            {
                return ctx.People.Find(key);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<Person> ReadAll()
        {
            try
            {
                return ctx.People.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Update(Person item)
        {
            try
            {
                Person old = Read(item.ID);
                ctx.Entry(old).CurrentValues.SetValues(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Delete(string key)
        {
            try
            {
                Person item = Read(key);
                ctx.People.Remove(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
