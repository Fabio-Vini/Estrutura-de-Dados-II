using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fila_medicamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Medicamentos medicamentos = new Medicamentos();
            int opcao;

            do
            {
                Console.WriteLine("\n===== MENU MEDICAMENTOS =====");
                Console.WriteLine("0. Finalizar processo");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento (sintético)");
                Console.WriteLine("3. Consultar medicamento (analítico)");
                Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
                Console.WriteLine("5. Vender medicamento");
                Console.WriteLine("6. Listar medicamentos");
                Console.Write("Escolha: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Laboratório: ");
                        string lab = Console.ReadLine();
                        medicamentos.Adicionar(new Medicamento(id, nome, lab));
                        Console.WriteLine("Medicamento cadastrado!");
                        break;

                    case 2:
                        Console.Write("Informe o ID: ");
                        id = int.Parse(Console.ReadLine());
                        var m = medicamentos.Pesquisar(new Medicamento(id, "", ""));
                        Console.WriteLine(m != null ? m.ToString() : "Não encontrado.");
                        break;

                    case 3:
                        Console.Write("Informe o ID: ");
                        id = int.Parse(Console.ReadLine());
                        m = medicamentos.Pesquisar(new Medicamento(id, "", ""));
                        if (m != null)
                        {
                            Console.WriteLine(m.ToString());
                            m.ListarLotes();
                        }
                        else
                            Console.WriteLine("Medicamento não encontrado.");
                        break;

                    case 4:
                        Console.Write("ID do medicamento: ");
                        id = int.Parse(Console.ReadLine());
                        m = medicamentos.Pesquisar(new Medicamento(id, "", ""));
                        if (m != null)
                        {
                            Console.Write("ID do lote: ");
                            int idLote = int.Parse(Console.ReadLine());
                            Console.Write("Quantidade: ");
                            int qtde = int.Parse(Console.ReadLine());
                            Console.Write("Data de vencimento (dd/mm/yyyy): ");
                            DateTime venc = DateTime.Parse(Console.ReadLine());
                            m.Comprar(new Lote(idLote, qtde, venc));
                            Console.WriteLine("Lote adicionado!");
                        }
                        else
                            Console.WriteLine("Medicamento não encontrado.");
                        break;

                    case 5:
                        Console.Write("ID do medicamento: ");
                        id = int.Parse(Console.ReadLine());
                        m = medicamentos.Pesquisar(new Medicamento(id, "", ""));
                        if (m != null)
                        {
                            Console.Write("Quantidade para vender: ");
                            int qtdeVenda = int.Parse(Console.ReadLine());
                            bool sucesso = m.Vender(qtdeVenda);
                            Console.WriteLine(sucesso ? "Venda realizada!" : "Quantidade insuficiente.");
                        }
                        else
                            Console.WriteLine("Medicamento não encontrado.");
                        break;

                    case 6:
                        medicamentos.ListarTodos();
                        break;

                    case 0:
                        Console.WriteLine("Encerrando...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opcao != 0);
        }
    }
}
