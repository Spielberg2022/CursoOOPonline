using System;

namespace tabuleiro
{
    class TabuleiroException : Exception
    {
        public TabuleiroException(string msg)
            : base(msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}
