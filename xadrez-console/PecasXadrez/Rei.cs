using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace PecasXadrez {
    class Rei : Peca {
        public Rei(Cor cor,Tabuleiro tab):base(cor,tab){
            
        }
        public override string ToString() {
            return "R";
        }

        private bool podeMover(Posicao pos){
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentoPossiveis() {
            bool[,] matriz = new bool[tab.linhas,tab.colunas] ;
            Posicao pos = new Posicao(0, 0);

            //Para cima
            pos.definirValoresDaPosicao(posicao.linha-1, posicao.coluna);
            if(tab.posicaoValida(pos)&&podeMover(pos)){
                matriz[pos.linha, pos.coluna] = true;
            }

            //Para Nordeste
            pos.definirValoresDaPosicao(posicao.linha - 1, posicao.coluna+1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                matriz[pos.linha, pos.coluna] = true;
            }

            //Para direita
            pos.definirValoresDaPosicao(posicao.linha , posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                matriz[pos.linha, pos.coluna] = true;
            }
            //Para sudeste
            pos.definirValoresDaPosicao(posicao.linha + 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                matriz[pos.linha, pos.coluna] = true;
            }

            //Para baixo
            pos.definirValoresDaPosicao(posicao.linha + 1, posicao.coluna );
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                matriz[pos.linha, pos.coluna] = true;
            }


            //Para suloste
            pos.definirValoresDaPosicao(posicao.linha + 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                matriz[pos.linha, pos.coluna] = true;
            }

            //Para esquerda
            pos.definirValoresDaPosicao(posicao.linha , posicao.coluna -1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                matriz[pos.linha, pos.coluna] = true;
            }

            //Para Noroeste
            pos.definirValoresDaPosicao(posicao.linha-1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                matriz[pos.linha, pos.coluna] = true;
            }
            return matriz;
        }
    }
}

