using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Virtual.EntityModels;

namespace CodeFirst
{
    public class GenericFireSale : DbContext
    {
        public GenericFireSale()
            : base("name=Authorize")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }
        public GenericFireSale(bool disableProxy = true)
            : base("name=Authorize")
        {
            if (disableProxy)
            {
                this.Configuration.ProxyCreationEnabled = false;
                this.Configuration.LazyLoadingEnabled = false;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Configurations.Add(new EntityTypeConfiguration<Cities>());
            //modelBuilder.Configurations.Add(new EntityTypeConfiguration<CityMapper>());
            //modelBuilder.Configurations.Add(new EntityTypeConfiguration<Countries>());
            //modelBuilder.Configurations.Add(new EntityTypeConfiguration<CountryMappers>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<OPUs>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<Fields>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<Platforms>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<Tags>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<SubUnits>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<MaintainableUnits>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<FailureModes>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<FailureEvents>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<EquipmentClass>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<AppUsers>());
        }
    }
}