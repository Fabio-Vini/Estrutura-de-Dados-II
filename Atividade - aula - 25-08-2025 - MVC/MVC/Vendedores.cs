using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    internal class Vendedores
    {
        private Vendedor[] osVendedores;
        private int max = 10;
        private int qtde;

        public Vendedor[] OsVendedores {get { return osVendedores; } }
        public int Qtde { get { return qtde; } }
        public int Max { get { return max; } }

        public Vendedores(int max) { 
        
            this.max = max;
            this.qtde = 0;
            this.osVendedores = new Vendedor[max];
            for (int i = 0; i < max; i++)
            {
                this.osVendedores = new Vendedor[max];
            }
        }

        //método para adicionar um vendedor
        public bool addVendedor(Vendedor v)
        {
            bool podeAdicionar = (this.qtde < this.max);
            if(podeAdicionar)
                this.osVendedores[this.qtde++] = v;
                return podeAdicionar;
        }

        //método para deletar um vendedor
        public bool delVendedor(Vendedor v)
        {
            for (int i = 0; i < osVendedores.Length; i++)
            {
                if (osVendedores[i] != null && osVendedores[i].Id == v.Id)
                {
                    // Verifica se o vendedor tem vendas registradas
                    if (osVendedores[i].valorVendas() > 0)
                    {
                        Console.WriteLine("Não é possível excluir este vendedor, pois já possui vendas registradas.");
                        return false;
                    }

                    // Se não tiver vendas, pode excluir
                    osVendedores[i] = null;
                    Console.WriteLine("Vendedor removido com sucesso.");
                    return true;
                }
            }

            Console.WriteLine("Vendedor não encontrado.");
            return false;
        }


        //método para pesquisar um vendedor
        public Vendedor pesqVendedor(Vendedor v)
        {
            Vendedor achouVendedor = new Vendedor();
            foreach (Vendedor pesquisa in this.osVendedores)
            {
                if (pesquisa.Id == v.Id)
                {
                    achouVendedor = pesquisa;
                    break;
                }
            }
            return achouVendedor;
        }

        public double ValorVendas()
        {
            double total = 0;
            for (int i = 0; i < qtde; i++)
            {
                total += osVendedores[i].valorVendas();
            }
            return total;

        }

        public double ValorComissao()
        {
            double total = 0;
            for (int i = 0; i < qtde; i++)
            {
                total += osVendedores[i].valorComissao();
            }
            return total;
        }
    }
}
