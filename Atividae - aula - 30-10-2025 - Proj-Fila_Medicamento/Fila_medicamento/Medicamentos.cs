using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fila_medicamento
{
    internal class Medicamentos
    {
        private List<Medicamento> listaMedicamentos = new List<Medicamento>();

        public void Adicionar(Medicamento medicamento)
        {
            listaMedicamentos.Add(medicamento);
        }

        public bool Deletar(Medicamento medicamento)
        {
            var med = Pesquisar(medicamento);
            if (med != null && med.QtdeDisponivel() == 0)
            {
                listaMedicamentos.Remove(med);
                return true;
            }
            return false;
        }

        public Medicamento Pesquisar(Medicamento medicamento)
        {
            return listaMedicamentos.FirstOrDefault(m => m.Id == medicamento.Id);
        }

        public void ListarTodos()
        {
            if (listaMedicamentos.Count == 0)
                Console.WriteLine("Nenhum medicamento cadastrado.");
            else
                foreach (var m in listaMedicamentos)
                    Console.WriteLine(m);
        }
    }
}
