using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BriefingMoments.Model
{
    public class DadosModel
    {
        public string Nome {  get; set; }
        public string TipoColegio { get; set; }
        public int QntTurmas { get; set; }
        public int QntAlunos { get; set; }
        public double ValorRepasse { get; set; }
        public string Producao { get; set; }
        public DateTime DataCol { get; set; }
        public DateTime DataBaile { get; set; }
        public string Obs { get; set; }
        public string NomeOperador { get; set; }

    }
}
