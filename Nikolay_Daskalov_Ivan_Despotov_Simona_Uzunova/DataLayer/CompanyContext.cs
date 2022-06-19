using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class CompanyContext : IDB<Company, string>
    {
        private Izpit3Context ctx;

        public CompanyContext()
        {
            ctx = new Izpit3Context();
        }
        public void Create(Company item)
        {
            try
            {
                ctx.Companies.Add(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Company Read(string key)
        {
            try
            {
                return ctx.Companies.Find(key);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<Company> ReadAll()
        {
            try
            {
                return ctx.Companies.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Update(Company item)
        {
            try
            {
                Company old = Read(item.ID);
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
                Company item = Read(key);
                ctx.Companies.Remove(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
