using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listaBiblioteca
{
    internal class Livros
    {
        private List<Livro> _acervo = new List<Livro>();

        public List<Livro> acervo {  get { return _acervo; } set { _acervo = value; } }

        public void adicionar(Livro livro)
        {
            acervo.Add(livro);
        }

        public Livro pesquisar (Livro livro)
        {
            return acervo.FirstOrDefault(l => l.Isbn == livro.Isbn);
        }
    }
}
