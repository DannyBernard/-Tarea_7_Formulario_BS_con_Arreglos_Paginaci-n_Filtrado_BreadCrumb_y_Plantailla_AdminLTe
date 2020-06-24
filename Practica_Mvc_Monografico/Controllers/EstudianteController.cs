using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Practica_Mvc_Monografico.Models;
using ReflectionIT.Mvc.Paging;

namespace Practica_Mvc_Monografico.Controllers
{
	[BreadCrumb(Title = "Estudiante", Url = "/Estudiante/Index", Order = 0)]
	public class EstudianteController : Controller
	{
		public static List<Estudiante> Estudiantes;
		// GET: Estudiante
		[BreadCrumb(Title = "Listado de Estudiante", Order = 1)]
		public ActionResult Index(string filter, int page = 1, string sortExpression = "Nombre")
		{
			if (Estudiantes == null)
			{
				Estudiantes = new List<Estudiante>() {


				new Estudiante() { IDEstudiante = 1, Cedula = "402-225-565555", Nombre = "Juan", Apellido = "Perez", Telefono = "849-352-5248", Religion = "Catolico", FechaIngreso = DateTime.Today, FechaNacimiento = DateTime.Now, Email = "Danny@hotmail.com", Sexo = 'm', Nacionalidad = "Dominicano", Direccion = "Av. Libertad", EstadoCivil = "soltero", TipoDeSangre = "O+",Carrera="Ingeniieria en sistemas",Matricuala="20150070",NombreMadre="Maria",NombrePadre="Jose",Ocupacion="Estudiante",Tipocolegio="Publico", Observaciones = "Es un buen empleado" }

				};
			}
			List<Estudiante> filtrada = Estudiantes;
			if (!string.IsNullOrWhiteSpace(filter))
			{
				filtrada = Estudiantes.FindAll(x => x.Nombre.ToUpper().Contains(filter.ToUpper()));
			}


			var model = PagingList.Create(filtrada, 2, page, sortExpression, "Nombre");
			model.RouteValue = new RouteValueDictionary {
			{ "filter", filter}
			};
			model.Action = "Index";
			return View(model);
		}


		// GET: Estudiante/Details/5
		[BreadCrumb(Title = "Detalle de Estudiante", Order = 2)]
		public ActionResult Details(int id)
		{
			var modelo = Estudiantes.Find(x => x.IDEstudiante == id);
			if (modelo == null)
			{
				return RedirectToAction(nameof(Index));
			}
			return View(modelo);
		}

		// GET: Estudiante/Create
		[BreadCrumb(Title = "Crear de Estudiante", Order = 3)]
		public ActionResult Create()
		{
			return View();
		}

		// POST: Estudiante/Create\
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Estudiante modelo)
		{
			try
			{
				// TODO: Add insert logic here
				if (ModelState.IsValid)
				{
					Estudiantes.Add(modelo);
					return RedirectToAction(nameof(Index));

				}
			}
			catch
			{
				return View(modelo);
			}
			return View(modelo);
		}

		// GET: Estudiante/Edit/5
		[BreadCrumb(Title = "Create de Estudiante", Order = 3)]
		public ActionResult Edit(int id)
		{
			var modelo = Estudiantes.Find(x => x.IDEstudiante == id);
			if (modelo == null)
				return RedirectToAction(nameof(Index));
			return View(modelo);
		}

		// POST: Estudiante/Edit/5
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Estudiante modelo)
		{
			try
			{
				// TODO: Add update logic here
				if (ModelState.IsValid)
				{
					int indice = Estudiantes.FindIndex(x => x.IDEstudiante == modelo.IDEstudiante);
					Estudiantes[indice] = modelo;
					return RedirectToAction(nameof(Index));
				}
			}
			catch
			{
				return View(modelo);
			}
			return View(modelo);
		}

		// GET: Estudiante/Delete/5
		[BreadCrumb(Title = "Borrar de Estudiante", Order = 3)]
		public ActionResult Delete(int id)
		{
			var modelo = Estudiantes.Find(x => x.IDEstudiante == id);
			if (modelo == null)
				return RedirectToAction(nameof(Index));
			return View(modelo);
		}

		// POST: Estudiante/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, Estudiante modelo)
		{
			try
			{
				// TODO: Add delete logic here
				int indice = Estudiantes.FindIndex(x => x.IDEstudiante == id);
				Estudiantes.RemoveAt(indice);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(modelo);
			}
		}
	}
}