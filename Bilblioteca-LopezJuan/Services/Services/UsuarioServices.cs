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

        public List<Usuario>? GetUsers()
        {
            try
            {
                 var result = _dbcontext.Usuarios.Include(x=> x.roles).ToList();

                var users = _dbcontext.Usuarios.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("error: " + ex.Message);

            }
        }

        public Usuario Finduser (int id)
        {
            try
            {
                Usuario usuario = _dbcontext.Usuarios.Find(id);
               


                return usuario;

            }catch(Exception ex)
            {
                throw new Exception("error: " + ex.Message);
            }
        }
      
        public bool CreateUser(Usuario user)
        {

            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = user.Nombre,
                    Apellido = user.Apellido,
                    UserName = user.UserName,
                    Password = user.Password,
                    FkRol = 1

                };
                var result = _dbcontext.Usuarios.Add(usuario);
                _dbcontext.SaveChanges();

                if (result != null)
                {
                    return true;
                }
                return false;
                    
            }
            catch (Exception e)
            {

                throw new Exception("error: " + e.Message);
            }

        }

        public bool EditUser(Usuario user)
        {
            try
            {

                Finduser(user.PkUsuario);
                Usuario usuario = Finduser(user.PkUsuario);

                usuario.Nombre = user.Nombre;
                usuario.Apellido = user.Apellido;
                usuario.UserName = user.UserName;
                usuario.Password = user.Password;
                usuario.FkRol = 1;
                var result = _dbcontext.Usuarios.Update(usuario);
                _dbcontext.SaveChanges();

                if (result != null)
                {
                    return true;
                }
                return false;

            }
            catch (Exception e)
            {

                throw new Exception("error: " + e.Message);
            }

        }

        
    }
}
