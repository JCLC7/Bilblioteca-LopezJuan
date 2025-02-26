using Bilblioteca_LopezJuan.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Bilblioteca_LopezJuan.Context
{
    public class AplicationDBcontext : DbContext
    {

        public AplicationDBcontext(DbContextOptions options) : base(options) {}

            //modelos que se van a mappear
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre="juan carlos",
                    Apellido="lopez can",
                    UserName="jlopez",
                    Password="123",
                    FkRol=1,
                  
                    

                }

                );
            modelBuilder.Entity<Rol>().HasData(
               new Rol
               {
                   PkRol = 1,
                   Nombre = "Administrador",


               }

               );

        }
    }
}
    

    
        
        

    

