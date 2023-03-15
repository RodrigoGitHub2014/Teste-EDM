
using System;

namespace Teste_EDM
{
    public  class Nota
    {
        public Nota(){}

        public int Valor { get; set; }

        public int Quantidade { get; set; }

        public void SacarNota()
        {
            this.Quantidade = this.Quantidade - 1;
        }

        public Nota Clone()
        {
            return new Nota()
            {
                Valor = this.Valor,
                Quantidade = this.Quantidade
            };
        }
    }
}
