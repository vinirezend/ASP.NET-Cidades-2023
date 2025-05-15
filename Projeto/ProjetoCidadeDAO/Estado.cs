using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ProjetoCidadeDAO
{
    public class Estado
    {
        private Pais _pais;
        private List<Cidade> _cidades;
        public int CodigoEstado { get; set; }
        public string NomeEstado { get; set; }
        public string SiglaEstado { get; set; }
        public int CodigoPais { get; set; }
        [ScriptIgnore]
        public List<Cidade> Cidades
        {
            get
            {
                if (_cidades == null)
                {
                    _cidades = new CidadeDAO().GetListCidadeEmEstado(CodigoEstado);
                }
                return _cidades;
            }
        }
        public Pais Pais
        {
            get
            {
                if(_pais == null || _pais.CodigoPais != CodigoPais)
                {
                    _pais = new PaisDAO().GetPais(CodigoPais);
                }
                return _pais;
            }
        }
    }
}
