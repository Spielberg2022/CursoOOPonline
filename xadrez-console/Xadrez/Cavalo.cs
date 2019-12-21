using tabuleiro;

namespace xadrez
{
    /// <summary>
    /// Define a peça Cavalo de um jogo de xadrez.
    /// </summary>
    class Cavalo : Peca
    {
        /// <summary>
        /// Constrói a peça Cavalo recebendo como parâmetro um Class Tabuleiro e uma Class Cor.
        /// </summary>
        /// <param name="tab"> Class Tabuleiro.</param>
        /// <param name="cor"> Class Cor.</param>
        public Cavalo(Tabuleiro tab, Cor cor)
            : base(tab, cor)
        {
        }

        /// <summary>
        /// Imprime a letra que indica uma peça Cavalo.
        /// </summary>
        /// <returns> Retorna o string "C".</returns>
        public override string ToString()
        {
            return "C";
        }

        /// <summary>
        /// Verifica se pode mover o Cavalo para a posição indicada.
        /// </summary>
        /// <param name="pos"> Class Posicao.</param>
        /// <returns> Retorna um bool true ou false.</returns>
        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != Cor;
        }

        /// <summary>
        /// Retorna uma matriz de movimentos possíveis do Cavalo.
        /// </summary>
        /// <returns> Retorna um vetor com os movimentos possíveis.</returns>
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            return mat;
        }
    }
}
