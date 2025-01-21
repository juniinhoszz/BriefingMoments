using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BriefingMoments.Model
{
    public class ListaModel
    {
        public string Descricao { get; set; }
        public override string ToString()
        {
            return Descricao; 
        }
    }
}
