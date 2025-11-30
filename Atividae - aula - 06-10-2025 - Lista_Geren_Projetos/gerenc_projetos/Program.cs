using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gerenc_projetos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Projetos sistema = new Projetos();
            int opcao;

            do
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar projeto");
                Console.WriteLine("2. Pesquisar projeto");
                Console.WriteLine("3. Remover projeto (apenas sem tarefas)");
                Console.WriteLine("4. Adicionar tarefa em projeto");
                Console.WriteLine("5. Concluir tarefa");
                Console.WriteLine("6. Cancelar tarefa");
                Console.WriteLine("7. Reabrir tarefa");
                Console.WriteLine("8. Listar tarefas de um projeto");
                Console.WriteLine("9. Filtrar tarefas por status ou prioridade - em um projeto");
                Console.WriteLine("10. Filtrar tarefas por status ou prioridade - em TODOS os projetos");
                Console.WriteLine("11. Resumo geral");
                Console.Write("Escolha: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("ID do projeto: ");
                        int pid = int.Parse(Console.ReadLine());
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();

                        if (sistema.Adicionar(new Projeto(pid, nome)))
                            Console.WriteLine("Projeto adicionado!");
                        else
                            Console.WriteLine("ID já existe.");
                        break;

                    case 2:
                        Console.Write("ID do projeto: ");
                        pid = int.Parse(Console.ReadLine());
                        var proj = sistema.Buscar(pid);
                        if (proj == null)
                            Console.WriteLine("Projeto não encontrado.");
                        else
                            Console.WriteLine($"Projeto: {proj.Nome} | Tarefas: {proj.Tarefas.Count}");
                        break;

                    case 3:
                        Console.Write("ID do projeto: ");
                        pid = int.Parse(Console.ReadLine());
                        Console.WriteLine(sistema.Remover(pid) ? "Removido." : "Não é possível remover.");
                        break;

                    case 4:
                        Console.Write("ID do projeto: ");
                        pid = int.Parse(Console.ReadLine());
                        proj = sistema.Buscar(pid);

                        if (proj == null)
                        {
                            Console.WriteLine("Projeto não existe.");
                            break;
                        }

                        Console.Write("ID da tarefa: ");
                        int tid = int.Parse(Console.ReadLine());

                        Console.Write("Título: ");
                        string titulo = Console.ReadLine();

                        Console.Write("Descrição: ");
                        string desc = Console.ReadLine();

                        Console.Write("Prioridade (1=Alta,2=Média,3=Baixa): ");
                        int pri = int.Parse(Console.ReadLine());

                        proj.AdicionarTarefa(new Tarefa(tid, titulo, desc, pri));
                        Console.WriteLine("Tarefa adicionada!");
                        break;

                    case 5:
                        Console.Write("ID projeto: ");
                        pid = int.Parse(Console.ReadLine());
                        proj = sistema.Buscar(pid);

                        Console.Write("ID tarefa: ");
                        tid = int.Parse(Console.ReadLine());

                        proj.BuscarTarefa(tid)?.Concluir();
                        Console.WriteLine("Tarefa concluída!");
                        break;

                    case 6:
                        Console.Write("ID projeto: ");
                        pid = int.Parse(Console.ReadLine());
                        proj = sistema.Buscar(pid);

                        Console.Write("ID tarefa: ");
                        tid = int.Parse(Console.ReadLine());

                        proj.BuscarTarefa(tid)?.Cancelar();
                        Console.WriteLine("Tarefa cancelada!");
                        break;

                    case 7:
                        Console.Write("ID projeto: ");
                        pid = int.Parse(Console.ReadLine());
                        proj = sistema.Buscar(pid);

                        Console.Write("ID tarefa: ");
                        tid = int.Parse(Console.ReadLine());

                        proj.BuscarTarefa(tid)?.Reabrir();
                        Console.WriteLine("Tarefa reaberta!");
                        break;

                    case 8:
                        Console.Write("ID projeto: ");
                        pid = int.Parse(Console.ReadLine());
                        proj = sistema.Buscar(pid);

                        foreach (var t in proj.Tarefas)
                            Console.WriteLine(t);
                        break;

                    case 9:
                        Console.Write("ID projeto: ");
                        pid = int.Parse(Console.ReadLine());
                        proj = sistema.Buscar(pid);

                        Console.Write("Filtrar por (status/prioridade): ");
                        string filtro = Console.ReadLine();

                        if (filtro == "status")
                        {
                            Console.Write("Status: ");
                            string st = Console.ReadLine();
                            proj.TarefasPorStatus(st).ForEach(Console.WriteLine);
                        }
                        else
                        {
                            Console.Write("Prioridade (1-3): ");
                            int p = int.Parse(Console.ReadLine());
                            proj.TarefasPorPrioridade(p).ForEach(Console.WriteLine);
                        }
                        break;

                    case 10:
                        Console.Write("Filtrar por (status/prioridade): ");
                        string f = Console.ReadLine();

                        if (f == "status")
                        {
                            Console.Write("Status: ");
                            string st = Console.ReadLine();
                            foreach (var p in sistema.Itens)
                                p.TarefasPorStatus(st).ForEach(Console.WriteLine);
                        }
                        else
                        {
                            Console.Write("Prioridade (1-3): ");
                            int p = int.Parse(Console.ReadLine());
                            foreach (var pr in sistema.Itens)
                                pr.TarefasPorPrioridade(p).ForEach(Console.WriteLine);
                        }
                        break;

                    case 11:
                        int totalProj = sistema.Itens.Count;
                        int totalAbertas = sistema.Itens.Sum(p => p.TotalAbertas());
                        int totalFechadas = sistema.Itens.Sum(p => p.TotalFechadas());

                        double perc = totalFechadas == 0 ? 0 :
                            (double)totalFechadas / (totalAbertas + totalFechadas) * 100;

                        Console.WriteLine($"Projetos: {totalProj}");
                        Console.WriteLine($"Abertas: {totalAbertas}");
                        Console.WriteLine($"Fechadas: {totalFechadas}");
                        Console.WriteLine($"% Concluídas: {perc:F1}%");
                        break;
                }

            } while (opcao != 0);
        }
    }
}
