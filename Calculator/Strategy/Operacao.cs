using System;

namespace Calculator.Strategy
{
    public abstract class Operacao
    {
        public abstract decimal Calcular(decimal n1, decimal n2);
    }
}
