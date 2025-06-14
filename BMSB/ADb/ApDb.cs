using Microsoft.EntityFrameworkCore;
using BMSB.Models;
namespace BMSB.ADb
{ 
    public class ApDb : DbContext
    {
        public ApDb(DbContextOptions<ApDb> options) : base(options){ }
        public DbSet<Cred> Creds { get; set; }
        public DbSet<AuthCred> AuthCreds { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Approval> Approvals { get; set; }

    }
}
