using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Practica_Mvc_Monografico.Models;
using ReflectionIT.Mvc.Paging;

namespace Practica_Mvc_Monografico.Controllers
{
	[BreadCrumb(Title = "Profesor", Url = "/Profesor/Index", Order = 0)]
	public class ProfesorController : Controller
	{
		public static List<Profesor> Profesor;
		// GET: ProfesorController
		[BreadCrumb(Title = "Listado de Profesor", Order = 1)]
		public ActionResult Index(string filter, int page = 1,string sortExpression = "Nombre")
		{

			if (Profesor == null)
			{
				Profesor = new List<Profesor>()
				{
					new Profesor(){IDProfesor =1,Codigo=303,Cedula="0560010101",Nombre="Nelson",Apellido="Abreu",Nacionalidad="Dominicano",Email="NJAbreu@hotmail.com",Direccion="En algun lugar de sfm",Carrera="Ingenieria en sistemas",Asignaturas="Programacion 2",EstadoCivil="Casado",Facultad="Sistemas",FechaIngreso = DateTime.Now,FechaNacimiento=DateTime.Now,Telefono="849325555",Sexo='M',Ocupacion="Imformatico",Religion="Catolico",CategoriaPorfersional="Doctor",GradoAcademico="Docotorado",Tipocolegio="Privado",TipoDeSangre="O+",Observaciones="Excelente Docente"}
				};
				}
			List<Profesor> filtrada = Profesor;
			if (!string.IsNullOrWhiteSpace(filter))
			{
				filtrada = Profesor.FindAll(x => x.Nombre.ToUpper().Contains(filter.ToUpper()));
			}


			var model = PagingList.Create(filtrada, 5, page, sortExpression, "Nombre");
			model.RouteValue = new RouteValueDictionary {
							{ "filter", filter}
			};
			model.Action = "Index";

			return View(model);
		}

		// GET: ProfesorController/Details/5
		[BreadCrumb(Title = "Detalle de Profesor", Order = 2)]
		public ActionResult Details(int id)
		{
			var modelo = Profesor.Find(x => x.IDProfesor == id);  //verifica si existe el id y lo busca en el arreglo
			if (modelo == null)
				return RedirectToAction(nameof(Index));

			return View(modelo);
		}

		// GET: ProfesorController/Create
		[BreadCrumb(Title = "Create de Profesor", Order = 3)]
		public ActionResult Create()
		{
			return View();
		}

		// POST: ProfesorController/Create
	
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Profesor modelo)
		{
			try
			{
				if (ModelState.IsValid)
				{
					Profesor.Add(modelo);
					return RedirectToAction(nameof(Index));
				}
				
			}
			catch
			{
				return View(modelo);
			}
			return View(modelo);
		}

		// GET: ProfesorController/Edit/5
		[BreadCrumb(Title = "Create de Profesor", Order = 3)]
		public ActionResult Edit(int id)
		{
			var modelo = Profesor.Find(x => x.IDProfesor == id);
			if (modelo == null)
				return RedirectToAction(nameof(Index));
			return View(modelo);
		}

		// POST: ProfesorController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Profesor modelo)
		{
			try
			{
				if (ModelState.IsValid)
				{
					int indice = Profesor.FindIndex(x => x.IDProfesor == modelo.IDProfesor);
					Profesor[indice] = modelo;
					return RedirectToAction(nameof(Index));
				}
			}
			catch
			{
				return View(modelo);
			}
			return View(modelo);
		}

		// GET: ProfesorController/Delete/5
		[BreadCrumb(Title = "Borrar de Profesor", Order = 3)]
		public ActionResult Delete(int id)
		{
			var modelo = Profesor.Find(x => x.IDProfesor == id);  //verifica si existe el id y lo busca en el arreglo
			if (modelo == null)
				return RedirectToAction(nameof(Index));
			return View(modelo);
		}

		// POST: ProfesorController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, Profesor modelo)
		{
			try
			{
				int indice = Profesor.FindIndex(x => x.IDProfesor == modelo.IDProfesor);
				Profesor.RemoveAt(indice);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(modelo);
			}
		}
	}
}
