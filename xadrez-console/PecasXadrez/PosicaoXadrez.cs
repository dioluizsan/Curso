using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;
using tabuleiro;
//converter posicao para o equivalente ao nomeados no xadrez
//exempo de como sera a conversao

//00 01 02 03 04 05 06 07 
//10 11 12 13 14 15 16 17 
//20 21 22 23 24 25 26 27 
//30 31 32 33 34 35 36 37 
//...
//80 81 82 83 84 85 86 87 

//para

//A8 B8 C8 D8 E8 F8 G8 H8
//A7 B7 C7 D7 E7 F7 G7 H7
//A6 B6 C6 D6 E6 F6 G6 H6
//A5 B5 C5 D5 E5 F5 G5 H5
//...
//A1 B1 C1 D1 E1 F1 G1 H1


namespace PecasXadrez {
    class PosicaoXadrez {
        public char coluna { get; set; }
        public int linha { get; set; }
        

        public PosicaoXadrez(char coluna, int linha) {
            this.linha = linha;
            this.coluna = coluna;
        }

        public Posicao paraPosicao(){
            return new Posicao(8 - linha, coluna - 'a');
        }
        public override string ToString() {
            return "" + coluna + linha;
        }
    }
}
