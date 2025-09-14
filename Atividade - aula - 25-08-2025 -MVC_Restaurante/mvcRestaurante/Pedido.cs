using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcRestaurante
{
    internal class Pedido
    {
        private int id;
        private string cliente;
        private Item[] itens = new Item[10];
        
        public int Id { get { return id; } }
        public string Cliente { get { return cliente; } set { cliente = value; } }

        public Pedido(int id, string cliente)
        {
            this.id = id;
            this.Cliente = cliente;
        }

        public bool adicionarItem(Item item)
        {
            for(int i = 0; i < itens.Length; i++)
            {
                if (itens[i] == null)
                {
                    itens[i] = item;
                    return true;
                }
            }
            return false;
        }

        public bool removerItem(Item item)
        {
            for(int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null && itens[i].Id == item.Id)
                {
                    itens[i] = null;
                    return true;
                }
            }
            Console.WriteLine("Item não encontrado!");
            return false;
        }

        public string dadosDoPedido()
        {
            int qtdPedido = 0;
            string resultado = " ";

            foreach(Item i in itens)
            {
                if(i != null)
                {
                    resultado += $" - {i.Id} | {i.Descricao} | {i.Preco}";
                    qtdPedido++;
                }
            }
            if (qtdPedido == 0)
            {
                resultado = "Nenhum item associado ao pedido!";
            }

            return resultado;
        }

        public double calcularTotal()
        {
            double total = 0;
            foreach (var item in itens)
            {
                if (item != null)
                    total += item.Preco;
            }
            return total;
        }

        public int guardaItens()
        {
            int qtd = 0;
            Console.WriteLine("\nItens: ");
            foreach (Item i in itens)
            {
                if (i != null)
                {
                    Console.WriteLine($"{i.Descricao}");
                    qtd++;
                }
            }

            if (qtd == 0)
            {
                Console.WriteLine("Nenhum item!");
            }

            return qtd;
        }


        public Pedido(int id) : this(id, "")
        {
        }
        public Pedido() : this(-1, "")
        {
        }
    }
}
