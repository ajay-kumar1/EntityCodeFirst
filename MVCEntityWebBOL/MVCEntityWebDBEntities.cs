namespace MVCEntityWebBOL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MVCEntityWebDBEntities : DbContext
    {
        public MVCEntityWebDBEntities()
            : base("name=MVCEntityWebDBEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<tbl_Category> tbl_Category { get; set; }
        public virtual DbSet<tbl_Url> tbl_Url { get; set; }
        public virtual DbSet<tbl_User> tbl_User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Category>()
                .Property(e => e.CategoryDesc)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Url>()
                .Property(e => e.UrlTitle)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Url>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Url>()
                .Property(e => e.UrlDesc)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Url>()
                .Property(e => e.IsApproved)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.UserEmail)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.Role)
                .IsUnicode(false);
        }
    }
}
