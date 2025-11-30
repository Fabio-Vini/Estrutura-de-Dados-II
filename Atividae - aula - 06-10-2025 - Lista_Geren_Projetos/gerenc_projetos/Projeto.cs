using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gerenc_projetos
{
    internal class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Tarefa> Tarefas { get; set; } = new List<Tarefa>();

        public Projeto(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AdicionarTarefa(Tarefa t)
        {
            Tarefas.Add(t);
        }

        public bool RemoverTarefa(int id)
        {
            var t = Tarefas.FirstOrDefault(x => x.Id == id);
            if (t != null)
            {
                Tarefas.Remove(t);
                return true;
            }
            return false;
        }

        public Tarefa BuscarTarefa(int id)
        {
            return Tarefas.FirstOrDefault(x => x.Id == id);
        }

        public List<Tarefa> TarefasPorStatus(string status)
        {
            return Tarefas.Where(t => t.Status == status).ToList();
        }

        public List<Tarefa> TarefasPorPrioridade(int prioridade)
        {
            return Tarefas.Where(t => t.Prioridade == prioridade).ToList();
        }

        public int TotalAbertas() => Tarefas.Count(t => t.Status == "Aberta");
        public int TotalFechadas() => Tarefas.Count(t => t.Status == "Fechada");
    }
}
