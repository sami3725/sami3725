namespace MemberRec.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Members")
        {
        }

        public virtual DbSet<BusinessType> BusinessTypes { get; set; }
        public virtual DbSet<comittee> comittees { get; set; }
        public virtual DbSet<FeeData> FeeDatas { get; set; }
        public virtual DbSet<FeeDetail> FeeDetails { get; set; }
        public virtual DbSet<member> members { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<SubBranch> SubBranches { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        
    }
}
