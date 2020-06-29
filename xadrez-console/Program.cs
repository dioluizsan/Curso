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

                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.Terminada) {
                    Console.Clear();

                   Tela.imprimeTabuleiro(partida.tab);
                   Console.WriteLine();
                   Console.Write("Origem:");
                   Posicao origem = Tela.lerposicaoxadrez().paraPosicao();
                   Console.Write("Destino:");
                   Posicao destino = Tela.lerposicaoxadrez().paraPosicao();

                    partida.executaMovimento(origem, destino);

                }


            }
            catch (tabuleiroException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
