using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCidadeDAO
{
    public class Pais
    {
        private List<Estado> _estados;
        public int CodigoPais { get; set; }
        public string Nome { get; set; }
        public string DDD { get; set; }
        public List<Estado> Estados 
        {
            get 
            {
                if(_estados == null)
                {
                    _estados = new EstadoDAO().GetListEstadoEmPais(CodigoPais);
                }
                return _estados;
            } 
        }
    }
}
