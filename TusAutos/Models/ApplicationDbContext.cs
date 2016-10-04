using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TusAutos.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.


    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public DbSet<Auto> Autos { get; set; }
        public DbSet<Consesionaria> Consesionarias { get; set; }
        public DbSet<Promotor> Promotores { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}