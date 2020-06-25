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
    }
}

