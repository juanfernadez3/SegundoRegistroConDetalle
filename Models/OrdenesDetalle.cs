﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoRegistroConDetalle.Models
{
    public class OrdenesDetalle
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe Ingresar Id de Orden")]
        public int OrdenId { get; set; }

        [Required(ErrorMessage = "Ingrese cantidad de producto")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Ingrese Id de producto")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Ingrese costo de producto")]
        public decimal Costo { get; set; }

        [Required(ErrorMessage = "Ingrese detalle de producto")]
        public string Detalle { get; set; }

        [Required(ErrorMessage = "Ingrese Total del producto")]
        public decimal Total { get; set; }

        public OrdenesDetalle()
        {
            Id = 0;
            OrdenId = 0;
            Cantidad = 0;
            ProductoId = 0;
            Detalle = string.Empty;
            Costo = 0;
            Total = 0;
        }
    }
}
