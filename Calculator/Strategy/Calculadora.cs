using System;

namespace Calculator.Strategy
{
    public class Calculadora
    {
        public Operacao Operacao { get; }

        public Calculadora(Operacao operacao)
        {
            Operacao = operacao;
        }

        public decimal Calcular(decimal n1, decimal n2) => this.Operacao.Calcular(n1, n2);
    }
}
