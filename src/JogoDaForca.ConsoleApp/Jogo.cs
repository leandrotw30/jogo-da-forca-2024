using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca.ConsoleApp
{
    public class Jogo
    {
        public string palavraEscolhida;
        public int tamanhoDaPalavra;
        public char[] palavraPreenchida;
        public int numeroErros = 0;

        public void DesenharForca()
        {
            Console.WriteLine("Jogo da Forca!");
            Console.WriteLine();

            Console.SetCursorPosition(0, 1);
            Console.Write(" -----------");
            Console.SetCursorPosition(0, 2);
            Console.Write(" |/        |");
            Console.SetCursorPosition(0, 3);
            Console.Write(" |");
            Console.SetCursorPosition(0, 4);
            Console.Write(" |");
            Console.SetCursorPosition(0, 5);
            Console.Write(" |");
            Console.SetCursorPosition(0, 6);
            Console.Write(" |");
            Console.SetCursorPosition(0, 7);
            Console.Write(" |");
            Console.SetCursorPosition(0, 8);
            Console.Write(" |");
            Console.SetCursorPosition(0, 9);
            Console.Write("_|____");
        }

        public string EscolherPalavra()
        {
            Random numeroAleatorio = new Random();
            int numeroAleatorioEscolhido = numeroAleatorio.Next(0, 29);

            string[] opcoesDePalavras = new string[] {"Abacate", "Abacaxi", "Acerola", "Açaí", "Araça", "Bacaba", "Bacuri", "Banana", "Cajá", "Cajú",
            "Carambola", "Cupuaçu", "Graviola", "Goiaba", "Jabuticaba", "Jenipapo", "Maçã", "Mangaba", "Manga", "Maracujá", "Murici", "Pequi", "Pitanga",
            "Pitaya", "Sapoti", "Tangerina", "Umbu", "Uva", "Uvaia"};

            palavraEscolhida = opcoesDePalavras[numeroAleatorioEscolhido].ToUpper();
            tamanhoDaPalavra = palavraEscolhida.Length;

            return ObterPalavraPreenchida();
        }

        private string ObterPalavraPreenchida()
        {
            palavraPreenchida = new char[palavraEscolhida.Length];
            for (int i = 0; i < palavraEscolhida.Length; i++)
            {
                palavraPreenchida[i] = '_';
            }
            return string.Join("", palavraPreenchida);
        }

        public void EscreverLetrasEncontradas(string letrasEncontradas)
        {
            Console.SetCursorPosition(0, 11);
            Console.Write(letrasEncontradas);
        }

        public char Chutar() 
        {
            Console.SetCursorPosition(0, 13);
            Console.Write("                                ");
            Console.SetCursorPosition(0, 13);
            Console.Write("Qual o seu chute? ");
            char chute = Convert.ToChar(Console.ReadLine().ToUpper());
            return chute;
        }

        public bool ChutesCertos(char chute)
        {
            for (int j = 0; j < tamanhoDaPalavra; j++)
            {
                if (palavraEscolhida[j].Equals(chute))
                {
                    palavraPreenchida[j] = chute; //tamanhoDaPalavra
                    Console.SetCursorPosition(j, 11);
                    Console.Write(chute);
                }
            }
            if (!palavraPreenchida.Contains('_'))
            {
                Console.SetCursorPosition(0, 13);
                Console.Write("Parabéns, você acertou!        ");
                Console.WriteLine();
                return true;
            }
            return false;
        }

        public void ChutesErrados()
        {
            numeroErros++;
            switch (numeroErros)
            {
                case 1:
                    Console.SetCursorPosition(11, 3);
                    Console.Write('o');
                    break;
                case 2:
                    Console.SetCursorPosition(10, 4);
                    Console.Write('/');
                    break;
                case 3:
                    Console.SetCursorPosition(11, 4);
                    Console.Write('x');
                    break;
                case 4:
                    Console.SetCursorPosition(12, 4);
                    Console.Write('\\');
                    break;
                case 5:
                    Console.SetCursorPosition(11, 5);
                    Console.Write('x');
                    Console.SetCursorPosition(0, 13);
                    Console.Write("O jogo acabou!        ");
                    Console.WriteLine();
                    break;
                default:
                    break;
            }
        }
    }
}
