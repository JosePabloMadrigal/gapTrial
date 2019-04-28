using InsuranceExamGAP_ORM.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceExamGAP_ORM
{
    public class InsuranceContext : DbContext
    {

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<PolicyType> PolicyTypes { get; set; }
        public virtual DbSet<RiskType> RiskTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ClientPolicy> ClientPolicies { get; set; }

        public InsuranceContext(DbContextOptions<InsuranceContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId).IsRequired();
            });

            

            #region ClientSeed
            modelBuilder.Entity<Client>().HasData(new Client { ClientId = 1, FullName = "Jose Madrigal" });
            modelBuilder.Entity<Client>().HasData(new Client { ClientId = 2, FullName = "Gerardo Madrigal" });
            modelBuilder.Entity<Client>().HasData(new Client { ClientId = 3, FullName = "Laura Marin" });
            modelBuilder.Entity<Client>().HasData(new Client { ClientId = 4, FullName = "Cotton Candy" });
            #endregion
            #region PolicyTypeSeed
            modelBuilder.Entity<PolicyType>().HasData(new PolicyType { PolicyTypeId = 1, Name = "Incendio", PolicyCover = 0.7});
            modelBuilder.Entity<PolicyType>().HasData(new PolicyType { PolicyTypeId = 2, Name = "Terremoto", PolicyCover = 0.7 });
            modelBuilder.Entity<PolicyType>().HasData(new PolicyType { PolicyTypeId = 3, Name = "Robo", PolicyCover = 0.4 });
            modelBuilder.Entity<PolicyType>().HasData(new PolicyType { PolicyTypeId = 4, Name = "Perdida", PolicyCover = 0.3 });
            #endregion
            #region RiskTypes
            modelBuilder.Entity<RiskType>().HasData(new RiskType { RiskTypeId = 1, Name = "Bajo"});
            modelBuilder.Entity<RiskType>().HasData(new RiskType { RiskTypeId = 2, Name = "Medio" });
            modelBuilder.Entity<RiskType>().HasData(new RiskType { RiskTypeId = 3, Name = "Medio-Alto" });
            modelBuilder.Entity<RiskType>().HasData(new RiskType { RiskTypeId = 4, Name = "Alto" });
            #endregion
        }

    }
}