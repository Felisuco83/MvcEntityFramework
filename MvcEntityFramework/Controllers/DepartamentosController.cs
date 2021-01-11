using Microsoft.AspNetCore.Mvc;
using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Controllers
{
    public class DepartamentosController : Controller
    {
        private DepartamentosContextSQL context;
        public DepartamentosController()
        {
            this.context = new DepartamentosContextSQL();
        }
        public IActionResult Index()
        {
            List<Departamento> departamentos = this.context.GetDepartamentos();
            return View(departamentos);
        }
        public IActionResult Edit (int iddept)
        {
            return View(this.context.GetDepartamento(iddept));
        }
        [HttpPost]
        public IActionResult Edit(Departamento dept)
        {
            this.context.UpdateDepartamento(dept);
            return RedirectToAction("Index", "Departamentos");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create (Departamento dept)
        {
            int inserted = this.context.InsertDepartamento(dept);
            return RedirectToAction("Index", "Departamentos");
        }
        public IActionResult Delete (int iddept)
        {
            int deleted = this.context.DeleteDepartamento(iddept);
            return RedirectToAction("Index", "Departamentos");
        }
    }
}
