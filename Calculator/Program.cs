using System;
using Calculator.Strategy;
using Calculator.Strategy.Enumerators;

namespace Calculator
{
    class Program
    {
        private static Action<string> _log;

        static void Menu()
        {
            _log("O que deseja fazer ?");
            _log("1 - Soma");
            _log("2 - Subtracao");
            _log("3 - Multiplicacao");
            _log("4 - Divisao");
            _log("5 - Sair");
        }

        static void Main(string[] args)
        {
            _log = Console.WriteLine;

            int operacao = 0;

            do
            {
                FluxoUsuario(ref operacao);
            } 
            while (operacao != 5);
        }

        static void FluxoUsuario(ref int operacao)
        {
            try
            {
                Menu();

                int.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.None, null, out operacao);

                if (operacao == 0)
                    throw new InvalidOperationException("Opção inválida!");
                
                if (operacao == 5)
                    return;

                var calculadora =  CalculadoraFactory.Criar((TipoOperacao)operacao);

                decimal? n1 = LerValor("Insira o primeiro valor:");
                decimal? n2 = LerValor("Insira o segundo valor:");

                _log($"O resultado é: {calculadora.Calcular(n1.Value, n2.Value)}");
                _log("=============================");
            }
            catch (InvalidOperationException ex)
            {
                _log(ex.Message);
            }
        }

        static decimal? LerValor(string texto)
        {
            _log(texto);

            decimal valor = 0;
            return decimal.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.AllowDecimalPoint, null, out valor)
                ? valor
                : throw new InvalidOperationException("Entrada inválida!");
        }
    }
}
