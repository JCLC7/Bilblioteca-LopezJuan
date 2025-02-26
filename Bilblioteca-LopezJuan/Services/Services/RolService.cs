using Bilblioteca_LopezJuan.Context;
using Bilblioteca_LopezJuan.Models.Domain;
using Bilblioteca_LopezJuan.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Bilblioteca_LopezJuan.Services.Services
{
    public class RolService : IRolService
    {
        private readonly AplicationDBcontext _aplicationDBcontext;
        public RolService(AplicationDBcontext aplicationDBcontext)
        {
            _aplicationDBcontext = aplicationDBcontext;
        }

        public async Task<List<Rol>> GetAllRol()
        {
            try
            {
                List<Rol> roles = await _aplicationDBcontext.roles.ToListAsync();
               
                return roles;
            }
            catch (Exception ex)
            {
                
                throw new Exception("error: " + ex.Message);
            }
        }
    }
}
