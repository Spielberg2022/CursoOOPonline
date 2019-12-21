using tabuleiro;

namespace xadrez 
{
    /// <summary>
    /// Define a peça Bispo de um jogo de xadrez
    /// </summary>
    class Bispo : Peca
    {
        /// <summary>
        /// Constrói a peça Bispo recebendo como parâmetro um Class Tabuleiro e uma Class Cor.
        /// </summary>
        /// <param name="tab"> Class Tabuleiro.</param>
        /// <param name="cor"> Class Cor.</param>
        public Bispo(Tabuleiro tab, Cor cor) 
            : base(tab, cor) 
        {
        }

        /// <summary>
        /// Imprime a letra que indica uma peça Bispo.
        /// </summary>
        /// <returns> Retorna o string "B".</returns>
        public override string ToString() 
        {
            return "B";
        }

        /// <summary>
        /// Verifica se pode mover o Bispo para a posição indicada.
        /// </summary>
        /// <param name="pos"> Class Posicao.</param>
        /// <returns> Retorna um bool true ou false.</returns>
        private bool PodeMover(Posicao pos) 
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != Cor;
        }
        
        /// <summary>
        /// Retorna uma matriz de movimentos possíveis do Bispo.
        /// </summary>
        /// <returns> Retorna um vetor com os movimentos possíveis.</returns>
        public override bool[,] MovimentosPossiveis() 
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // Noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) 
                    break;
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            // Nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                    break;
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            // Sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                    break;
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            // Sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor)
                    break;
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            return mat;
        }
    }
}
