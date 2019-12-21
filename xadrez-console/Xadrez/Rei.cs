using tabuleiro;

namespace xadrez
{
    /// <summary>
    /// Define a peça Peão de um jogo de xadrez.
    /// </summary>
    class Rei : Peca
    {
        private PartidaDeXadrez Partida;

        /// <summary>
        /// Constrói a peça Rei recebendo como parâmetro um Class Tabuleiro, uma Class Cor e uma Class PartidaDeXadrez.
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="cor"></param>
        /// <param name="partida"></param>
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida)
            : base(tab, cor)
        {
            Partida = partida;
        }

        /// <summary>
        /// Imprime a letra que indica uma peça Rei.
        /// </summary>
        /// <returns> Retorna o string "R"</returns>
        public override string ToString()
        {
            return "R";
        }

        /// <summary>
        /// Verifica se pode mover o Rei para a posição indicada.
        /// </summary>
        /// <param name="pos"> Class Posicao.</param>
        /// <returns> Retorna um bool true ou false.</returns>
        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != Cor;
        }

        /// <summary>
        /// Verifica se tem uma torre disponível para fazer o Roque, recebe como parâmetro a Class Posicao da torre.
        /// </summary>
        /// <param name="pos"> Class Posicao.</param>
        /// <returns> Retorna um bool True ou False.</returns>
        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QteMovimentos == 0;
        }

        /// <summary>
        /// Retorna uma matriz de movimentos possíveis do Rei.
        /// </summary>
        /// <returns> Retorna um vetor com os movimentos possíveis.</returns>
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // norte
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;
            // nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;
            // leste
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;
            // sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;
            //sul
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;
            //sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;
            //oeste
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;
            //noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // #jogadaespecial roque
            if(QteMovimentos == 0 && !Partida.Xeque)
            {
                // #jogadaespecial roque pequeno
                Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null)
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                }

                // #jogadaespecial roque grande
                Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TesteTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null && Tab.Peca(p3) == null)
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                }
            }

            return mat;
        }
    }
}
