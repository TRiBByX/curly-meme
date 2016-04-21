namespace Win10WebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GuestViewDBContext : DbContext
    {
        public GuestViewDBContext()
            : base("name=GuestViewDBContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Guest_View> Guest_View { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest_View>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
