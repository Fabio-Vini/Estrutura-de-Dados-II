using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcRestaurante
{
    internal class Item
    {
        private int id;
        private string descricao;
        private double preco;

        public int Id { get { return id; } }
        public string Descricao { get { return descricao; } set { descricao = value; } }
        public double Preco { get { return preco; } set { preco = value; } }

        public Item(int id, string descricao, double preco)
        {
            this.id = id;
            this.Descricao = descricao;
            this.Preco = preco;
        }

        public Item(int id) : this(id, "", 0)
        {
        }
    }
}
