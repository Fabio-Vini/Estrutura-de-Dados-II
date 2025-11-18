using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        private List<Ambiente> ambientes = new List<Ambiente>();

        public Usuario(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public bool ConcederPermissao(Ambiente ambiente)
        {
            // já possui?
            if (ambientes.Contains(ambiente))
                return false;

            ambientes.Add(ambiente);
            return true;
        }

        public bool RevogarPermissao(Ambiente ambiente)
        {
            return ambientes.Remove(ambiente);
        }

        public IEnumerable<Ambiente> GetPermissoes()
        {
            return ambientes.ToList();
        }
    }
}
