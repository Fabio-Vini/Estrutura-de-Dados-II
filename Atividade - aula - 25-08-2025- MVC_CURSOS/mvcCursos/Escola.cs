using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcCursos
{
    internal class Escola
    {
        private Curso[] cursos = new Curso[5];

        public bool adicionarCurso(Curso curso)
        {
            for(int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] == null)
                {
                    cursos[i] = curso;
                    return true;
                }
            }
            return false;
        }

        public Curso pesquisarCurso(int id)
        {
            foreach (Curso c in this.cursos)
            {
                if (c != null && c.Id == id)
                {
                    return c;
                }
            }
            return null;
        }
        public bool removerCurso(Curso curso)
        {
            for(int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] != null && cursos[i].Id == curso.Id)
                {
                    //Verificando se o curso tem disciplinas associadas
                    if (cursos[i].guardaDisciplinas() > 0)
                    {
                        Console.WriteLine("Não é possivel excluir este curso, há disciplinas associadas a ele!");
                        return false;
                    }

                    cursos[i] = null;
                    return true;
                }
            }

            Console.WriteLine("Curso não encontrado.");
            return false;
        }

        public bool disciplinaExiste(int idDisciplina)
        {
            foreach (Curso c in cursos)
            {
                if (c != null)
                {
                    foreach (Disciplina d in c.guardarArrayDisciplinas()) // método que retorna o array de disciplinas
                    {
                        if (d != null && d.Id == idDisciplina)
                        {
                            return true; // já existe
                        }
                    }
                }
            }
            return false; // não existe
        }

        public Curso[] Cursos
        {
            get { return cursos; }
        }

        public (Aluno, List<Disciplina>) pesquisarAluno(int id)
        {
            Aluno alunoEncontrado = null;
            List<Disciplina> disciplinasAluno = new List<Disciplina>();

            foreach (Curso c in this.cursos)
            {
                if (c != null)
                {
                    foreach (Disciplina d in c.guardarArrayDisciplinas())
                    {
                        if (d != null)
                        {
                            foreach (Aluno a in d.guardarArrayAlunos())
                            {
                                if (a != null && a.Id == id)
                                {
                                    alunoEncontrado = a;       // já temos o aluno
                                    disciplinasAluno.Add(d);   // adiciona a disciplina
                                }
                            }
                        }
                    }
                }
            }

            if (alunoEncontrado != null)
                return (alunoEncontrado, disciplinasAluno);

            return (null, null); // não encontrou
        }

        //Teste
        /* public void listarCursos()
         {
             Console.WriteLine("\nCursos cadastrados:");
             foreach (Curso c in cursos)
             {
                 if (c != null)
                 {
                     Console.WriteLine($"ID: {c.Id}, Nome: {c.Descricao}");
                 }
             }
         }*/
    }
}
