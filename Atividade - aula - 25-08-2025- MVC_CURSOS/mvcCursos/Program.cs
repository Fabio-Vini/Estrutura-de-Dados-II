using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcCursos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Escola escola = new Escola();
            int opcao = -1;

            do
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Adicionar curso");
                Console.WriteLine("2 - Pesquisar curso");
                Console.WriteLine("3 - Remover curso");
                Console.WriteLine("4 - Adicionar disciplina ao curso");
                Console.WriteLine("5 - Pesquisar disciplina");
                Console.WriteLine("6 - Remover disciplina do curso");
                Console.WriteLine("7 - Matricular aluno na disciplina");
                Console.WriteLine("8 - Remover aluno da disciplina");
                Console.WriteLine("9 - Pesquisar aluno");
                Console.Write("Opção: ");

                if(!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        for(int i = 0; i < 5; i++)
                        {
                            Console.WriteLine("Digite o ID do curso: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.WriteLine("Descrição do curso: ");
                            string descricao = Console.ReadLine();

                            Curso curso = new Curso(id, descricao);

                            if (escola.adicionarCurso(curso))
                            {
                                Console.WriteLine("Curso adicionado com sucesso!\n");
                            }
                            else
                            {
                                Console.WriteLine("Não foi possível adicionar, lista cheia.\n");
                                break;
                            }
                            /*escola.listarCursos();*/
                        }
                        break;

                    case 2:
                        Console.WriteLine("Digite o Id do curso: ");
                        int Idpesqu = int.Parse(Console.ReadLine());
                        Curso achado = escola.pesquisarCurso(Idpesqu);

                        if(achado != null && achado.Id != -1)
                        {
                            Console.WriteLine($"\nId: {achado.Id}");
                            Console.WriteLine($"\nDescrição: {achado.Descricao}");
                            Console.WriteLine($"Disciplinas {achado.guardaDisciplinas()}");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Id do curso a ser excluido: ");
                        int idDel = int.Parse(Console.ReadLine());

                        bool removido = escola.removerCurso(new Curso(idDel));
                        Console.WriteLine(removido ? "Curso removido!" : "Curso não encontrado!");
                        break;

                    case 4:
                        Console.WriteLine("Digite o ID do curso que deseja adicionar a disciplina: ");
                        int idCurso = int.Parse(Console.ReadLine());

                        Curso cursoEncontrado = escola.pesquisarCurso(idCurso);

                        if(cursoEncontrado == null)
                        {
                            Console.WriteLine("Curso não encontrado!");
                        }
                        else
                        {
                            Console.WriteLine("Quantas disciplinas deseja adicionar (máximo 12): ");
                            int qtdDisciplinas = int.Parse(Console.ReadLine());

                            int disponiveis = 12 - cursoEncontrado.guardaDisciplinas();

                            if(qtdDisciplinas > disponiveis)
                            {
                                Console.WriteLine($"Só é possivel adicionar {disponiveis} disciplinas!");
                                qtdDisciplinas = disponiveis;   
                            }

                            for(int i = 0; i < qtdDisciplinas; i++ )
                            {
                                Console.WriteLine("Digite o ID da disciplina: ");
                                int idDisciplina = int.Parse(Console.ReadLine());

                                if (escola.disciplinaExiste(idDisciplina))
                                {
                                    Console.WriteLine("Já existe uma disciplina com esse ID em outro curso! Digite outro ID.");
                                    i--; // repete essa iteração
                                    continue;
                                }

                                Console.WriteLine("Descrição da disciplina: ");
                                string descDisciplina = Console.ReadLine();

                                Disciplina disciplina = new Disciplina(idDisciplina, descDisciplina);

                                if (cursoEncontrado.adicionarDisciplina(disciplina))
                                {
                                    Console.WriteLine("Disciplina adicionada com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Não foi possível adicionar. O curso já atingiu o limite de 12 disciplinas.");
                                }
                            }
                        }
                        break;

                    case 5:
                        Console.WriteLine("Digite o Id da disciplina: ");
                        int IdpesquDisciplina = int.Parse(Console.ReadLine());
                        Disciplina achouDisciplina = null;

                        foreach (Curso c in escola.Cursos) 
                        {
                            achouDisciplina = c.pesquisarDisciplina(IdpesquDisciplina);
                            if (achouDisciplina != null)
                                break;
                        }

                        if (achouDisciplina != null)
                        {
                            Console.WriteLine($"\nId: {achouDisciplina.Id}");
                            Console.WriteLine($"Descrição: {achouDisciplina.Descricao}");
                        }
                        else
                        {
                            Console.WriteLine("Disciplina não encontrada.");
                        }
                        break;

                    case 6:
                        Console.WriteLine("Digite o ID do curso onde está a disciplina: ");
                        int idCursoDel = int.Parse(Console.ReadLine());

                        Curso cursoDel = escola.pesquisarCurso(idCursoDel);

                        if (cursoDel == null)
                        {
                            Console.WriteLine("Curso não encontrado!");
                            break;
                        }

                        Console.WriteLine("Digite o ID da disciplina a ser excluída: ");
                        int idDisciplinaDel = int.Parse(Console.ReadLine());

                        bool removida = cursoDel.removerDisciplina(new Disciplina(idDisciplinaDel));

                        Console.WriteLine(removida
                            ? "Disciplina removida!"
                            : "Disciplina não encontrada ou não pode ser excluída (há alunos matriculados).");
                        break;


                    case 7:
                        Console.WriteLine("Digite o ID do curso: ");
                        int idCursoMat = int.Parse(Console.ReadLine());
                        Curso cursoMat = escola.pesquisarCurso(idCursoMat);

                        if (cursoMat == null)
                        {
                            Console.WriteLine("Curso não encontrado!");
                            break;
                        }

                        Console.WriteLine("Digite o ID da disciplina: ");
                        int idDiscMat = int.Parse(Console.ReadLine());
                        Disciplina disciplinaMat = cursoMat.pesquisarDisciplina(idDiscMat);

                        if (disciplinaMat == null)
                        {
                            Console.WriteLine("Disciplina não encontrada!");
                            break;
                        }

                        Console.WriteLine("Digite o ID do aluno: ");
                        int idAluno = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o nome do aluno: ");
                        string nomeAluno = Console.ReadLine();

                        Aluno aluno = new Aluno(idAluno, nomeAluno);

                        if (disciplinaMat.matricularAluno(aluno))
                        {
                            Console.WriteLine("Aluno matriculado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível matricular. A disciplina já tem 15 alunos.");
                        }
                        break;

                    case 8:
                        Console.WriteLine("Digite o ID do curso: ");
                        int idCursoDesmat = int.Parse(Console.ReadLine());
                        Curso cursoDesmat = escola.pesquisarCurso(idCursoDesmat);

                        if (cursoDesmat == null)
                        {
                            Console.WriteLine("Curso não encontrado!");
                            break;
                        }

                        Console.WriteLine("Digite o ID da disciplina: ");
                        int idDiscDesmat = int.Parse(Console.ReadLine());
                        Disciplina discDesmat = cursoDesmat.pesquisarDisciplina(idDiscDesmat);

                        if (discDesmat == null)
                        {
                            Console.WriteLine("Disciplina não encontrada!");
                            break;
                        }

                        Console.WriteLine("Digite o ID do aluno a ser desmatriculado: ");
                        int idAlunoDesmat = int.Parse(Console.ReadLine());
                        Aluno alunoDesmat = discDesmat.pesquisarAluno(idAlunoDesmat);

                        if (alunoDesmat == null)
                        {
                            Console.WriteLine("Aluno não encontrado na disciplina!");
                            break;
                        }

                        if (discDesmat.desmatricularAluno(alunoDesmat))
                        {
                            Console.WriteLine("Aluno desmatriculado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível desmatricular o aluno.");
                        }
                        break;

                    case 9:
                        Console.WriteLine("Digite o Id do aluno: ");
                        int IdpesquAluno = int.Parse(Console.ReadLine());

                        var resultado = escola.pesquisarAluno(IdpesquAluno);
                        Aluno achouAluno = resultado.Item1;
                        List<Disciplina> disciplinasAluno = resultado.Item2;

                        if (achouAluno != null)
                        {
                            Console.WriteLine($"\nId: {achouAluno.Id}");
                            Console.WriteLine($"Nome: {achouAluno.Nome}");

                            Console.WriteLine("Disciplinas em que está matriculado:");
                            foreach (Disciplina d in disciplinasAluno)
                            {
                                Console.WriteLine($" - {d.Descricao}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Aluno não encontrado!");
                        }
                        break;
                }






            } while (opcao != 0);
        }
    }
}
