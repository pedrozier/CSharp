using System;
using Calculator.Strategy.Enumerators;
using Calculator.Strategy.Operacoes;

namespace Calculator.Strategy
{
    public sealed class CalculadoraFactory
    {
        private CalculadoraFactory()
        {
        }

        public static Calculadora Criar(TipoOperacao tipoOperacao)
        {
            Operacao operacao = tipoOperacao switch 
            {
                TipoOperacao.Soma => new Soma(),
                TipoOperacao.Subtracao => new Subtracao(),
                TipoOperacao.Multiplicacao => new Multiplicacao(),
                TipoOperacao.Divisao => new Divisao(),
                _ => throw new InvalidOperationException("Tipo de operação inválida!")
            };

            return new Calculadora(operacao);
        }
    }
}
