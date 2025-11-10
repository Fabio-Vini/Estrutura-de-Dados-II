using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fila_medicamento
{
    internal class Medicamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Laboratorio { get; set; }
        private Queue<Lote> lotes = new Queue<Lote>();

        public Medicamento() { }

        public Medicamento(int id, string nome, string laboratorio)
        {
            Id = id;
            Nome = nome;
            Laboratorio = laboratorio;
        }

        public int QtdeDisponivel()
        {
            return lotes.Sum(l => l.Qtde);
        }

        public void Comprar(Lote lote)
        {
            lotes.Enqueue(lote);
        }

        public bool Vender(int qtde)
        {
            if (QtdeDisponivel() < qtde)
                return false;

            while (qtde > 0 && lotes.Count > 0)
            {
                Lote lote = lotes.Peek();

                if (lote.Qtde <= qtde)
                {
                    qtde -= lote.Qtde;
                    lotes.Dequeue();
                }
                else
                {
                    lote.Qtde -= qtde;
                    qtde = 0;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return $"{Id} - {Nome} - {Laboratorio} - {QtdeDisponivel()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Medicamento m)
                return Id == m.Id;
            return false;
        }

        public void ListarLotes()
        {
            if (lotes.Count == 0)
                Console.WriteLine("Nenhum lote cadastrado.");
            else
            {
                foreach (var lote in lotes)
                    Console.WriteLine($"   {lote}");
            }
        }
    }
}
