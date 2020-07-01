using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
namespace PecasXadrez {
    class Torre:Peca {
        public Torre(Cor cor,Tabuleiro tab):base(cor,tab){
           
        }
        public override string ToString() {
            return "T";
        }

        private bool podeMover(Posicao pos) {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentoPossiveis() {
            bool[,] matriz = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            //Para cima
            pos.definirValoresDaPosicao(posicao.linha - 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                matriz[pos.linha, pos.coluna] = true;
                if(tab.peca(pos)!=null && tab.peca(pos).cor !=cor){
                    break;
                }
                pos.linha = pos.linha - 1;
            }


            //Para direita
            pos.definirValoresDaPosicao(posicao.linha, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                matriz[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }
           

            //Para baixo
            pos.definirValoresDaPosicao(posicao.linha + 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                matriz[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }
                pos.linha = pos.linha + 1;
            }


            //Para esquerda
            pos.definirValoresDaPosicao(posicao.linha, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos)) {
                matriz[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor) {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }


            return matriz;
        }
    }
}
