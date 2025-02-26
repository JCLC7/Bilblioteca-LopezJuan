using Bilblioteca_LopezJuan.Models.Domain;
using Bilblioteca_LopezJuan.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bilblioteca_LopezJuan.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        private readonly IRolService _rolService;
        public UsuariosController(IUsuarioServices usuarioServices, IRolService rolService)
        {
            _usuarioServices = usuarioServices;
            _rolService = rolService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _usuarioServices.GetUsers();
            return View(result);
        }

      
        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario) {
          
            await _usuarioServices.CreateUser(usuario);
            return RedirectToAction("Index");
                        
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _usuarioServices.Finduser(id);
            List<Rol> roels = await _rolService.GetAllRol();

            ViewBag.Roles = roels.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkRol.ToString()
            });
            return View(result);

        }

        [HttpPost]
        public async Task<IActionResult> PostEdit(Usuario usuario)
        {
            await _usuarioServices.EditUser(usuario);
            return RedirectToAction("Index");

        }
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
           
            try
            {
                await _usuarioServices.DeleteUser(id);
               
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al eliminar el usuario");
            }

        }
       




        [HttpGet]
        public async Task<IActionResult> Add()
        {
            

            List <Rol> result = await _rolService.GetAllRol();

            ViewBag.Roles = result.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkRol.ToString()
            });
            return View();
        }
    }
}
