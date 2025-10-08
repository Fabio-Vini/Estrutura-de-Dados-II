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
            emprestimos = new List<Emprestimo>();
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
            Emprestimo emp = emprestimos.LastOrDefault(e => e.DtDevolucao == null);
            if (emp != null)
            {
                emp.DtDevolucao = DateTime.Now;
                return true;
            }
            return false;
        }
        public bool disponivel()
        {
            if (emprestimos.Count == 0)
                return true;

            // Está disponível se o último empréstimo tiver data de devolução
            return emprestimos.Last().DtDevolucao != null;
        }
        public int qtdeEmprestimos()
        {
            return emprestimos.Count;
        }

    }
}
