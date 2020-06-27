using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoRegistroConDetalle.Models
{
    public class Productos
    {
        [Key]
        public int ProductosId { get; set; }

        [Required(ErrorMessage = "Ingrese descripcion del producto")]
        [MinLength(3, ErrorMessage = "La Descripcion no es valida")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese costo de producto")]
        public decimal Costo { get; set; }

        [Required(ErrorMessage = "Ingrese cantidad de Inventario")]
        public int Inventario { get; set; }

        [Required(ErrorMessage = "Ingrese Id de suplidor")]
        public int SuplidorId { get; set; }

        [ForeignKey("SuplidorId")]
        public virtual Suplidores Suplidores { get; set; }

        public Productos()
        {
            ProductosId = 0;
            Descripcion = string.Empty;
            Costo = 0;
            Inventario = 0;
            SuplidorId = 0;
        }
    }
}
