namespace tabuleiro
{
    /// <summary>
    /// Define as peças do jogo.
    /// </summary>
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Tabuleiro Tab { get; protected set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public abstract bool[,] MovimentosPossiveis();

        /// <summary>
        /// Constrói as peças do jogo recebendo como parâmetro um Class Tabuleiro e uma Class Cor.
        /// </summary>
        /// <param name="tab"> Class Tabuleiro da qual a peça faz parte.</param>
        /// <param name="cor"> Class Cor que define a cor da peça.</param>
        public Peca(Tabuleiro tab, Cor cor)
        {
            Posicao = null;
            QteMovimentos = 0;
            Cor = cor;
            Tab = tab;
        }

        /// <summary>
        /// Incrementa a quantidade de jogadas da peça.
        /// </summary>
        public void IncrementarQtdMovimentos()
        {
            QteMovimentos++;
        }

        /// <summary>
        /// Decremente a quantidade de jogada da peça.
        /// </summary>
        public void DecrementarQtdMovimentos()
        {
            QteMovimentos--;
        }

        /// <summary>
        /// Verifica os movimentos possíveis da peça dentro do tabuleiro como um todo.
        /// </summary>
        /// <returns> Retorna true ou false</returns>
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for(int i=0; i<Tab.Linhas; i++)
                for(int j=0; j<Tab.Colunas; j++)
                    if (mat[i, j])
                        return true;
            return false;
        }

        /// <summary>
        /// Verifica o movimento possível da peça na determida Class Posicao que é passada como parâmetro.
        /// </summary>
        /// <param name="pos"> Class Posica que informa a posição a ser verificada</param>
        /// <returns> Retorna a Matriz de movimentos possíveis.</returns>
        public bool MovimentoPossivel(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        } 
    }
}
