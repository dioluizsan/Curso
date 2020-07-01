using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
namespace PecasXadrez {
    class PartidaDeXadrez {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez() {
            this.tab = new Tabuleiro(8, 8);
            this.turno = 1;
            this.jogadorAtual = Cor.Branca;
            Terminada = false;
            colocarPecas();
        }
        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pecaCapiturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        public void realizarJogada(Posicao origem, Posicao destino) {
            executaMovimento(origem, destino);
            turno++;
            mudajogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos) {
            if (tab.peca(pos) == null) {
                throw new tabuleiroException("Não existe peca na posicao origem escolhida!");
            }
            if (jogadorAtual !=tab.peca(pos).cor) {
                throw new tabuleiroException("Não é a vez do jogador com as peças"+ tab.peca(pos).cor + "! Selecione uma peça "+ jogadorAtual);
            }
            if (!tab.peca(pos).existeMovimentoPossiveis()) {
                throw new tabuleiroException("Não é possivel mover a peça!");
            }
        }

        public void validarPosicaoDeDetino(Posicao origem,Posicao destino) {
            if (!tab.peca(origem).podeMoverPara(destino)) {
                throw new tabuleiroException("Posicao de destino invalida!");
            }
           
        }
        public void mudajogador() {

            if (jogadorAtual == Cor.Branca) {
                jogadorAtual = Cor.Preta;

            }
            else {
                jogadorAtual = Cor.Branca;
            }
        }

        private void colocarPecas() {

            tab.colocarPeca(new Rei(Cor.Preta, tab), new PosicaoXadrez('d', 8).paraPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('c', 8).paraPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('e', 8).paraPosicao());

            tab.colocarPeca(new Rei(Cor.Branca, tab), new PosicaoXadrez('d', 1).paraPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('c', 1).paraPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('e', 1).paraPosicao());

        }
    }
}
