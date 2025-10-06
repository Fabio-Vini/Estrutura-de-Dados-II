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
        List<Exemplar> exemplares = new List<Exemplar>();

        public int Isbn { get {  return isbn; } set {  isbn = value; } }
        public string Titulo { get {  return titulo; } set {  titulo = value; } }
        public string Autor { get {  return autor; } set {  autor = value; } }
        public string Editora { get { return editora;  } set { editora = value; } }

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
        }

        public void adicinarExemplar(Exemplar exemplar)
        {

        }

        public int qtdeExemplares()
        {
            return 0;
        }

        public int qtdeDisponiveis()
        {
            return 0;
        }

        public int qtdeEmprestimos()
        {
            return 0;
        }

        public double percDisponibilidae()
        {
            return 0;
        }
    }
}
