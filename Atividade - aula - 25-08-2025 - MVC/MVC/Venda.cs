using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    internal class Venda
    {
        private int qtde;
        private double valor;

        public int Qtde { get { return qtde; } set { qtde = value; } }

        public double Valor { get { return valor; } set { valor = value; } }

        public double valorMedio()
        {
            if (qtde == 0)
            {
                return 0;
            }
            return valor/qtde;
        }
    }
}
