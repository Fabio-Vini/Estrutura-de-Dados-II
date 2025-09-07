using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcCursos
{
    internal class Curso
    {
        private int id;
        private string descricao;
        private Disciplina[] disciplinas  = new Disciplina[12];

        public int Id { get { return id; } }
        public string Descricao { get { return descricao; } set { descricao = value; } }

        //Construtor
        public Curso(int id, string descricao)
        {
            this.id = id;
            this.Descricao = descricao;
        }

        public bool adicionarDisciplina(Disciplina disciplina)
        {
            for(int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] == null)
                {
                    disciplinas[i] = disciplina;
                    return true;
                }
            }
            return false;
        }
        public Disciplina pesquisarDisciplina(int id)
        {
            foreach(Disciplina d in disciplinas)
            {
                if(d != null && d.Id == id)
                {

                    return d;
                }
            }
            return null;
        }
        public bool removerDisciplina(Disciplina disciplina)
        {
            for(int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] != null && disciplinas[i].Id == disciplina.Id)
                {
                    //Verificar se nao tem aluno nessa disciplina
                    if (disciplinas[i].guardaAluno() > 0)
                    {
                        Console.WriteLine("Não é possivel excluir esta disciplina, há alunnos matriculados nele!");
                        return false;
                    }

                    disciplinas[i] = null;
                    return true;
                }
            }

            Console.WriteLine("Disciplina não encontrada!");
            return false;
        }

        public int guardaDisciplinas()
        {
            int qtd = 0;
            Console.WriteLine("\nDisciplinas associadas: ");
            foreach (Disciplina d in disciplinas)
            {
                if (d != null)
                {
                    Console.WriteLine($" - {d.Descricao}");
                    qtd++;
                }
            }

            if (qtd == 0)
            {
                Console.WriteLine("Nenhuma disciplina associada!");
            }

            return qtd;
        }

        public Curso(int id) : this(id, "")
        {
        }
        public Curso() : this(-1, "")
        {
        }

        public Disciplina[] guardarArrayDisciplinas()
        {
            return disciplinas;
        }
    }
}
