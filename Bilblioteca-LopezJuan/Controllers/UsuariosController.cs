using Bilblioteca_LopezJuan.Models.Domain;
using Bilblioteca_LopezJuan.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Bilblioteca_LopezJuan.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        public UsuariosController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;

        }
        public IActionResult Index()
        {
            var result = _usuarioServices.GetUsers();
            return View(result);
        }

        [HttpGet]
        public IActionResult Add() { 
            return View();
        }
        [HttpPost]
        public IActionResult Post(Usuario usuario) { 
            _usuarioServices.CreateUser(usuario);
            return RedirectToAction("Index");
                        
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _usuarioServices.Finduser(id);
            return View(result);

        }

        [HttpPost]
        public IActionResult PostEdit(Usuario usuario)
        {
            _usuarioServices.EditUser(usuario);
            return RedirectToAction("Index");

        }
    }
}
