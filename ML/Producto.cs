using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public string SKU { get; set; }
        public string Fert { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public string NumeroDeSerie { get; set; }
        public DateTime Fecha { get; set; }
        public List<object> Productos { get; set; }
        public string Accion { get; set; }
    }
}
