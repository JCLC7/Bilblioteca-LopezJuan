using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bilblioteca_LopezJuan.Models.Domain
{
    public class Usuario
    {
        [Key]
        public int PkUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [ForeignKey("roles")]
        public int FkRol { get; set; }

        public Rol roles { get; set; }
    }
}
