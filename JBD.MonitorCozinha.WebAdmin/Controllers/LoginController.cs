using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JBD.MonitorCozinha.CrossCutting;
using JBD.MonitorCozinha.WebAdmin.Models;
using JBD.MonitorCozinha.WebAdmin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JBD.MonitorCozinha.WebAdmin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UsuarioServiceWeb _usuarioServiceWeb;

        public LoginController(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioServiceWeb = new UsuarioServiceWeb(_mapper);
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(string userName, string senha)
        {
            string mansagem = "";
            bool logado = false;
            try
            {
                var usuario = _usuarioServiceWeb.UsuarioLogar(userName, GeraradorDeHash.GerarHash256(senha));
                if (usuario != null)
                {
                    Controle.AtualzarAcesso(usuario);
                    logado = true;
                }
                else
                {
                    mansagem = "Usuário ou senha não confere!!!";
                }
            }
            catch (Exception ex)
            {
                mansagem = "Erro: Entre em contato com o Administrador!";
            }
            return Json(new { message = mansagem, logado = logado });
        }

        public ActionResult Home()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}