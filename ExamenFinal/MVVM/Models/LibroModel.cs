using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinal.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class LibroModel
    {
        public String Titulo { get; set; }
        public String Autor { get; set; }
        public int NumPagTotales { get; set; }
        public int NumPagLeidas { get; set; }
        public int PorcentajeLeido { get; set; }
    }
}
