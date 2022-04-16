using FM.DAL.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace FM.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("FinancialManager")
        {

        }

        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<Cost> Costs { get; set; }
        public virtual DbSet<IncomeSource> IncomeSources { get; set; }
        public virtual DbSet<CostType> CostTypes { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Balance> Balances { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Balance
            EntityTypeConfiguration<Balance> balanceBuilder = modelBuilder.Entity<Balance>();
            balanceBuilder.HasKey(b => b.Id);
            balanceBuilder.Property(b => b.Money).IsRequired();

            balanceBuilder.HasRequired(b => b.Currency).WithMany(c => c.Balances).HasForeignKey(b => b.CurrencyId);
            balanceBuilder.HasRequired(b => b.User).WithMany(u => u.Balances).HasForeignKey(b => b.UserId);

            // Currency
            EntityTypeConfiguration<Currency> currencyBuilder = modelBuilder.Entity<Currency>();
            currencyBuilder.HasKey(c => c.Id);
            currencyBuilder.Property(c => c.Name).IsRequired();
            currencyBuilder.Property(c => c.Char).IsRequired().HasMaxLength(1).IsFixedLength();

            // User
            EntityTypeConfiguration<User> userBuilder = modelBuilder.Entity<User>();
            userBuilder.HasKey(u => u.Id);
            userBuilder.Property(u => u.Name).IsRequired();
            userBuilder.Property(u => u.Surname).IsRequired();

            // IncomeSource
            EntityTypeConfiguration<IncomeSource> incomeSourceBuilder = modelBuilder.Entity<IncomeSource>();
            incomeSourceBuilder.HasKey(i => i.Id);
            incomeSourceBuilder.Property(i => i.Name).IsRequired();

            // CostType
            EntityTypeConfiguration<CostType> costTypeBuilder = modelBuilder.Entity<CostType>();
            costTypeBuilder.HasKey(c => c.Id);
            costTypeBuilder.Property(c => c.Name).IsRequired();

            // Income
            EntityTypeConfiguration<Income> incomeBuilder = modelBuilder.Entity<Income>();
            incomeBuilder.HasKey(i => i.Id);
            incomeBuilder.Property(i => i.Money).IsRequired();
            incomeBuilder.Property(i => i.Date).IsRequired();

            incomeBuilder.HasRequired(i => i.IncomeSource).WithMany(i => i.Incomes).HasForeignKey(i => i.IncomeSourceId);
            incomeBuilder.HasRequired(i => i.Balance).WithMany(b => b.Incomes).HasForeignKey(i => i.BalanceId);

            // Cost
            EntityTypeConfiguration<Cost> costBuilder = modelBuilder.Entity<Cost>();
            costBuilder.HasKey(c => c.Id);
            costBuilder.Property(c => c.Money).IsRequired();
            costBuilder.Property(c => c.Date).IsRequired();

            costBuilder.HasRequired(i => i.CostType).WithMany(i => i.Costs).HasForeignKey(i => i.CostTypeId);
            costBuilder.HasRequired(i => i.Balance).WithMany(b => b.Costs).HasForeignKey(i => i.BalanceId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
