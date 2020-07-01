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
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public PartidaDeXadrez() {
            this.tab = new Tabuleiro(8, 8);
            this.turno = 1;
            this.jogadorAtual = Cor.Branca;
            Terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }
        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if (pecaCapturada!=null){
                capturadas.Add(pecaCapturada);
            }
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
        public HashSet<Peca> pecasCapturadas(Cor cor){
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas){
                if(x.cor==cor){
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Peca> pecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }
        public void colocarNovaPeca(char coluna,int linha,Peca peca){
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).paraPosicao());
            pecas.Add(peca);
        }

        private void colocarPecas() {
            colocarNovaPeca('c', 1, new Torre(Cor.Branca, tab));
            colocarNovaPeca('d', 1, new Rei(Cor.Branca, tab));
            colocarNovaPeca('e', 1, new Torre(Cor.Branca, tab));

            colocarNovaPeca('c', 8, new Torre(Cor.Preta, tab));
            colocarNovaPeca('d', 8, new Rei(Cor.Preta, tab));
            colocarNovaPeca('e', 8, new Torre(Cor.Preta, tab));

        }
    }
}
