using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            PosicaoXadrez pos1 = new PosicaoXadrez('a', 1);
            PosicaoXadrez pos2 = new PosicaoXadrez('c', 7);

            Console.WriteLine(pos1);
            Console.WriteLine(pos1.ToPosicao());

            Console.WriteLine(pos2);
            Console.WriteLine(pos2.ToPosicao());

        }
    }
}
