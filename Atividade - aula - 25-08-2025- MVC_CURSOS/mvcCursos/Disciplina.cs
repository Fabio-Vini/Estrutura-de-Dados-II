using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcCursos
{
    internal class Disciplina
    {
        private int id;
        private string descricao;
        private Aluno[] alunos = new Aluno[15];

        public int Id { get { return id; } }
        public string Descricao { get { return descricao; } set { descricao = value; } }

        //Construtor
        public Disciplina(int id, string descricao)
        {
            this.id = id;
            this.Descricao = descricao;
        }
        public bool matricularAluno(Aluno aluno)
        {
            for(int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] == null)
                {
                    alunos[i] = aluno;
                    return true;
                }
            }
            return false;
        }

        public bool desmatricularAluno(Aluno aluno)
        {
            for(int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] != null && alunos[i].Id == aluno.Id)
                {
                    alunos[i] = null;
                    return true;
                }
            }
            Console.WriteLine("Aluno não encontrado");
            return false;
        }

        public int guardaAluno()
        {
            int qtdAluno = 0;
            Console.WriteLine("\nNome: ");
            foreach(Aluno a in alunos)
            {
                if(a != null)
                {
                    Console.WriteLine($" - {a.Nome}");
                    qtdAluno++;
                }
            }
            if (qtdAluno == 0)
            {
                Console.WriteLine("Nenhuma disciplina associada!");
            }

            return qtdAluno;
        }

        public Aluno pesquisarAluno(int id)
        {
            foreach (Aluno a in this.alunos)
            {
                if (a != null && a.Id == id)
                    return a;
            }
            return null;
        }

        public Aluno[] guardarArrayAlunos()
        {
            return alunos;
        }

        public Disciplina(int id) : this(id, "")
        {
        }
        public Disciplina() : this(-1, "")
        {
        }
    }
}
