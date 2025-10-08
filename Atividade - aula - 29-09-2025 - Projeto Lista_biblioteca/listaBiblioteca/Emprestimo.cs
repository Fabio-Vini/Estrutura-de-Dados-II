using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listaBiblioteca
{
    internal class Emprestimo
    {
        private DateTime dtEmprestimo;
        private DateTime? dtDevolucao;

        public DateTime DtEmprestimo { get; set; }
        public DateTime? DtDevolucao { get; set; }

        public Emprestimo()
        {
            dtEmprestimo = DateTime.Now;
            dtDevolucao = null; // precisa começar nula
        }
    }
}
