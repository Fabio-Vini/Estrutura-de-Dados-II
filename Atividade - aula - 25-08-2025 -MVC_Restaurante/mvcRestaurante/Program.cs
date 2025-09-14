using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcRestaurante
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restaurante restaurante = new Restaurante();
            Pedido pedido = new Pedido();
            int opcao = -1;

            do
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Criar novo pedido");
                Console.WriteLine("2 - Adicionar item ao pedido");
                Console.WriteLine("3 - Remover item do pedido");
                Console.WriteLine("4 - Consultar pedido");
                Console.WriteLine("5 - Cancelar pedido");
                Console.WriteLine("6 - Listar todos os pedidos");
                Console.Write("Opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }


                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Saindo do sistema...");
                        break;

                            
                    case 1:
                        int continuar = 1;

                        while (continuar == 1 && restaurante.ProxPedido < 50)
                        {
                            Console.WriteLine("Digite o id do pedido: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.WriteLine("Digite o nome do cliente: ");
                            string cliente = Console.ReadLine();

                            Pedido novo = new Pedido(id, cliente);

                            if (restaurante.novoPedido(novo))
                                Console.WriteLine($"Pedido #{novo.Id} adicionado com sucesso para {cliente}");
                            else
                                Console.WriteLine("Não foi possível adicionar o pedido (limite atingido).");

                            if (restaurante.ProxPedido >= 50)
                            {
                                Console.WriteLine("Limite máximo de 50 pedidos atingido!");
                                break;
                            }

                            Console.WriteLine("Deseja adicionar outro pedido? (1 - Sim / 0 - Não)");
                            continuar = int.Parse(Console.ReadLine());
                        }
                        break;

                    case 2:
                        Console.WriteLine("Digite o id do pedido que deseja adicionar o item: ");
                        int idPedido = int.Parse(Console.ReadLine());

                        Pedido pedidoEncontrado = restaurante.buscarPedido(idPedido);

                        if (pedidoEncontrado == null)
                        {
                            Console.WriteLine("Pedido não encontrado!");
                        }
                        else
                        {
                            Console.WriteLine("Quantos itens deseja adicionar (Maximo 10)?");
                            int qtdItens = int.Parse(Console.ReadLine());

                            int disponiveis = 10 - pedidoEncontrado.guardaItens();

                            if(qtdItens > disponiveis)
                            {
                                Console.WriteLine($"Só é possivel adicionar {disponiveis} itens!");
                                qtdItens = disponiveis;
                            }

                            for(int i = 0; i < qtdItens; i++)
                            {
                                Console.WriteLine($"Digite o id do {i+1}º item: ");
                                int idItem = int.Parse(Console.ReadLine());

                                Console.WriteLine("Descrição: ");
                                string descItem = Console.ReadLine();

                                Console.WriteLine($"Informe o valor do {i+1}º item: ");
                                double valorItem = double.Parse(Console.ReadLine());

                                Item item = new Item(idItem, descItem, valorItem);

                                if (pedidoEncontrado.adicionarItem(item))
                                {
                                    Console.WriteLine("Item adicionado com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Não foi possível adicionar. O pedido já atingiu o limite de 10 itens.");
                                }
                            }
                        }
                        break;


                    case 3:
                        Console.WriteLine("Digite o id do pedido que deseja excluir o item: ");
                        int idPedidoDel = int.Parse(Console.ReadLine());

                        Pedido pedidoDel = restaurante.buscarPedido(idPedidoDel);

                        if(pedidoDel == null)
                        {
                            Console.WriteLine("Pedido não encontrado!");
                        }

                        Console.WriteLine("Digite o id do item que deseja excluir: ");
                        int idItemDel = int.Parse(Console.ReadLine());

                        bool itemRemovido = pedidoDel.removerItem(new Item(idItemDel));

                        Console.WriteLine(itemRemovido ? "Item removido!" : "Não foi possivel remover o item!");
                        break;


                    case 4:
                        Console.WriteLine("Digite o id do pedido: ");
                        int idConsultaPedido = int.Parse(Console.ReadLine());

                        Pedido achouPedido = restaurante.buscarPedido(idConsultaPedido);

                        if(achouPedido != null && achouPedido.Id != -1)
                        {
                            Console.WriteLine($"Id: {achouPedido.Id}");
                            Console.WriteLine($"Cliente: {achouPedido.Cliente}");
                            Console.WriteLine($"Quantidade de itens: {achouPedido.guardaItens()}");
                            Console.WriteLine($"Total: {achouPedido.calcularTotal()}");
                        }
                        else
                        {
                            Console.WriteLine("Pedido não encontrado!");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Informe o id do pedido que deseja cancelar: ");
                        int idPedidoCancela = int.Parse(Console.ReadLine());

                        bool pedidoCancela = restaurante.cancelarPedido(new Pedido(idPedidoCancela));
                        Console.WriteLine(pedidoCancela ? "Pedido cancelado!" : "Não foi possivel cancelar o pedido!");
                        break;


                    case 6:
                        Console.WriteLine("\n---- Lista de todos os pedidos -----");
                        double totalDoDia = 0;
                        bool temPedido = false;

                        foreach (var p in restaurante.Pedidos) 
                        {
                            if (p != null)
                            {
                                temPedido = true;
                                double totalPedido = p.calcularTotal();
                                Console.WriteLine($"Pedido ID: {p.Id} | Cliente: {p.Cliente} | Total: R${totalPedido:F2}");
                                totalDoDia += totalPedido;
                            }
                        }

                        if (!temPedido)
                        {
                            Console.WriteLine("Nenhum pedido realizado hoje!");
                        }
                        else
                        {
                            Console.WriteLine($"\n==== TOTAL DO DIA: R${totalDoDia:F2} ====");
                        }
                        break;
                }
            }
            while (opcao != 0);
        }
    }
}
