using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiWseiLibrary.Modele
{
    public class ModelGracza
    {
        public string Nick { get; set; }
        public List<ModelSiatki> miejsceStatku { get; set; } = new List<ModelSiatki>();
        public List<ModelSiatki> poleStrzalu { get; set; } = new List<ModelSiatki>();
    }
}
