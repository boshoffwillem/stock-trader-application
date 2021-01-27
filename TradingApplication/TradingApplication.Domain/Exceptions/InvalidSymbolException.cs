using System;

namespace TradingApplication.Domain.Exceptions
{
    public class InvalidSymbolException : Exception
    {
        public string Symbol { get; set; }

        public InvalidSymbolException(string symbol)
        {
            Symbol = symbol;
        }

        public InvalidSymbolException(string message, string symbol) : base(message)
        {
            Symbol = symbol;
        }

        public InvalidSymbolException(string message, Exception innerException, string symbol) : base(message, innerException)
        {
            Symbol = symbol;
        }
    }
}
