using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
namespace PecasXadrez {
    class PartidaDeXadrez {
        public Tabuleiro tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool Terminada { get; private set; }

        public PartidaDeXadrez() {
            this.tab = new Tabuleiro(8,8);
            this.turno = 1;
            this.jogadorAtual = Cor.Branca;
            Terminada = false;
            colocarPecas();
        }
        public void executaMovimento(Posicao origem,Posicao destino){
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pecaCapiturada=tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        private void colocarPecas(){
           
            tab.colocarPeca(new Rei(Cor.Preta, tab), new PosicaoXadrez('a', 1).paraPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('c', 2).paraPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('a', 3).paraPosicao());
        }
    }
}
