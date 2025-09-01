using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vendedores vendedores = new Vendedores(10); // limite de 10
            int opcao = -1;

            do
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Cadastrar vendedor");
                Console.WriteLine("2 - Consultar vendedor");
                Console.WriteLine("3 - Excluir vendedor");
                Console.WriteLine("4 - Registrar venda");
                Console.WriteLine("5 - Listar vendedores");
                Console.Write("Opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida.");
                    continue;
                }

                switch (opcao)
                {
                    case 1: // Cadastrar vendedor
                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Percentual de comissão (ex: 0,1 para 10%): ");
                        double perc = double.Parse(Console.ReadLine().Replace(',', '.'));

                        Vendedor novo = new Vendedor(id, nome, perc);
                        if (vendedores.addVendedor(novo))
                            Console.WriteLine("Vendedor cadastrado!");
                        else
                            Console.WriteLine("Limite de 10 vendedores atingido.");
                        break;

                    case 2: // Consultar vendedor
                        Console.Write("ID do vendedor: ");
                        int idCons = int.Parse(Console.ReadLine());
                        Vendedor achado = vendedores.pesqVendedor(new Vendedor(idCons));

                        if (achado != null && achado.Id != -1)
                        {
                            Console.WriteLine($"\nID: {achado.Id}");
                            Console.WriteLine($"Nome: {achado.Nome}");
                            Console.WriteLine($"Comissão: {achado.PercComissao:P2}");
                            Console.WriteLine($"Total de vendas: {achado.valorVendas():C2}");
                            Console.WriteLine($"Total de comissão: {achado.valorComissao():C2}");
                        }
                        else
                        {
                            Console.WriteLine("Vendedor não encontrado.");
                        }
                        break;

                    case 3: // Excluir vendedor
                        Console.Write("ID do vendedor a excluir: ");
                        int idDel = int.Parse(Console.ReadLine());
                        bool removido = vendedores.delVendedor(new Vendedor(idDel));
                        Console.WriteLine(removido ? "Vendedor removido." : "Vendedor não encontrado.");
                        break;

                    case 4: // Registrar venda
                        Console.Write("ID do vendedor: ");
                        int idVend = int.Parse(Console.ReadLine());
                        Vendedor vend = vendedores.pesqVendedor(new Vendedor(idVend));

                        if (vend != null && vend.Id != -1)
                        {
                            Console.Write("Dia da venda (1 a 31): ");
                            int dia = int.Parse(Console.ReadLine());
                            Console.Write("Quantidade: ");
                            int qtde = int.Parse(Console.ReadLine());
                            Console.Write("Valor total da venda: ");
                            double valor = double.Parse(Console.ReadLine().Replace(',', '.'));

                            Venda venda = new Venda { Qtde = qtde, Valor = valor };
                            bool ok = vend.registrarVenda(dia, venda);
                            Console.WriteLine(ok ? "Venda registrada!" : "Dia inválido (use 1 a 31).");
                        }
                        else
                        {
                            Console.WriteLine("Vendedor não encontrado.");
                        }
                        break;

                    case 5: // Listar vendedores
                        if (vendedores.Qtde == 0)
                        {
                            Console.WriteLine("Nenhum vendedor cadastrado.");
                        }
                        else
                        {
                            Console.WriteLine("\n--- Vendedores ---");
                            for (int i = 0; i < vendedores.Qtde; i++)
                            {
                                Vendedor v = vendedores.OsVendedores[i];
                                if (v != null)
                                    Console.WriteLine($"{v.Id} - {v.Nome} (Comissão: {v.PercComissao:P2})");
                            }
                        }
                        break;

                    case 0:
                        Console.WriteLine("Encerrando...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (opcao != 0);
        }
    }
}
