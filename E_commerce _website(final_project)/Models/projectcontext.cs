using E_commerce__website_final_project_.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace E_commerce__website_final_project_.Models
{
    public class projectcontext : DbContext {

        public projectcontext(DbContextOptions<projectcontext> options) : base(options) { }
        
        public DbSet<admin> admins {  get; set; }
        public DbSet<customer> customers { get; set; }
        public DbSet<product> products { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>().HasData(new admin { a_e_mail = "a@gmail.com", a_password = "1234" });
            modelBuilder.Entity<admin>().HasData(new admin { a_e_mail = "b@gmail.com", a_password = "5678" });







                
        }
    }
     
   
}
