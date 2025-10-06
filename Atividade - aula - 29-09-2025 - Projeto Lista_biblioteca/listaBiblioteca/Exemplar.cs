using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listaBiblioteca
{
    internal class Exemplar
    {
        private int tombo;
        List<Emprestimo> emprestimos = new List<Emprestimo>();

        public int Tombo { get { return tombo; } set {  tombo = value; } }

        public Exemplar(int tombo)
        {
            this.tombo = tombo;
        }

        public bool emprestar()
        {
            return false;
        }
        public bool devolver()
        {
            return false;
        }
        public bool disponivel()
        {
            return false;
        }
        public int qtdeEmprestimos()
        {
            return 0;
        }

    }
}
