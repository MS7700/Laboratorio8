using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    
    public class Cliente
    {
        public Cliente()
        {
        }

        public Cliente(int id, string nombre, string apellido, DateTime fecha_Nacimiento, bool estaActivo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Fecha_Nacimiento = fecha_Nacimiento;
            EstaActivo = estaActivo;
        }

        public Cliente(string nombre, string apellido, DateTime fecha_Nacimiento, bool estaActivo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Fecha_Nacimiento = fecha_Nacimiento;
            EstaActivo = estaActivo;
        }

        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public bool EstaActivo { get; set; }
    }
}