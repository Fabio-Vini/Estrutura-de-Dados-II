using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gerenc_projetos
{
    internal class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Prioridade { get; set; } // 1-alta, 2-média, 3-baixa
        public string Status { get; set; }  // Aberta, Fechada, Cancelada
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }

        public Tarefa(int id, string titulo, string descricao, int prioridade)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Prioridade = prioridade;
            Status = "Aberta";
            DataCriacao = DateTime.Now;
        }

        public void Concluir()
        {
            Status = "Fechada";
            DataConclusao = DateTime.Now;
        }

        public void Cancelar()
        {
            Status = "Cancelada";
            DataConclusao = DateTime.Now;
        }

        public void Reabrir()
        {
            Status = "Aberta";
            DataConclusao = null;
        }

        public override string ToString()
        {
            return $"[{Id}] {Titulo} - {Status} - Prioridade {Prioridade}";
        }
    }
}
