using Bilblioteca_LopezJuan.Models.Domain;

namespace Bilblioteca_LopezJuan.Services.IServices
{
    public interface IUsuarioServices
    {
        public  Task<List<Usuario>?> GetUsers();
        public  Task<Usuario> Finduser(int id);
        public  Task<bool> CreateUser(Usuario user);
        public  Task<bool> EditUser(Usuario user);
        public  Task<bool> DeleteUser(int id);
    }
}
