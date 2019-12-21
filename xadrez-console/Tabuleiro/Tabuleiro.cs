namespace tabuleiro
{
    /// <summary>
    /// Define o Tabuleiro.
    /// </summary>
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] pecas;

        /// <summary>
        /// Constrói o Tabuleiro, recebe como parâmetro um int quantidade de linhas e um int quantidade de colunas.
        /// </summary>
        /// <param name="linha"> Quantidade de linhas.</param>
        /// <param name="colunas"> Quantidade de colunas.</param>
        public Tabuleiro(int linha, int colunas)
        {
            this.Linhas = linha;
            this.Colunas = colunas;
            pecas = new Peca[Linhas, Colunas];
        }

        /// <summary>
        /// Retorna a peça do Tabuleiro que está na determinada int linha e int coluna recebidos como parâmetro.
        /// </summary>
        /// <param name="linha"> Índice da linha.</param>
        /// <param name="coluna"> Índice da coluna.</param>
        /// <returns> Retorna um vetor de peças.</returns>
        public Peca Peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        /// <summary>
        /// Retorna a peça do Tabuleiro que está em uma determinada Class Posicao recebida como parâmetro.
        /// </summary>
        /// <param name="pos"> Class Posicao.</param>
        /// <returns> Retorna a peça da posição informada.</returns>
        public Peca Peca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }

        /// <summary>
        /// Verifica se existe peca no Tabulueiro, na Class Posicao recebida como parâmetro.
        /// </summary>
        /// <param name="pos"> Class Posicao.</param>
        /// <returns> Retorna um boll true ou false.</returns>
        private bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        }

        /// <summary>
        /// Coloca a peça em uma posição do Tabuleiro, recebendo como parâmetros a Class Peca e a Class Posicao.
        /// </summary>
        /// <param name="p"> Class Peca.</param>
        /// <param name="pos"> Class Posicao.</param>
        public void ColocarPeca(Peca p, Posicao pos)
        {
            if(ExistePeca(pos))
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        /// <summary>
        /// Retira a peça em uma posição do Tabuleiro, recebendo como parâmetros a Class Posicao.
        /// </summary>
        /// <param name="pos"> Class Posicao.</param>
        /// <returns> Retorna a Class Peca.</returns>
        public Peca RetirarPeca(Posicao pos)
        {
            if (Peca(pos) == null)
                return null;
            Peca p = Peca(pos);
            p.Posicao = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return p;
        }

        /// <summary>
        /// Verifica se a posição do Tabuleiro é válida, recebendo como parâmetro a Class Posicao.
        /// </summary>
        /// <param name="pos"> Class Posicao.</param>
        /// <returns> Retorna um bool true ou false.</returns>
        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
                return false;
            return true;
        }

        /// <summary>
        /// Valida a posição imprimindo uma mensagem de erro, recebe como parâmetro a Class Posicao.
        /// </summary>
        /// <param name="pos"> Class Posicao.</param>
        private void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
                throw new TabuleiroException("Posição inválida!");
        }
    }
}
