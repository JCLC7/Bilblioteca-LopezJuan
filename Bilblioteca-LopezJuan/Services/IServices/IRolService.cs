using Bilblioteca_LopezJuan.Models.Domain;

namespace Bilblioteca_LopezJuan.Services.IServices
{
    public interface IRolService
    {
        public Task<List<Rol>> GetAllRol();
    }
}
