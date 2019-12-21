using tabuleiro;

namespace xadrez
{
    /// <summary>
    /// Define a posição do tabuleiro de xadrez.
    /// </summary>
    class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        /// <summary>
        /// Constrói a posição do tabuleiro de xadrez, recebendo como parâmetro a char coluna e a int linha.
        /// </summary>
        /// <param name="coluna"> Char coluna.</param>
        /// <param name="linha"> Int linha.</param>
        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        /// <summary>
        /// Retorna a posição d0 tabuleiro de xadrez como se ele fosse uma matriz de linhas por colunas.
        /// </summary>
        /// <returns> </returns>
        public Posicao ToPosicao()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        /// <summary>
        /// Imprime a posição de xadrez.
        /// </summary>
        /// <returns> Retorna a string que indica a posição do jogo de xadrez.</returns>
        public override string ToString()
        {
            return "" + Coluna + Linha;
        }

        
    }
}
