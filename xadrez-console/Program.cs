using PecasXadrez;
using System;
using tabuleiro;
using PecasXadrez;
using System.Linq.Expressions;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            //Posicao posicao = new Posicao(1,1);
            //Console.WriteLine(posicao);
            try {

                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.Terminada) {
                    try {

                        Console.Clear();
                        Tela.imprimirPartida(partida);
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().paraPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentoPossiveis();

                        Console.Clear();
                        Tela.imprimeTabuleiro(partida.tab, posicoesPossiveis);

                        
                        Console.WriteLine();
                        Console.Write("Destino:");
                        Posicao destino = Tela.lerPosicaoXadrez().paraPosicao();
                        partida.validarPosicaoDeDetino(origem, destino);

                        partida.realizarJogada(origem, destino);
                    }
                    catch (tabuleiroException e) {
                        Console.Write(e.Message);
                        Console.ReadLine();
                    }
                }


            }
            catch (tabuleiroException e) {
                Console.Write(e.Message);
            }
        }
    }
}
