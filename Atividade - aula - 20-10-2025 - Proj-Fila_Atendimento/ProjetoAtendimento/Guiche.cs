using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAtendimento
{
    internal class Guiche
    {
        public int Id { get; private set; }
        public Queue<Senha> Atendimentos { get; private set; }

        public Guiche()
        {
            Id = 0;
            Atendimentos = new Queue<Senha>();
        }

        public Guiche(int id)
        {
            Id = id;
            Atendimentos = new Queue<Senha>();
        }

        public bool Chamar(Queue<Senha> filaSenhas)
        {
            if (filaSenhas.Count == 0)
                return false;

            Senha s = filaSenhas.Dequeue();
            s.DataAtend = System.DateTime.Now;
            s.HoraAtend = System.DateTime.Now;
            Atendimentos.Enqueue(s);
            return true;
        }
    }
}
