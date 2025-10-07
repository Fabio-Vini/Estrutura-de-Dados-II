using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listaBiblioteca
{
    internal class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> _exemplares = new List<Exemplar>();

        public int Isbn { get {  return isbn; } set {  isbn = value; } }
        public string Titulo { get {  return titulo; } set {  titulo = value; } }
        public string Autor { get {  return autor; } set {  autor = value; } }
        public string Editora { get { return editora;  } set { editora = value; } }
        public List<Exemplar> exemplares { get { return _exemplares; } set { _exemplares = value; } }

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
        }

        public void adicinarExemplar(Exemplar exemplar)
        {
            exemplares.Add(exemplar);
        }

        public int qtdeExemplares()
        {
            return exemplares.Count;
        }

        public int qtdeDisponiveis()
        {
            return exemplares.Count(e => e.disponivel());
        }

        public int qtdeEmprestimos()
        {
            return exemplares.Sum(e => e.qtdeEmprestimos());
        }

        public double percDisponibilidade()
        {
            if(qtdeExemplares() == 0)
            {
                return 0;
            }
            return (double)qtdeDisponiveis() / qtdeExemplares() * 100;
        }
    }
}
