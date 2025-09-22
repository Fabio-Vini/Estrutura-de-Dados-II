using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listaAgenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contatos agenda = new Contatos();
            int opcao;

            do
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar contato");
                Console.WriteLine("2. Pesquisar contato");
                Console.WriteLine("3. Alterar contato");
                Console.WriteLine("4. Remover contato");
                Console.WriteLine("5. Listar contatos");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    case 1:
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();

                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        Console.Write("Data de nascimento (dd/mm/aaaa): ");
                        string[] partes = Console.ReadLine().Split('/');
                        Data data = new Data();
                        data.setData(int.Parse(partes[0]), int.Parse(partes[1]), int.Parse(partes[2]));

                        Contato novo = new Contato(nome, email, data);

                        Console.Write("Telefone (tipo): ");
                        string tipo = Console.ReadLine();

                        Console.Write("Telefone (número): ");
                        string numero = Console.ReadLine();

                        Console.Write("É principal? (s/n): ");
                        bool principal = Console.ReadLine().ToLower() == "s";

                        Telefone tel = new Telefone(tipo, numero, principal);
                        novo.adicionarTelefone(tel);

                        if (agenda.adicionar(novo))
                            Console.WriteLine("Contato adicionado com sucesso!");
                        else
                            Console.WriteLine("Contato já existe!");
                        break;

                    case 2:
                        Console.Write("Digite o email do contato a pesquisar: ");
                        string emailPesquisa = Console.ReadLine().Trim(); // remover espaços
                        Contato pesquisa = new Contato("Temp", emailPesquisa, null);

                        Contato encontrado = agenda.pesquisar(pesquisa);
                        if (encontrado != null)
                            Console.WriteLine(encontrado);
                        else
                            Console.WriteLine("Contato não encontrado!");
                        break;

                    case 3:
                        Console.Write("Digite o email do contato a alterar: ");
                        string emailAlterar = Console.ReadLine();
                        Contato contatoAlterar = new Contato("", emailAlterar, new Data());

                        if (agenda.pesquisar(contatoAlterar) != null)
                        {
                            Console.Write("Novo nome: ");
                            string novoNome = Console.ReadLine();

                            Console.Write("Nova data de nascimento (dd/mm/aaaa): ");
                            string[] dataAlt = Console.ReadLine().Split('/');
                            Data novaData = new Data();
                            novaData.setData(int.Parse(dataAlt[0]), int.Parse(dataAlt[1]), int.Parse(dataAlt[2]));

                            Contato atualizado = new Contato(novoNome, emailAlterar, novaData);

                            Console.Write("Novo telefone (tipo): ");
                            string tipoAlt = Console.ReadLine();

                            Console.Write("Novo telefone (número): ");
                            string numeroAlt = Console.ReadLine();

                            Console.Write("É principal? (s/n): ");
                            bool principalAlt = Console.ReadLine().ToLower() == "s";

                            atualizado.adicionarTelefone(new Telefone(tipoAlt, numeroAlt, principalAlt));

                            if (agenda.alterar(atualizado))
                                Console.WriteLine("Contato alterado com sucesso!");
                            else
                                Console.WriteLine("Erro ao alterar contato!");
                        }
                        else
                        {
                            Console.WriteLine("Contato não encontrado!");
                        }
                        break;

                    case 4:
                        Console.Write("Digite o email do contato a remover: ");
                        string emailRemover = Console.ReadLine();
                        Contato remover = new Contato("", emailRemover, new Data());

                        if (agenda.remover(remover))
                            Console.WriteLine("Contato removido!");
                        else
                            Console.WriteLine("Contato não encontrado!");
                        break;

                    case 5:
                        Console.WriteLine("===== Lista de contatos =====");
                        foreach (var contato in agenda.Listar())
                        {
                            Console.WriteLine(contato);
                            Console.WriteLine("-------------------");
                        }
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (opcao != 0);
        }
    }
}
