using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domains;
using Web.ViewModels;

namespace Web.Datas
{
    public class RepositoryDatabase : DbContext
    {
        public RepositoryDatabase(DbContextOptions<RepositoryDatabase> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<EnterpriseEntity> EnterpriseEntities { get; set; }
        public DbSet<Web.ViewModels.EnterpriseCreateViewModel> EnterpriseCreateViewModel { get; set; }
    }
}
