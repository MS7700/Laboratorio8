using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServiceReference;

namespace WebService.Controllers
{
    public class ClientesController : Controller
    {
        
        //private Model db = new Model();
        ClienteSoapClient clienteSoap = new ClienteSoapClient();
        // GET: Clientes
        public ActionResult Index()
        {
            IEnumerable<Cliente> clientes = clienteSoap.ObtenerClientes().ToList();
            return View(clienteSoap.ObtenerClientes());
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteSoap.InsertarCliente(cliente.Nombre, cliente.Apellido, cliente.Fecha_Nacimiento);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            clienteSoap.ModificarEstado(id);
            return RedirectToAction("Index");
        }

        

        // Get: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            clienteSoap.EliminarCliente(id);
            return RedirectToAction("Index");
        }

        
    }
}
