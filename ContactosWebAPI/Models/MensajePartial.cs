using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactosWebAPI.Models
{
    public partial class Mensaje
    {
        public virtual Usuario Origen { get; set; }
        public virtual Usuario Destino { get; set; }
    }
}
