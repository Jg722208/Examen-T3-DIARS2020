using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using T3_N00024113.Extenciones;
using T3_N00024113.Models;

namespace T3_N00024113.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly T3Context context;
        public UsuarioController(T3Context context)
        {
            this.context = context;
        }
        // GET: UsuarioController
        public ActionResult Index()
        {
            var usuario = HttpContext.Session.Get<Usuario>("Logueado");
            var rutinas = context.Rutinas.Where(o=>o.IdUsuario ==usuario.IdUsuario).ToList();
            return View(rutinas);
        }
        

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            

            return View(new Usuario());
        }

        // POST: UsuarioController/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Password = GetHashetPassword(usuario.Password);
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(usuario);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string usuario,string password )
        {
            var usuariodb = context.Usuarios.FirstOrDefault(o=>o.NombreUsuario==usuario && o.Password==GetHashetPassword(password));
            
            if (usuariodb==null)
            {
                ModelState.AddModelError("Login", "Usuario o contraseña incorrectos");
                return View();
            }
            HttpContext.Session.Set("Logueado",usuariodb);
            var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, usuario)
                };

            var claimsIdentity = new ClaimsIdentity(claims, "Login");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            HttpContext.SignInAsync(claimsPrincipal);
            return RedirectToAction("Index");
        }
        private string GetHashetPassword(string password)
        {
            var sha = SHA256.Create();
            var hashData = sha.ComputeHash(Encoding.Default.GetBytes(password));
            return Convert.ToBase64String(hashData);
        }

    }
}
