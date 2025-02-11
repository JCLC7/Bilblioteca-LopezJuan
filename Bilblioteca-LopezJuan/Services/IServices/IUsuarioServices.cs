using Bilblioteca_LopezJuan.Models.Domain;

namespace Bilblioteca_LopezJuan.Services.IServices
{
    public interface IUsuarioServices
    {
        public List<Usuario>? GetUsers();
        public bool CreateUser(Usuario user);
        public Usuario Finduser(int id);
        public bool EditUser(Usuario user);
    }
}
