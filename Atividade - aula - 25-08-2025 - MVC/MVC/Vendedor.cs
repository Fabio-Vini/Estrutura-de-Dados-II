using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    internal class Vendedor
    {
        private int id;
        private string nome;
        private double percComissao;
        private Venda[] asVendas = new Venda[31];

        public int Id { get { return id; } set { id = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public double PercComissao { get { return percComissao; } set {  percComissao = value; } }
        public int QtdeVendas { get { return asVendas.Count(v => v != null); } }


        public Vendedor(int id, string nome, double percComissao)
        {
            this.Id = id;
            this.Nome = nome;
            this.PercComissao = percComissao;
        }

        public Vendedor(int id) : this(id, "", 0)
        {
        }
        public Vendedor() : this(-1, "", 0)
        {
        }

        public bool registrarVenda(int dia, Venda v)
        {
            if(dia < 1 || dia > 31) return false;
            asVendas[dia - 1] = v;
            return true;   
        }

        public double valorVendas()
        {
            double total = 0;
            foreach (var venda in asVendas)
            {
                if(venda != null)
                total += venda.Valor;
            }
            return total;

        }

        public double valorComissao()
        {
            return valorVendas() * percComissao;
        }
    }
}
