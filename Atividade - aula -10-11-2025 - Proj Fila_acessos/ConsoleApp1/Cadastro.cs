using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Cadastro
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Ambiente> ambientes = new List<Ambiente>();

        public void AdicionarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public bool RemoverUsuario(Usuario usuario)
        {
            if (usuario.GetPermissoes().Any())
                return false;

            return usuarios.Remove(usuario);
        }

        public Usuario PesquisarUsuario(Usuario usuario)
        {
            return usuarios.FirstOrDefault(u => u.Id == usuario.Id);
        }

        public void AdicionarAmbiente(Ambiente ambiente)
        {
            ambientes.Add(ambiente);
        }

        public bool RemoverAmbiente(Ambiente ambiente)
        {
            return ambientes.Remove(ambiente);
        }

        public Ambiente PesquisarAmbiente(Ambiente ambiente)
        {
            return ambientes.FirstOrDefault(a => a.Id == ambiente.Id);
        }

        public void Upload()
        {
            // implementar depois (salvar dados em arquivo)
        }

        public void Download()
        {
            // implementar depois (carregar arquivo)
        }
    }
}
