using JogoDaVelha.Core.Helpers;

namespace JogoDaVelha.Core.Entities
{
    public class Tabuleiro
    {
        private char[,] Area { get; set; }

        private char SimboloJogador1 { get; set; } = 'X';
        private char SimboloJogador2 { get; set; } = 'O';

        private char SimboloJogadorAtual { get; set; }
        private char SimboloJogadorInimigo => SimboloJogadorAtual == SimboloJogador1 ? SimboloJogador2 : SimboloJogador1;

        public void Jogar()
        {
            Console.Clear();
            PrepararJogo();

            while (!VerificarVencedor())
            {
                Console.WriteLine($"VEZ DO JOGADOR: {SimboloJogadorAtual}");
                MostrarSituacaoTabuleiro();
                Console.WriteLine();

                var (linha, coluna) = ConsoleHelper.LerLinhaColuna("Digite a linha/coluna:");
                Console.Clear();

                if (linha > 2 || coluna > 2 || linha < 0 || coluna < 0)
                {
                    Console.WriteLine("As posições não podem ultrapassar o tamanho do tabuleiro!");
                    continue;
                }

                if (Area[linha, coluna] != ' ')
                {
                    Console.WriteLine("A posição deve estar vazia!");
                    continue;
                }

                Area[linha, coluna] = SimboloJogadorAtual;
                MudarVez();
            }
        }

        private void PrepararJogo()
        {
            Area = new char[3, 3]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
            };

            SimboloJogadorAtual = SimboloJogador1;
        }

        private void MostrarSituacaoTabuleiro()
        {
            Console.WriteLine("    0   1   2");
            var formatter = "| {0} | {1} | {2} |";

            for (var linha = 0; linha < 3; linha++)
            {
                var args = Enumerable.Range(0, 3)
                    .Select(coluna => Area[linha, coluna].ToString())
                    .ToArray();

                Console.WriteLine($"{linha} {string.Format(formatter, args)}");
            }
        }

        private bool VerificarVencedor()
        {
            foreach (var simbolo in new[] { SimboloJogador2, SimboloJogador1 })
            {
                if (Area[0, 0] == simbolo && Area[1, 1] == simbolo && Area[2, 2] == simbolo ||
                    Area[0, 2] == simbolo && Area[1, 1] == simbolo && Area[2, 0] == simbolo ||
                    Enumerable.Range(0, 3).Any(indice =>
                        Area[indice, 0] == simbolo && Area[indice, 1] == simbolo && Area[indice, 2] == simbolo ||
                        Area[0, indice] == simbolo && Area[1, indice] == simbolo && Area[2, indice] == simbolo
                    ))
                {
                    Console.Clear();
                    Console.WriteLine("FIM DE JOGO!");
                    Console.WriteLine($"JOGADOR [{simbolo}] GANHOU!");
                    MostrarSituacaoTabuleiro();

                    return true;
                }
            }

            return false;
        }

        private void MudarVez()
        {
            SimboloJogadorAtual = SimboloJogadorInimigo;
        }
    }
}
