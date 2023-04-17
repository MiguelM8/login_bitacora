using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login_bitacora
{
    public class Historial
    {
        public string usuario { get; }
        public DateTime fecha { get; }

        public Historial(string usuario, DateTime fecha)
        {
            this.usuario = usuario;
            this.fecha = fecha;
        }
    }
}
