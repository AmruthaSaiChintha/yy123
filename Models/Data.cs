using Microsoft.EntityFrameworkCore;
using YumYard.Controllers;
using YumYard.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace YumYard.Models
{
    public class Data : DbContext

    {
      public Data(DbContextOptions<Data> options)
           : base(options)
        {
        }
        public DbSet<User> user { get; set; }   

        public DbSet<MenuItem> menuItem { get; set; }
            
        public DbSet<Order> Order { get; set; }


    }
}
