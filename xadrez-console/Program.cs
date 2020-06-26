using PecasXadrez;
using System;
using tabuleiro;
using PecasXadrez;
namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            //Posicao posicao = new Posicao(1,1);
            //Console.WriteLine(posicao);
            try {
                Tabuleiro tab = new Tabuleiro(8, 8);
                tab.colocarPeca(new Rei(Cor.Preta, tab), new Posicao(0, 0));
                tab.colocarPeca(new Torre(Cor.Preta, tab), new Posicao(0, 2));
                Tela.imprimeTabuleiro(tab);
            }
            catch (tabuleiroException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
