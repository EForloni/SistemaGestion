using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionWebApi
{
    public class ProductoVendido
    {
        public int id { get; set; }
        public int stock { get; set; }
        public int idproducto { get; set; }
        public int idventa { get; set; }
    }
}
