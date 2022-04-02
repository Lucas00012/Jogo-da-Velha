using JogoDaVelha.Core.Entities;

Console.WriteLine(@"

     ██╗ ██████╗  ██████╗  ██████╗     ██████╗  █████╗ 
     ██║██╔═══██╗██╔════╝ ██╔═══██╗    ██╔══██╗██╔══██╗
     ██║██║   ██║██║  ███╗██║   ██║    ██║  ██║███████║
██   ██║██║   ██║██║   ██║██║   ██║    ██║  ██║██╔══██║
╚█████╔╝╚██████╔╝╚██████╔╝╚██████╔╝    ██████╔╝██║  ██║
 ╚════╝  ╚═════╝  ╚═════╝  ╚═════╝     ╚═════╝ ╚═╝  ╚═╝
                                                       
██╗   ██╗███████╗██╗     ██╗  ██╗ █████╗               
██║   ██║██╔════╝██║     ██║  ██║██╔══██╗              
██║   ██║█████╗  ██║     ███████║███████║              
╚██╗ ██╔╝██╔══╝  ██║     ██╔══██║██╔══██║              
 ╚████╔╝ ███████╗███████╗██║  ██║██║  ██║              
  ╚═══╝  ╚══════╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝              
                                                       
Como jogar?
- Forme uma combinação 3 símbolos iguais na vertical, horizontal ou diagonal
- A posição deve ser escolhida no formato (linha,coluna) sem os parênteses

Pressione qualquer tecla para continuar...
");

Console.ReadKey();
Console.Clear();

var tabuleiro = new Tabuleiro();
char opcao;

do
{
    tabuleiro.Jogar();

    do
    {
        Console.WriteLine();
        Console.WriteLine("Deseja jogar novamente? S/N");

        opcao = char.ToUpper(Console.ReadKey().KeyChar);
    } while (opcao != 'S' && opcao != 'N');
} while (opcao == 'S');