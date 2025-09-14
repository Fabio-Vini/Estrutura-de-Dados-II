using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcRestaurante
{
    internal class Restaurante
    {
        private int proxPedido;
        private Pedido[] pedidos = new Pedido[50];

        public int ProxPedido { get { return proxPedido; } set { proxPedido = value; } }

        public Restaurante()
        {
            this.ProxPedido = 0;
        }

        public bool novoPedido(Pedido pedido)
        {
            for(int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] == null)
                {
                    pedidos[i] = pedido;
                    proxPedido++;
                    return true;
                }
            }
            return false;
        }

        public Pedido buscarPedido(int id)
        {
            foreach(Pedido p in pedidos)
            {
                if(p != null && p.Id == id)
                {
                    return p;
                }
            }
            return null;
        }

        public bool cancelarPedido(Pedido pedido)
        {
            for(int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null && pedidos[i].Id == pedido.Id)
                {
                    pedidos[i] = null;
                    return true;
                }
            }

            Console.WriteLine("Pedido não encontrado!");
            return false;
        }

        public void listarPedidos()
        {
            double totalDia = 0;
            bool temPedido = false;

            foreach (Pedido p in pedidos)
            {
                if (p != null)
                {
                    temPedido = true; // achou pelo menos um pedido
                    Console.WriteLine($"\nPedido #{p.Id} - Cliente: {p.Cliente}");
                    Console.WriteLine(p.dadosDoPedido());
                    Console.WriteLine($"Total do pedido: R${p.calcularTotal():F2}");
                    totalDia += p.calcularTotal();
                }
            }

            if (!temPedido)
            {
                Console.WriteLine("Nenhum pedido realizado hoje!");
            }
            else
            {
                Console.WriteLine($"\n==== TOTAL DO DIA: R${totalDia:F2} ====");
            }
        }

        public Pedido[] Pedidos
        {
            get { return pedidos; }
        }
    }
}
