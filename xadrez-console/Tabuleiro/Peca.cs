using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace tabuleiro {
    abstract class Peca {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimento { get; protected set; }

        public Tabuleiro tab { get; protected set; }

        public Peca(Cor cor, Tabuleiro tab) {
            this.posicao = null;
            this.cor = cor;
            qtdMovimento = 0;
            this.tab = tab;
        }

        public abstract bool[,] movimentoPossiveis();
        public void incrementarQtdMovimentos() {
            qtdMovimento++;
        }
        public bool podeMoverPara(Posicao pos){
            return movimentoPossiveis()[pos.linha, pos.coluna];
        }
        public bool existeMovimentoPossiveis() {
            bool[,] matriz = movimentoPossiveis();
            for (int i = 0; i < tab.linhas; i++) {
                for (int j = 0; j < tab.colunas; j++) {
                    if (matriz[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }
        
    }
}
