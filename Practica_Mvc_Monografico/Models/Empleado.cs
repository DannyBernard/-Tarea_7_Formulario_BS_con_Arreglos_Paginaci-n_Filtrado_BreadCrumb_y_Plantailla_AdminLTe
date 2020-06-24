using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practica_Mvc_Monografico.Models
{
	public class Empleado
	{
        [Key]
        public int IDEmpleado { get; set; }
        public int Codigo { get; set; }
        public string Cedula { get; set; }
        [Display(Name = "Fecha Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [Required(ErrorMessage = "Fecha invalida")]
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        [StringLength(40, ErrorMessage = "Máximo 40 caracteres.")]
        public string Nombre { get; set; }
        [StringLength(40, ErrorMessage = "Máximo 40 caracteres.")]
        public string Apellido { get; set; }
        public char Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string TipoDeSangre { get; set; }
        public string Nacionalidad { get; set; }
        public string Religion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int Salario { get; set; }
        public string Departamento { get; set; }
        public string NombreContacto { get; set; }
        public string TelefonoContacto { get; set; }
        public string AFP { get; set; }
        public string ARS { get; set; }
        public string Observaciones { get; set; }
    }
}
