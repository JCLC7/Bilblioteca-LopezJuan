using Bilblioteca_LopezJuan.Context;
using Bilblioteca_LopezJuan.Models.Domain;
using Bilblioteca_LopezJuan.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bilblioteca_LopezJuan.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly AplicationDBcontext _dbcontext;
       
        public UsuarioServices(AplicationDBcontext dBcontext)
        {
            _dbcontext = dBcontext;
            


        }

        public async Task<List<Usuario>> GetUsers()
        {
            try
            {
                var result = await _dbcontext.Usuario.Include(x => x.Roles).ToListAsync();


                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("error: " + ex.Message);

            }
        }

        public async Task<Usuario> Finduser(int id)
        {
            try
            {
                Usuario usuario = await _dbcontext.Usuario.FindAsync(id);



                return usuario;

            }
            catch (Exception ex)
            {
                throw new Exception("error: " + ex.Message);
            }
        }

        public async Task<bool> CreateUser(Usuario user)
        {

            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = user.Nombre,
                    Apellido = user.Apellido,
                    UserName = user.UserName,
                    Password = user.Password,
                    FkRol = 1,

                };
                var result = await _dbcontext.Usuario.AddAsync(usuario);
                await _dbcontext.SaveChangesAsync();

                if (result != null)
                {
                    return true;
                }
                return false;

            }
            catch (Exception e)
            {

                if (e.InnerException != null)
                {
                    throw new Exception("Error: " + e.InnerException.Message);
                }
                throw new Exception("Error: " + e.Message);
            }

        }

        public async Task<bool> EditUser(Usuario user)
        {
            try
            {

                await Finduser(user.PkUsuario);
                Usuario usuario = await Finduser(user.PkUsuario);

                usuario.Nombre = user.Nombre;
                usuario.Apellido = user.Apellido;
                usuario.UserName = user.UserName;
                usuario.Password = user.Password;
                usuario.FkRol = user.FkRol;
                var result = _dbcontext.Usuario.Update(usuario);
                await _dbcontext.SaveChangesAsync();

                if (result != null)
                {
                    return true;
                }
                return false;

            }
            catch (Exception e)
            {

                if (e.InnerException != null)
                {
                    throw new Exception("Error: " + e.InnerException.Message);
                }
                throw new Exception("Error: " + e.Message);
            }
        }

       
           public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var usuario = await _dbcontext.Usuario.FindAsync(id);
                if (usuario == null)
                {
                    return false;
                }
                _dbcontext.Usuario.Remove(usuario);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Error al eliminar el usuario: " + (e.InnerException?.Message ?? e.Message));
            }
        }

    


    }
}

