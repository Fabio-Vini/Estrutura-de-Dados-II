using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gerenc_projetos
{
    internal class Projetos
    {
        public List<Projeto> Itens { get; set; } = new List<Projeto>();

        public bool Adicionar(Projeto p)
        {
            if (Itens.Any(x => x.Id == p.Id))
                return false;

            Itens.Add(p);
            return true;
        }

        public bool Remover(int id)
        {
            var p = Itens.FirstOrDefault(x => x.Id == id);
            if (p != null && p.Tarefas.Count == 0)
            {
                Itens.Remove(p);
                return true;
            }
            return false;
        }

        public Projeto Buscar(int id)
        {
            return Itens.FirstOrDefault(x => x.Id == id);
        }

        public List<Projeto> Listar()
        {
            return Itens;
        }
    }
}
