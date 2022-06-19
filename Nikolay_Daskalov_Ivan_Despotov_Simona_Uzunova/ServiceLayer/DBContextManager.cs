using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public static class DBContextManager
    {
        public static GameContext GetGameContext() => new GameContext();
        public static PersonContext GetPersonContext() => new PersonContext();
        public static CompanyContext GetCompanyContext() => new CompanyContext();

    }
}