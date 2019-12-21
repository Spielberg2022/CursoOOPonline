using System;

namespace tabuleiro
{
    /// <summary>
    /// Define os erros do Tabuleiro de jogo.
    /// </summary>
    class TabuleiroException : Exception
    {
        /// <summary>
        /// Constrói uma exceção com a mensagem informada, recebe como parâmetro a string da mensagem.
        /// </summary>
        /// <param name="msg"> String mensagem a ser impressa.</param>
        public TabuleiroException(string msg)
            : base(msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}
