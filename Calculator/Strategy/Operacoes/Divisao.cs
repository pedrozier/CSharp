using System;

namespace Calculator.Strategy.Operacoes
{
    public class Divisao : Operacao
    {
        public override decimal Calcular(decimal n1, decimal n2) => n1 / n2;
    }
}
