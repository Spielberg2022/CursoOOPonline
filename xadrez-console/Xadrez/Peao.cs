using tabuleiro;

namespace xadrez
{
    /// <summary>
    /// Define a peça Peão de um jogo de xadrez.
    /// </summary>
    class Peao : Peca
    {
        private PartidaDeXadrez Partida;

        /// <summary>
        /// Constrói a peça Peão recebendo como parâmetro um Class Tabuleiro, uma Class Cor e uma Class PartidaDeXadrez.
        /// </summary>
        /// <param name="tab"> Class Tabuleiro.</param>
        /// <param name="cor"> Class Cor.</param>
        /// <param name="partida"> Class PartidaDeXadrez.</param>
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) 
            : base(tab, cor)
        {
            Partida = partida;
        }

        /// <summary>
        /// Imprime a letra que indica uma peça Peão.
        /// </summary>
        /// <returns> Retorna o string "P".</returns>
        public override string ToString()
        {
            return "P";
        }

        /// <summary>
        /// Verifica se existe peça inimiga na Class Posicao recebida como parâmetro.
        /// </summary>
        /// <param name="pos"> Class Posicao</param>
        /// <returns> Retorna um bool True ou False.</returns>
        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p.Cor != Cor;
        }

        /// <summary>
        /// Verifica se a Class Posicao indicada está livre.
        /// </summary>
        /// <param name="pos"> Class Posicao.</param>
        /// <returns> Retorna um bool True ou False.</returns>
        private bool Livre(Posicao pos)
        {
            return Tab.Peca(pos) == null;
        }

        /// <summary>
        /// Retorna uma matriz de movimentos possíveis do Peão.
        /// </summary>
        /// <returns> Retorna um vetor com os movimentos possíveis.</returns>
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Branca)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(p2) && Livre(p2) && Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                // jogadaespecial en passant
                if(Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.Peca(esquerda) == Partida.VulneravelEnPassant)
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.Peca(direita) == Partida.VulneravelEnPassant)
                        mat[direita.Linha - 1, direita.Coluna] = true;
                }
            }
            else
            {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosicaoValida(p2) && Livre(p2) && Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                // jogadaespecial en passant
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.Peca(esquerda) == Partida.VulneravelEnPassant)
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.Peca(direita) == Partida.VulneravelEnPassant)
                        mat[direita.Linha + 1, direita.Coluna] = true;
                }
            }

            return mat;
        }
    }
}
