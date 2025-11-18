using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ambiente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        private Queue<Log> logs = new Queue<Log>();

        public Ambiente(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void RegistrarLog(Log log)
        {
            if (logs.Count >= 100)
                logs.Dequeue(); // remove o mais antigo

            logs.Enqueue(log);
        }

        public IEnumerable<Log> GetLogs()
        {
            return logs.ToList();
        }
    }
}
