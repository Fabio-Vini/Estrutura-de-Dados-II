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
        private List<Emprestimo> _emprestimos = new List<Emprestimo>();

        public int Tombo { get { return tombo; } set {  tombo = value; } }
        public List<Emprestimo> emprestimos { get { return _emprestimos; } set { _emprestimos = value; } }

        public Exemplar(int tombo)
        {
            this.tombo = tombo;
        }

        public bool emprestar()
        {
            if(disponivel())
            {
                emprestimos.Add(new Emprestimo());
                return true;
            }
            return false;
        }
        public bool devolver()
        {
            //LastOrDefault retorna o ultimo elemento que atende àquela condição
            var emprestimo = emprestimos.LastOrDefault(e => e.DtDevolucao == DateTime.MinValue);
            if(emprestimo != null)
            {
                emprestimo.DtDevolucao = DateTime.Now;
            }
            return false;
        }
        public bool disponivel()
        {
            //Any serve para verificar se algum elemento da lista atende a alguma condição
            return !emprestimos.Any(e => e.DtDevolucao == DateTime.MinValue);
        }
        public int qtdeEmprestimos()
        {
            return emprestimos.Count;
        }

    }
}
