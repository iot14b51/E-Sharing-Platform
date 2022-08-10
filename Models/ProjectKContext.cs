using Microsoft.EntityFrameworkCore;
using ProjectK.Models;

namespace ProjectK.Models
{
    public class ProjectKContext: DbContext
    {
        public ProjectKContext()
        {

        }
        public ProjectKContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> CustomerM { get; set; }
        public DbSet<Vendor> VendorM { get; set; }
        public DbSet<Admin> AdminM { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Services> services { get; set; }
        public DbSet<BookProduct> bookProducts { get; set; }

        public DbSet<BookService> bookServices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =NANAJIBOLLA\\SQLEXPRESS;Initial Catalog=ProjectK;Integrated Security=true");
        }
        public DbSet<ProjectK.Models.CustomerLogin>? CustomerLogin { get; set; }
        public DbSet<ProjectK.Models.VendorLogin>? VendorLogin { get; set; }
        public DbSet<ProjectK.Models.AdminLogin>? AdminLogin { get; set; }
        public DbSet<ProjectK.Models.BookProduct>? BookProduct { get; set; }
    }
}
