using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Model
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions<AplicationContext>options): base(options)
        {

        }
        public DbSet<Categoria> Categorias { get; set; }
        

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             base.OnConfiguring(optionsBuilder);
         }*/
    }
}
