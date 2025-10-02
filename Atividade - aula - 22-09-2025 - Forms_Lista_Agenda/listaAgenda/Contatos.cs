using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listaAgenda
{
    internal class Contatos
    {
        private readonly List<Contato> agenda = new List<Contato>();

        public bool adicionar(Contato c)
        {
            if (!agenda.Contains(c))
            {
                agenda.Add(c);
                return true;
            }
            return false;
        }

        public Contato pesquisar(Contato c)
        {
            foreach (var contato in agenda)
            {
                if (contato.Equals(c))
                    return contato;
            }
            return null;
        }

        public bool alterar(Contato c)
        {
            for (int i = 0; i < agenda.Count; i++)
            {
                if (agenda[i].Equals(c))
                {
                    agenda[i] = c;
                    return true;
                }
            }
            return false;
        }

        public bool remover(Contato c)
        {
            return agenda.Remove(c);
        }

        public List<Contato> Listar()
        {
            return agenda;
        }

    }
}
