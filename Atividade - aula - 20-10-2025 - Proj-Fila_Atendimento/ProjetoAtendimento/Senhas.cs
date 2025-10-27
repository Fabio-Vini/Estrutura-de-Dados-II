using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAtendimento
{
    internal class Senhas
    {
        public int ProximoAtendimento { get; private set; }
        public Queue<Senha> FilaSenhas { get; private set; }

        public Senhas()
        {
            FilaSenhas = new Queue<Senha>();
            ProximoAtendimento = 1;
        }

        public void Gerar()
        {
            Senha s = new Senha(ProximoAtendimento);
            FilaSenhas.Enqueue(s);
            ProximoAtendimento++;
        }
    }
}
