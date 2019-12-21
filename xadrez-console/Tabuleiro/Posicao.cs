namespace tabuleiro
{
    /// <summary>
    /// Define a posição.
    /// </summary>
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        /// <summary>
        /// Constrói a posição no tabuleiro recebendo um int linha para a posição da linha e um int coluna para a posição da coluna como parâmetro.
        /// </summary>
        /// <param name="linha"> Índice da linha.</param>
        /// <param name="coluna"> Índice da coluna.</param>
        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        /// <summary>
        /// Define os valores da linha e da coluna, recebendo como parâmetro um int linha e um int coluna.
        /// </summary>
        /// <param name="linha"> Índice da linha.</param>
        /// <param name="coluna"> Índice da coluna.</param>
        public void DefinirValores(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        /// <summary>
        /// String que indica a posição.
        /// </summary>
        /// <returns> Retorna uma string que indica a posição.</returns>
        public override string ToString()
        {
            return Linha
                + ", "
                + Coluna;
        }
    }
}
