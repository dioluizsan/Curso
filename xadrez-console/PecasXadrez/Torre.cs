﻿using System;
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
    }
}
