using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listaBiblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Livros biblioteca = new Livros();
            int opcao;

            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("| 0. Sair                            |");
                Console.WriteLine("| 1. Adicionar livro                 |");
                Console.WriteLine("| 2. Pesquisar livro (sintético)     |");
                Console.WriteLine("| 3. Pesquisar livro (analítico)     |");
                Console.WriteLine("| 4. Adicionar exemplar              |");
                Console.WriteLine("| 5. Registrar empréstimo            |");
                Console.WriteLine("| 6. Registrar devolução             |");
                Console.WriteLine("--------------------------------------");
                Console.Write("Escolha uma opção: ");

                if(!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                Console.WriteLine();

                switch (opcao) 
                {
                    case 1:
                        AdicionarLivro(biblioteca);
                        break;
                    case 2:
                        PesquisarLivroSintetico(biblioteca);
                        break;
                    case 3:
                        PesquisarLivroAnalitico(biblioteca);
                        break;
                    case 4:
                        AdicionarExemplar(biblioteca);
                        break;
                    case 5:
                        RegistrarEmprestimo(biblioteca);
                        break;
                    case 6:
                        RegistrarDevolucao(biblioteca);
                        break;
                    case 0:
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine();

            } while (opcao != 0);
           
        }
        static void AdicionarLivro(Livros biblioteca)
        {
            Console.WriteLine("Informe o ISBN: ");
            int isbn = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o titulo: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Informe o autor/a: ");
            string autor = Console.ReadLine();

            Console.WriteLine("Informe a editora: ");
            string editora = Console.ReadLine();

            Livro livro = new Livro(isbn, titulo, autor, editora);
            biblioteca.adicionar(livro);

            Console.WriteLine("Livro adicionado com sucesso!");
        }

        static void PesquisarLivroSintetico(Livros biblioteca)
        {
            Console.WriteLine("Informe o ISBN: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro livroBusca = new Livro(isbn, "", "", "");
            Livro livroEncontrado = biblioteca.pesquisar(livroBusca);

            if(livroEncontrado != null)
            {
                Console.WriteLine($"\nTítulo: {livroEncontrado.Titulo}");
                Console.WriteLine($"Autor: {livroEncontrado.Autor}");
                Console.WriteLine($"Editora: {livroEncontrado.Editora}");
                Console.WriteLine($"Total de Exemplares: {livroEncontrado.qtdeExemplares()}");
                Console.WriteLine($"Disponíveis: {livroEncontrado.qtdeDisponiveis()}");
                Console.WriteLine($"Emprestados: {livroEncontrado.qtdeEmprestimos()}");
                Console.WriteLine($"% Disponibilidade: {livroEncontrado.percDisponibilidade():F2}%");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
        static void PesquisarLivroAnalitico(Livros biblioteca)
        {
            Console.WriteLine("Informe o ISBN: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro livroBusca = new Livro(isbn, "", "", "");
            Livro livroEncontrado = biblioteca.pesquisar(livroBusca);

            if(livroEncontrado != null)
            {
                PesquisarLivroSintetico(biblioteca);

                Console.WriteLine("\n--- Detalhes dos Exemplares ---");
                foreach(var ex in livroEncontrado.exemplares)
                {
                    Console.WriteLine($"Tombo: {ex.Tombo} | Disponível: {ex.disponivel()} | Total de Empréstimos: {ex.qtdeEmprestimos()}");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void AdicionarExemplar(Livros biblioteca)
        {
            Console.WriteLine("Informe o ISBN: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro livroBusca = new Livro(isbn, "", "", "");
            Livro livroEncontrado = biblioteca.pesquisar(livroBusca);

            if(livroEncontrado != null)
            {
                int novoTombo = livroEncontrado.qtdeExemplares() + 1;
                Exemplar exemplar = new Exemplar(novoTombo);
                livroEncontrado.adicionarExemplar(exemplar);
                Console.WriteLine("Exemplar adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void RegistrarEmprestimo(Livros biblioteca)
        {
            Console.WriteLine("Informe o ISBN: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro livroBusca = new Livro(isbn, "", "", "");
            Livro livroEncontrado = biblioteca.pesquisar(livroBusca);

            if(livroEncontrado != null)
            {
                Exemplar exemplar = livroEncontrado.exemplares.FirstOrDefault(e => e.disponivel());
                if(exemplar != null && exemplar.emprestar())
                {
                    Console.WriteLine("Empréstimo realizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não há exemplares disponíveis para empréstimo.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void RegistrarDevolucao(Livros biblioteca)
        {
            Console.Write("Informe o ISBN do livro: ");
            if (!int.TryParse(Console.ReadLine(), out int isbn))
            {
                Console.WriteLine("ISBN inválido.");
                return;
            }

            // Cria um objeto Livro apenas para usar no pesquisar(Livro livro)
            Livro livroBusca = new Livro(isbn, "", "", "");
            Livro livro = biblioteca.pesquisar(livroBusca);

            if (livro != null)
            {
                // procura um exemplar que esteja emprestado (ou seja, !disponivel())
                Exemplar exemplar = livro.exemplares.FirstOrDefault(e => !e.disponivel());
                if (exemplar != null && exemplar.devolver())
                {
                    Console.WriteLine("Devolução registrada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não há empréstimos pendentes para este livro.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
    }
}
