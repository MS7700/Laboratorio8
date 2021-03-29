using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using WebService.Models;

namespace WebService.WebService
{
    /// <summary>
    /// Descripción breve de Cliente
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Cliente : System.Web.Services.WebService
    {


        [WebMethod]
        public void InsertarCliente(String nombre, String apellido, DateTime fechaNacimiento)
        {
            using (var db = new Model())
            {
                Models.Cliente cliente = new Models.Cliente(nombre, apellido, fechaNacimiento, true);
                cliente = db.Clientes.Add(cliente);
                db.SaveChanges();
            }
        }
        [WebMethod]
        public void ModificarEstado(int id)
        {
            using (var db = new Model())
            {
                db.Clientes.FindAsync(id).Result.EstaActivo = !db.Clientes.FindAsync(id).Result.EstaActivo;
                db.SaveChanges();
            }
        }

        [WebMethod]
        public List<Models.Cliente> ObtenerClientes()
        {
            using (var db = new Model())
            {
                return  db.Clientes.ToList();
            }
        }
        [WebMethod]
        public void EliminarCliente(int id)
        {
            using (var db = new Model())
            {
                var cliente = db.Clientes.FindAsync(id).Result;
                db.Clientes.Remove(cliente);
                db.SaveChanges();
            }
        }

    }
}
