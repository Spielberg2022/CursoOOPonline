using tabuleiro;

namespace xadrez
{
    /// <summary>
    /// Define a peça Torre de um jogo de xadrez.
    /// </summary>
    class Torre : Peca
    {
        /// <summary>
        /// Constrói a peça Torre recebendo como parâmetro um Class Tabuleiro e uma Class Cor.
        /// </summary>
        /// <param name="tab"> Class Tabuleiro.</param>
        /// <param name="cor"> Class Cor.</param>
        public Torre(Tabuleiro tab, Cor cor)
            : base(tab, cor)
        {
        }

        /// <summary>
        /// Imprime a letra que indica uma peça Torre.
        /// </summary>
        /// <returns> Retorna o string "T"</returns>
        public override string ToString()
        {
            return "T";
        }

        /// <summary>
        /// Verifica se pode mover a Torre para a posição indicada.
        /// </summary>
        /// <param name="pos"> Class Posicao.</param>
        /// <returns> Retorna um bool true ou false.</returns>
        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != Cor;
        }

        /// <summary>
        /// Retorna uma matriz de movimentos possíveis da Torre.
        /// </summary>
        /// <returns> Retorna um vetor com os movimentos possíveis.</returns>
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // norte
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while(Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                    break;
                pos.Linha = pos.Linha - 1;
            }
            // sul
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                    break;
                pos.Linha = pos.Linha + 1;
            }
            // direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                    break;
                pos.Coluna = pos.Coluna + 1;
            }
            // esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                    break;
                pos.Coluna = pos.Coluna - 1;
            }

            return mat;
        }
    }
}
