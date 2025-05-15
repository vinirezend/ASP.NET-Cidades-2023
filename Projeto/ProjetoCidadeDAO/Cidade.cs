using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCidadeDAO
{
    public class Cidade
    {
        private Estado _estado;
        public int CodigoCidade { get; set; }
        public string Nome { get; set; }
        public int CodigoEstado { get; set; }
        public Estado Estado 
        { 
            get 
            {
                if(_estado == null || _estado.CodigoEstado != CodigoEstado)
                {
                    _estado = new EstadoDAO().GetEstado(CodigoEstado);
                }
                return _estado;
            } 
        }
    }
}
