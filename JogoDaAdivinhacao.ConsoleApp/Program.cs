using System;
using System.Threading;

namespace JogoDaAdivinhacao.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random gerarNumero = new Random();
            int numeroGerado = gerarNumero.Next(1, 21); // Alterado para incluir o número 20
            int numeroDigitado = 0;

            double pontuacao = 1000; // Alterado para double para lidar com decimais

            // Boas vindas e Explicação sobre o jogo
            Console.WriteLine("*************************************");
            Console.WriteLine(@"* Bem-vindo ao Jogo da Adivinhação! *");
            Console.WriteLine("*************************************");
            Console.WriteLine("\nO jogo gerou um número aleatório entre 1 e 20! Tente adivinhar qual o número.\n");

            int maxTentativas = 0;
            while (maxTentativas == 0)
            {
                Console.WriteLine("Escolha o nível de dificuldade:");
                Console.WriteLine("1 - Fácil (15 tentativas)");
                Console.WriteLine("2 - Médio (10 tentativas)");
                Console.WriteLine("3 - Difícil (5 tentativas)");
                Console.Write("\nEscolha uma opção: ");

                int opcao;
                if (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 3)
                {
                    Console.WriteLine("Opção inválida. Escolha um número de 1 a 3.");
                }
                else
                {
                    switch (opcao)
                    {
                        case 1:
                            maxTentativas = 15;
                            break;
                        case 2:
                            maxTentativas = 10;
                            break;
                        case 3:
                            maxTentativas = 5;
                            break;
                    }
                }
            }

            Console.WriteLine($"\nVocê tem {maxTentativas} tentativas.");

            for (int tentativa = 1; tentativa <= maxTentativas; tentativa++)
            {
                Console.WriteLine($"\nTentativa {tentativa}");
                Console.Write("Digite um número: ");
                numeroDigitado = int.Parse(Console.ReadLine());

                if (numeroDigitado == numeroGerado)
                {
                    Console.WriteLine("Parabéns! Você acertou o número gerado.");
                    break;
                }
                else
                {
                    Console.WriteLine(numeroDigitado < numeroGerado
                        ? "O número digitado é menor que o número gerado."
                        : "O número digitado é maior que o número gerado.");

                    // Calcular a pontuação do jogador apenas se ele errar
                    double diferenca = Math.Abs(numeroDigitado - numeroGerado) / 2.0;
                    pontuacao -= diferenca; // A pontuação agora é atualizada corretamente com decimais

                    Console.WriteLine($"Sua pontuação atual é: {pontuacao:N2}"); // Exibindo com duas casas decimais

                    if (tentativa == maxTentativas)
                    {
                        Console.WriteLine($"\nEssa foi sua última tentativa. O número gerado era {numeroGerado}.");
                        Console.WriteLine($"Sua pontuação final é: {pontuacao:N2}");
                        Console.WriteLine("Que pena, você perdeu.");
                        break;
                    }
                }

                Thread.Sleep(3000);
                Console.Clear();
            }

            // Verificar se o jogador acertou e mostrar a pontuação final
            if (numeroDigitado == numeroGerado)
            {
                Console.WriteLine($"Parabéns! Você ganhou com uma pontuação final de: {pontuacao:N2}");
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
