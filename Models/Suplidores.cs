using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoRegistroConDetalle.Models
{
    public class Suplidores
    {
        [Key]
        public int SuplidorId { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del suplidor")]
        [MinLength(3, ErrorMessage = "El Nombre no es valido")]
        public string Nombre { get; set; }

        public Suplidores()
        {
            SuplidorId = 0;
            Nombre = string.Empty;
        }
    }
}
