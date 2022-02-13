using System;

namespace Calculator.Strategy.Operacoes
{
    public class Multiplicacao : Operacao
    {
        public override decimal Calcular(decimal n1, decimal n2) => n1 * n2;
    }
}
