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
        private DateTime dtDevolucao;

        public DateTime DtEmprestimo { get { return dtEmprestimo;  } set { dtEmprestimo = value;  } }
        public DateTime DtDevolucao { get { return dtDevolucao; } set { dtDevolucao = value; } }

        public Emprestimo()
        {
            dtEmprestimo = DateTime.Now;
            dtDevolucao = DateTime.MinValue; //ainda não foi devolvido
        }
    }
}
