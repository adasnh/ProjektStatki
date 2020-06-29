using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiWseiLibrary.Modele
{
    public class ModelSiatki
    {
        public string LiteraPola { get; set; }
        public int NumerPola { get; set; }
        public StatusPola Status { get; set; } = StatusPola.Pusty;
    }
}
