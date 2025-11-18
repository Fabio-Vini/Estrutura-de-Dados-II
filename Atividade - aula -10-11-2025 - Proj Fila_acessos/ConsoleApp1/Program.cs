using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cadastro cadastro = new Cadastro();


            int opcao;

            do
            {
                Console.WriteLine("====================================");
                Console.WriteLine("   SISTEMA DE ACESSO - MENU");
                Console.WriteLine("====================================");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Cadastrar ambiente");
                Console.WriteLine("2. Consultar ambiente");
                Console.WriteLine("3. Excluir ambiente");
                Console.WriteLine("4. Cadastrar usuário");
                Console.WriteLine("5. Consultar usuário");
                Console.WriteLine("6. Excluir usuário");
                Console.WriteLine("7. Conceder permissão (usuário + ambiente)");
                Console.WriteLine("8. Revogar permissão (usuário + ambiente)");
                Console.WriteLine("9. Registrar acesso (usuário tenta acessar ambiente)");
                Console.WriteLine("10. Consultar logs (ambiente)");
                Console.WriteLine("====================================");
                Console.Write("Escolha uma opção: ");

                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opcao)
                {
                    case 1:
                        CadastrarAmbiente(cadastro);
                        break;

                    case 2:
                        ConsultarAmbiente(cadastro);
                        break;

                    case 3:
                        ExcluirAmbiente(cadastro);
                        break;

                    case 4:
                        CadastrarUsuario(cadastro);
                        break;

                    case 5:
                        ConsultarUsuario(cadastro);
                        break;

                    case 6:
                        ExcluirUsuario(cadastro);
                        break;

                    case 7:
                        ConcederPermissao(cadastro);
                        break;

                    case 8:
                        RevogarPermissao(cadastro);
                        break;

                    case 9:
                        RegistrarAcesso(cadastro);
                        break;

                    case 10:
                        ConsultarLogs(cadastro);
                        break;

                    case 0:
                        Console.WriteLine("Salvando dados...");
                        cadastro.Upload();
                        Console.WriteLine("Encerrado.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine();

            } while (opcao != 0);
        }

        // ==================================================
        // FUNÇÕES DO MENU
        // ==================================================

        static void CadastrarAmbiente(Cadastro cad)
        {
            Console.Write("ID do ambiente: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nome do ambiente: ");
            string nome = Console.ReadLine();

            cad.AdicionarAmbiente(new Ambiente(id, nome));
            Console.WriteLine("Ambiente cadastrado!");
        }

        static void ConsultarAmbiente(Cadastro cad)
        {
            Console.Write("Informe o ID: ");
            int id = int.Parse(Console.ReadLine());

            var ambiente = cad.PesquisarAmbiente(new Ambiente(id, ""));

            if (ambiente == null)
            {
                Console.WriteLine("Ambiente não encontrado!");
                return;
            }

            Console.WriteLine($"ID: {ambiente.Id}");
            Console.WriteLine($"Nome: {ambiente.Nome}");
        }

        static void ExcluirAmbiente(Cadastro cad)
        {
            Console.Write("ID do ambiente: ");
            int id = int.Parse(Console.ReadLine());

            var ambiente = cad.PesquisarAmbiente(new Ambiente(id, ""));

            if (ambiente == null)
            {
                Console.WriteLine("Ambiente não encontrado!");
                return;
            }

            if (cad.RemoverAmbiente(ambiente))
                Console.WriteLine("Ambiente removido.");
            else
                Console.WriteLine("Falha ao remover.");
        }

        static void CadastrarUsuario(Cadastro cad)
        {
            Console.Write("ID do usuário: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nome do usuário: ");
            string nome = Console.ReadLine();

            cad.AdicionarUsuario(new Usuario(id, nome));

            Console.WriteLine("Usuário cadastrado!");
        }

        static void ConsultarUsuario(Cadastro cad)
        {
            Console.Write("ID do usuário: ");
            int id = int.Parse(Console.ReadLine());

            var usuario = cad.PesquisarUsuario(new Usuario(id, ""));

            if (usuario == null)
            {
                Console.WriteLine("Usuário não encontrado!");
                return;
            }

            Console.WriteLine($"ID: {usuario.Id}");
            Console.WriteLine($"Nome: {usuario.Nome}");

            Console.WriteLine("Permissões:");
            foreach (var a in usuario.GetPermissoes())
            {
                Console.WriteLine($"- {a.Nome}");
            }
        }

        static void ExcluirUsuario(Cadastro cad)
        {
            Console.Write("ID do usuário: ");
            int id = int.Parse(Console.ReadLine());

            var usuario = cad.PesquisarUsuario(new Usuario(id, ""));

            if (usuario == null)
            {
                Console.WriteLine("Usuário não encontrado!");
                return;
            }

            if (cad.RemoverUsuario(usuario))
                Console.WriteLine("Usuário removido.");
            else
                Console.WriteLine("Usuário não pode ser removido (possui permissões).");
        }

        static void ConcederPermissao(Cadastro cad)
        {
            Console.Write("ID do usuário: ");
            int idU = int.Parse(Console.ReadLine());

            Console.Write("ID do ambiente: ");
            int idA = int.Parse(Console.ReadLine());

            var usuario = cad.PesquisarUsuario(new Usuario(idU, ""));
            var ambiente = cad.PesquisarAmbiente(new Ambiente(idA, ""));

            if (usuario == null || ambiente == null)
            {
                Console.WriteLine("Usuário ou ambiente não encontrado!");
                return;
            }

            if (usuario.ConcederPermissao(ambiente))
                Console.WriteLine("Permissão concedida!");
            else
                Console.WriteLine("Usuário já tem essa permissão.");
        }

        static void RevogarPermissao(Cadastro cad)
        {
            Console.Write("ID do usuário: ");
            int idU = int.Parse(Console.ReadLine());

            Console.Write("ID do ambiente: ");
            int idA = int.Parse(Console.ReadLine());

            var usuario = cad.PesquisarUsuario(new Usuario(idU, ""));
            var ambiente = cad.PesquisarAmbiente(new Ambiente(idA, ""));

            if (usuario == null || ambiente == null)
            {
                Console.WriteLine("Usuário ou ambiente não encontrado!");
                return;
            }

            if (usuario.RevogarPermissao(ambiente))
                Console.WriteLine("Permissão removida!");
            else
                Console.WriteLine("Usuário não tinha essa permissão.");
        }

        static void RegistrarAcesso(Cadastro cad)
        {
            Console.Write("ID do usuário: ");
            int idU = int.Parse(Console.ReadLine());

            Console.Write("ID do ambiente: ");
            int idA = int.Parse(Console.ReadLine());

            var usuario = cad.PesquisarUsuario(new Usuario(idU, ""));
            var ambiente = cad.PesquisarAmbiente(new Ambiente(idA, ""));

            if (usuario == null || ambiente == null)
            {
                Console.WriteLine("Usuário ou ambiente não encontrado!");
                return;
            }

            bool autorizado = usuario.GetPermissoes().Contains(ambiente);

            ambiente.RegistrarLog(new Log(usuario, autorizado));

            Console.WriteLine(autorizado ? "Acesso AUTORIZADO" : "Acesso NEGADO");
        }

        static void ConsultarLogs(Cadastro cad)
        {
            Console.Write("ID do ambiente: ");
            int id = int.Parse(Console.ReadLine());

            var ambiente = cad.PesquisarAmbiente(new Ambiente(id, ""));

            if (ambiente == null)
            {
                Console.WriteLine("Ambiente não encontrado!");
                return;
            }

            Console.WriteLine($"Logs do ambiente: {ambiente.Nome}");

            foreach (var log in ambiente.GetLogs())
            {
                Console.WriteLine($"{log.DtAcesso} - Usuário: {log.Usuario.Nome} - {(log.TipoAcesso ? "AUTORIZADO" : "NEGADO")}");
            }
        }
    }
}
