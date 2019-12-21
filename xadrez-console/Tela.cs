using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {
        /// <summary>
        /// Imprime a partida na tela, é necessário a Class PartidaDeXadrez para ser passada como parâmetro.
        /// </summary>
        /// <param name="partida"> Class PartidaDeXadrez que controla os dados da partida.</param>
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            if (!partida.Terminada)
            {
                Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
                if (partida.Xeque)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("XEQUE!");
                    Console.ResetColor();
                }
                    
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("XEQUEMATE!");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }
        }

        /// <summary>
        /// Imprime as peças capturadas na tela, é necessário a Class PartidaDeXadrez para ser passada como parâmetro.
        /// </summary>
        /// <param name="partida"> Class PartidaDeXadrez que controla os dados da partida</param>
        private static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        /// <summary>
        /// Imprime o conjunto de peças na tela, é necessário o conjunto da Class Peca para ser passado como parâmetro.
        /// </summary>
        /// <param name="conjunto"> Conjunto da Class Peca que controla as peças a serem impressas.</param>
        private static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
                Console.Write(x + " ");
            Console.Write("]");
        }

        /// <summary>
        /// Imprime o Tabuleiro na tela, é necessário a Class Tabuleiro para ser passada como parâmetro.
        /// </summary>
        /// <param name="tab"> Class Tabuleiro que deseja imprimir.</param>
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                    ImprimirPeca(tab.Peca(i, j));
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        /// <summary>
        /// Imprime o Tabuleiro na tela, é necessário a Class Tabuleiro e uma matriz de posições possívei para o tabuleiro indicar os movimentos possíveis da jogada.
        /// </summary>
        /// <param name="tab"> Class Tabuleiro que deseja imprimir.</param>
        /// <param name="posicoesPossiveis"> Matriz de movimentos possíveis da partida</param>
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                        Console.BackgroundColor = fundoAlterado;
                    else
                        Console.BackgroundColor = fundoOriginal;
                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        /// <summary>
        /// Lê a posição informada.
        /// </summary>
        /// <returns> Retorna a Class PosicaoXadrez.</returns>
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        /// <summary>
        /// Imprime as peças na tela, é necessário a Class Peca para ser passada como parâmetro.
        /// </summary>
        /// <param name="peca"> Class Peca que deseja imprimir.</param>
        private static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
                Console.Write("- ");
            else
            {
                if (peca.Cor == Cor.Branca)
                    Console.Write(peca);
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
