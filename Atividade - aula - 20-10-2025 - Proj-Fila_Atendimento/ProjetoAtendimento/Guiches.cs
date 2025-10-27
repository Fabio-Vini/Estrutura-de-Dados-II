using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAtendimento
{
    internal class Guiches
    {
        public List<Guiche> ListaGuiches { get; private set; }

        public Guiches()
        {
            ListaGuiches = new List<Guiche>();
        }

        public void Adicionar(Guiche guiche)
        {
            ListaGuiches.Add(guiche);
        }
    }
}
