using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using UnitOfWork.Models.Mapping;

namespace UnitOfWork.Models
{
    public partial class TestDBContext : DbContext
    {
        static TestDBContext()
        {
            Database.SetInitializer<TestDBContext>(null);
        }

        public TestDBContext()
            : base("Name=TestDBContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
