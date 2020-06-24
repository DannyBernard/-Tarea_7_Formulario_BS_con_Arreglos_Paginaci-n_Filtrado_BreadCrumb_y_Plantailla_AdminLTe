using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Practica_Mvc_Monografico.Models;
using ReflectionIT.Mvc.Paging;

namespace Practica_Mvc_Monografico.Controllers
{
    [BreadCrumb(Title = "Empleado", Url = "/Empleado/Index", Order = 0)]
    public class EmpleadoController : Controller
    {

       
        public static List<Empleado> empleados;
        // GET: CRUD
        [BreadCrumb(Title = "Listado de Empleado", Order = 1)]
        public ActionResult Index(string filter,int page =1,string sortExpression="Nombre")
        {
            if (empleados == null)
            {
                empleados = new List<Empleado>()
                {
                    new Empleado(){IDEmpleado=1,Nombre="Juan",Apellido="Perez",Telefono="849-352-5248",Religion="Catolico",FechaIngreso=DateTime.Today,FechaNacimiento=DateTime.Now,Email="Danny@hotmail.com",Sexo='m',NombreContacto="Pedro perez",TelefonoContacto="849-352-3548",Nacionalidad="Dominicano",ARS="Senasa",Cedula="056-0005355-5",AFP="popular",Codigo=2525,Departamento="TI",Direccion="Av. Libertad",EstadoCivil="soltero",Salario=20000,TipoDeSangre="O+",Observaciones="Es un buen empleado"},
                      new Empleado(){IDEmpleado=2,Nombre="Jose",Apellido="Perez",Telefono="849-352-5248",Religion="Catolico",FechaIngreso=DateTime.Today,FechaNacimiento=DateTime.Now,Email="Danny@hotmail.com",Sexo='m',NombreContacto="Pedro perez",TelefonoContacto="849-352-3548",Nacionalidad="Dominicano",ARS="Senasa",Cedula="056-0005355-5",AFP="popular",Codigo=2525,Departamento="TI",Direccion="Av. Libertad",EstadoCivil="soltero",Salario=20000,TipoDeSangre="O+",Observaciones="Es un buen empleado"},
                        new Empleado(){IDEmpleado=3,Nombre="Pedro",Apellido="Perez",Telefono="849-352-5248",Religion="Catolico",FechaIngreso=DateTime.Today,FechaNacimiento=DateTime.Now,Email="Danny@hotmail.com",Sexo='m',NombreContacto="Pedro perez",TelefonoContacto="849-352-3548",Nacionalidad="Dominicano",ARS="Senasa",Cedula="056-0005355-5",AFP="popular",Codigo=2525,Departamento="TI",Direccion="Av. Libertad",EstadoCivil="soltero",Salario=20000,TipoDeSangre="O+",Observaciones="Es un buen empleado"},
                          new Empleado(){IDEmpleado=4,Nombre="Julian",Apellido="Perez",Telefono="849-352-5248",Religion="Catolico",FechaIngreso=DateTime.Today,FechaNacimiento=DateTime.Now,Email="Danny@hotmail.com",Sexo='m',NombreContacto="Pedro perez",TelefonoContacto="849-352-3548",Nacionalidad="Dominicano",ARS="Senasa",Cedula="056-0005355-5",AFP="popular",Codigo=2525,Departamento="TI",Direccion="Av. Libertad",EstadoCivil="soltero",Salario=20000,TipoDeSangre="O+",Observaciones="Es un buen empleado"}
                };
            }

            List<Empleado> filtrada = empleados;
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filtrada = empleados.FindAll(x => x.Nombre.ToUpper().Contains(filter.ToUpper()));
            }


            var model = PagingList.Create(filtrada, 2, page, sortExpression, "Nombre");
            model.RouteValue = new RouteValueDictionary {
                            { "filter", filter}
            };
            model.Action = "Index";
            return View(model);
        }

        // GET: CRUD/Details/5
        [BreadCrumb(Title = "Detalle de Empleado", Order =2)]
        public ActionResult Details(int id)
        {
            var modelo = empleados.Find(x => x.IDEmpleado == id);
           if (modelo == null)
            return RedirectToAction(nameof(Index));
            return View(modelo);
                    
        }

        // GET: CRUD/Create
        [BreadCrumb(Title = "Create de Empleado", Order = 3)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUD/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleado modelo)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    empleados.Add(modelo);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: CRUD/Edit/5
        [BreadCrumb(Title = "Editar de Empleado", Order = 4)]
        public ActionResult Edit(int id)
        {
            var modelo = empleados.Find(x => x.IDEmpleado == id);
            if (modelo == null)
                return RedirectToAction(nameof(Index));
            return View(modelo);
        }

        // POST: CRUD/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Empleado modelo)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    int indice = empleados.FindIndex(x => x.IDEmpleado == modelo.IDEmpleado);
                    empleados[indice] = modelo;
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: CRUD/Delete/5
        [BreadCrumb(Title = "Borrar de Empleado", Order = 5)]
        public ActionResult Delete(int id)
        {
            var modelo = empleados.Find(x => x.IDEmpleado == id);
            if (modelo == null)
                return RedirectToActionPermanent(nameof(Index));
            return View(modelo);
        }

        // POST: CRUD/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Empleado modelo)
        {
            try
            {
                // TODO: Add delete logic here
                int indice = empleados.FindIndex(x => x.IDEmpleado == id);
                empleados.RemoveAt(indice);
                 return RedirectToAction(nameof(Index));

            
            }
            catch
            {
                return View(modelo);
            }
        }
        public IActionResult AdminLite()
		{
            return View();
		}
    }
}