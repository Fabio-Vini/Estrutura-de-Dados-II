using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcCursos
{
    internal class Aluno
    {
        private int id;
        private string nome;
        private Curso cursoMatriculado;

        public int Id { get { return id; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public Curso CursoMatriculado { get { return cursoMatriculado; } }

        //Construtor
        public Aluno(int id, string nome)
        {
            this.id = id;
            this.Nome = nome;
        }

        public bool podeMatricular(Curso cursos)
        {
            if(cursoMatriculado == null)
            {
                cursoMatriculado = cursos;
                return true;
            }

            if(cursoMatriculado != cursos)
                return false;

            int qtdCurso = 0;
            foreach(Disciplina d in cursos.guardarArrayDisciplinas())
            {
                if(d != null)
                {
                    foreach(Aluno a in d.guardarArrayAlunos())
                    {
                        if(a != null && a.Id == this.Id)
                        {
                            qtdCurso++;
                        }
                    }
                }
            }

            return qtdCurso < 6;
        }

        public Aluno(int id) : this(id, "")
        {
        }
        public Aluno() : this(-1, "")
        {
        }
    }
}
