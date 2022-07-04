using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebApplicationEjercicio.Models
{
    public class Producto
    {
            public int SKUP { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public Image foto { get; set; }
    }
}
