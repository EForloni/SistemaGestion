using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Modelos
{
    public class Producto
    {
        public int id { get; set; }
        public string descripciones { get; set; }
        public int costo { get; set; }
        public int precioventa { get; set; }
        public int stock { get; set; }
        public int idusuario { get; set; }
    }
}
