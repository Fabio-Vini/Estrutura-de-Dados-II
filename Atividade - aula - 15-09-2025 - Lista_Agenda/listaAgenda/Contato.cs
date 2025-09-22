using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listaAgenda
{
    internal class Contato
    {
        private string email;
        private string nome;
        private Data dtNasc;
        List<Telefone> telefones = new List<Telefone>();

        public string Email { get { return email; } set { email = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public Data DtNasc { get { return dtNasc; } set { dtNasc = value; } }


        public Contato() { }

        public Contato(string nome, string email, Data dtNasc)
        {
            this.nome = nome;
            this.email = email;
            this.dtNasc = dtNasc;
        }

        public int getIdate()
        {
            return DateTime.Now.Year - int.Parse(dtNasc.ToString().Split('/')[2]);
        }

        public void adicionarTelefone(Telefone t)
        {
            telefones.Add(t);
        }

        public string getTelefonePrincipal()
        {
            foreach (var tel in telefones)
            {
                if (tel.IsPrincipal())
                    return tel.GetNumero();
            }
            return "Nenhum telefone principal cadastrado.";
        }

        public override string ToString()
        {
            string telefonePrincipal = getTelefonePrincipal();
            return $"Nome: {nome}\nEmail: {email}\nNascimento: {dtNasc}\nTelefone Principal: {telefonePrincipal}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Contato)) return false;
            Contato c = (Contato)obj;

            // Comparação de email ignorando maiúsculas/minúsculas e espaços extras
            return this.email.Trim().ToLower() == c.email.Trim().ToLower();
        }

        public override int GetHashCode()
        {
            return email.Trim().ToLower().GetHashCode();
        }
    }
}