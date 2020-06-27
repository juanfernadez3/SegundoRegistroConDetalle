using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoRegistroConDetalle.Models
{
    public class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }

        [Required(ErrorMessage = "Debe ingresar Fecha de Ingreso")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Debe ingresar Suplidor")]
        public int SuplidorId { get; set; }

        [Required(ErrorMessage = "Debe ingresar Monto")]
        public decimal Monto { get; set; }

        [ForeignKey("OrdenId")]
        public virtual List<OrdenesDetalle> OrdenesDetalle { get; set; }

        public Ordenes()
        {
            OrdenId = 0;
            Fecha = DateTime.Now;
            SuplidorId = 0;
            Monto = 0;
            OrdenesDetalle = new List<OrdenesDetalle>();
        }
    }
}
